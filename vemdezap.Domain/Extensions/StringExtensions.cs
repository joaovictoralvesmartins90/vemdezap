using System;
using System.Text;

namespace vemdezap.Domain.Extensions;

public static class StringExtensions
{
    //o this é pra dizer que é uma extensão do objeto que quer usar aquele método
    public static string ConvertToMD5(this string texto)
    {
        if (string.IsNullOrEmpty(texto))
        {
            return "";
        }

        var senha = texto += "|2d331cca-f6c0-40c0-bb43-6e32989c2881";
        var md5 = System.Security.Cryptography.MD5.Create();
        var data = md5.ComputeHash(Encoding.Default.GetBytes(senha));
        var sbString = new StringBuilder();

        foreach (var t in data)
        {
            sbString.Append(t.ToString("x2"));
        }

        return sbString.ToString();
    }
}
