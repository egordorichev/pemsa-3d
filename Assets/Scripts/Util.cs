using System;

public static class Util {
    public static int HexToInt(char hexChar)  {
        hexChar = char.ToUpper(hexChar);
        return Math.Min(15, Math.Max(0, (int) hexChar < (int) 'A' ? (hexChar - '0') : 10 + (hexChar - 'A')));
    }
}