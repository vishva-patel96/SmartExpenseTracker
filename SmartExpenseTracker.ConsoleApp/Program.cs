using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartExpenseTracker.Application.Services;
using SmartExpenseTracker.Domain.Interfaces;
using SmartExpenseTracker.Infrastructure;
using SmartExpenseTracker.Infrastructure.Repositories;

// Ensure Microsoft.Extensions.Configuration is referenced so ConfigurationBuilder is available.

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var services = new ServiceCollection();

services.AddDbContext<ExpenseDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("ExpenseDb")));

services.AddScoped<IExpenseRepository, ExpenseRepository>();
services.AddScoped<IExpenseService, ExpenseService>();

var serviceProvider = services.BuildServiceProvider();
MainMenu.Show(serviceProvider);