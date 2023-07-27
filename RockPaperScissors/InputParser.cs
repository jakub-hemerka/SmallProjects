namespace RockPaperScissors;
public static class InputParser
{
    private static readonly Dictionary<char, char> _replacementTable = new()
    {
        ['á'] = 'a',
        ['č'] = 'c',
        ['ď'] = 'd',
        ['é'] = 'e',
        ['ě'] = 'e',
        ['í'] = 'i',
        ['ň'] = 'n',
        ['ó'] = 'o',
        ['ř'] = 'r',
        ['š'] = 's',
        ['ť'] = 't',
        ['ú'] = 'u',
        ['ů'] = 'u',
        ['ý'] = 'y',
        ['ž'] = 'z'
    };

    public static string RemoveDiacritics(this string text)
    {
        char[] arr = text.ToCharArray();

        for (int i = 0; i < arr.Length; i++)
        {
            if (_replacementTable.ContainsKey(arr[i]))
            {
                arr[i] = _replacementTable[arr[i]];
            }
        }

        return new string(arr);
    }
}