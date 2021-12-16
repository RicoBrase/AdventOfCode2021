namespace AdventOfCode._2021.Day16.Packets;

public static class PacketType
{
    public const int SUM = 0;
    public const int PRODUCT = 1;
    public const int MINIMUM = 2;
    public const int MAXIMUM = 3;
    public const int LITERAL_VALUE = 4;
    public const int GREATER_THAN = 5;
    public const int LESS_THAN = 6;
    public const int EQUAL_TO = 7;
}