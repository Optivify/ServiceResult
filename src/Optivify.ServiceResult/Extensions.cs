using System.Text;

namespace Optivify.ServiceResult;

public static class Extensions
{
    public static string? JoinStrings(this IEnumerable<string>? strings, char separator = '.')
    {
        if (strings is null)
        {
            return null;
        }

        var sb = new StringBuilder();

        foreach (var str in strings)
        {
            var refinedString = str.Trim();
            sb.Append(refinedString);

            if (!refinedString.EndsWith(separator))
            {
                sb.Append(separator);
            }

            sb.Append(' ');
        }

        return sb.ToString().Trim();
    }
}
