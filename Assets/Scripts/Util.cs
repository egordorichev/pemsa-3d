public static class Util {
    public static int HexToInt(char hexChar)  {
        hexChar = char.ToUpper(hexChar);
        return (int) hexChar < (int) 'A' ? (hexChar - '0') : 10 + (hexChar - 'A');
    }
}