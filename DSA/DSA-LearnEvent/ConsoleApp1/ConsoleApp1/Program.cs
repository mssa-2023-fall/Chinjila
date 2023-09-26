// See https://aka.ms/new-console-template for more information
using System.Text;
for (int i = 0; i < 1000; i++)
{
    Console.WriteLine(Base26Converter.ConvertToBase26FromInt64(i)); 
}
public class Base26Converter
{

    internal static string ConvertToBase26FromInt64(Int64 input)
    {
        int baseNum = 26;
        int i = 1;
        while (Math.Pow(baseNum, i) <= input)
        {
            i++;
        }
        int[] result = new int[i];
        while (i > 1)
        {
            i--;
            result[i] = (int)(input / Math.Pow(baseNum, i));
            input -= result[i] * (long)Math.Pow(baseNum, i);
        }
        result[0] = (int)input;

        StringBuilder sb = new StringBuilder();
        foreach (var item in result.Reverse())
        {
            sb.Append((char)(item + 97));
        }
        return sb.ToString();

    }


}