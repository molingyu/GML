﻿using System.Text.RegularExpressions;

namespace GUML;

public partial class KeyConverter : IConverter
{
    public ConverterType ConverterType => ConverterType.KeyName;

    public object Convert(object source)
    {
        if (source is string keyName)
        {
            return ToPascalCase(keyName);
        }

        throw new Exception("");
    }
    
    public static string FromCamelCase(string str)
    {
        // 确保首字母始终为小写
        str = char.ToLower(str[0]) + str.Substring(1);

        str = FromCamelRegex().Replace(str, match => '_' + match.Groups["char"].Value.ToLowerInvariant());
        return str;
    }
    
    public static string ToPascalCase(string str)
    {
        var text = ToPascalRegex().Replace(str, match => match.Groups["char"].Value.ToUpperInvariant());
        return char.ToUpperInvariant(text[0]) + text[1..];
    }

    [GeneratedRegex("([_\\-])(?<char>[a-z])")]
    private static partial Regex ToPascalRegex();
    
    [GeneratedRegex("(?<char>[A-Z])")]
    private static partial Regex FromCamelRegex();
}
