using System.Text;

Check("", 0, true, "", "");
Check(" ", 0, true, "", "  ");
Check(" a b ", 2, false, "A. B.", " a b  a b ");
Check("А роза упала на лапу Азора", 6, true, "А. Р. У. Н. Л. А.",
    "А роза упала на лапу АзораА роза упала на лапу Азора");
Check("Ахметов Ерлан", 2, false, "А. Е.", "Ахметов ЕрланАхметов Ерлан");
Report("Initials", "А. Е. С.", TextTools.Initials("Ахметов Ерлан Серикұлы"));
Report("Repeat (n = 0)", "", TextTools.Repeat("a", 0));

static void Check(string input, int words, bool palindrome, string initials, string repeated)
{
    Console.WriteLine($"Вход: «{input}»");
    Report("CountWords", words, TextTools.CountWords(input));
    Report("IsPalindrome", palindrome, TextTools.IsPalindrome(input));
    Report("Initials", initials, TextTools.Initials(input));
    Report("Repeat (n = 2)", repeated, TextTools.Repeat(input, 2));
}

static void Report<T>(string test, T expected, T actual)
{
    string status = EqualityComparer<T>.Default.Equals(expected, actual) ? "OK" : "FAIL";
    Console.WriteLine($"{test}: ожидалось «{expected}», получено «{actual}» — {status}");
    if (status == "FAIL")
        Environment.ExitCode = 1;
}

static class TextTools
{
    public static int CountWords(string s)
    {
        int count = 0;
        bool inWord = false;
        foreach (char c in s)
        {
            bool isWordChar = !char.IsWhiteSpace(c);
            if (isWordChar && !inWord)
                count++;
            inWord = isWordChar;
        }
        return count;
    }

    public static bool IsPalindrome(string s)
    {
        int left = 0;
        int right = s.Length - 1;
        while (left < right)
        {
            if (char.IsWhiteSpace(s[left]))
            {
                left++;
                continue;
            }
            if (char.IsWhiteSpace(s[right]))
            {
                right--;
                continue;
            }
            if (char.ToUpperInvariant(s[left]) != char.ToUpperInvariant(s[right]))
                return false;
            left++;
            right--;
        }
        return true;
    }

    public static string Initials(string fullName)
    {
        var initials = new StringBuilder();
        bool inWord = false;
        foreach (char c in fullName)
        {
            bool isWordChar = !char.IsWhiteSpace(c);
            if (isWordChar && !inWord)
            {
                if (initials.Length > 0)
                    initials.Append(' ');
                initials.Append(char.ToUpperInvariant(c)).Append('.');
            }
            inWord = isWordChar;
        }
        return initials.ToString();
    }

    public static string Repeat(string s, int n)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(n);
        var result = new StringBuilder();
        for (int i = 0; i < n; i++)
            result.Append(s);
        return result.ToString();
    }
}