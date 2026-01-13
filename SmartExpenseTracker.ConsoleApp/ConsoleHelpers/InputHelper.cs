public static class InputHelper
{
    public static int ReadInt(string message)
    {
        Console.Write(message);
        return int.Parse(Console.ReadLine());
    }

    public static decimal ReadDecimal(string message)
    {
        Console.Write(message);
        return decimal.Parse(Console.ReadLine());
    }
}
