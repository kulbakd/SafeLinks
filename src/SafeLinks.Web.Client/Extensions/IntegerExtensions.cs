namespace SafeLinks.Web.Client.Extensions;

public static class IntegerExtensions
{
    private const string Base36CharList = "0123456789abcdefghijklmnopqrstuvwxyz";

    private static string Encode(int number) {
        var n = number / 36;
        var c = Base36CharList[number % 36];
        return n > 0 ? Encode(n) + c : c.ToString();
    }

    public static string ToBase36(this int number)
    {
        return Encode(number);
    }
}