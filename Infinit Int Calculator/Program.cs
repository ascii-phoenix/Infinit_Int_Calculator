using static System.Net.Mime.MediaTypeNames;

namespace Infinit_Int_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            uExdInt try1 = new uExdInt(Console.ReadLine());
            for (int i= 0; i < try1.ArrayOfuInt.Length; i++)
            {
                Console.Write(try1.ArrayOfuInt[i]);
            }
            Console.WriteLine("");
            Console.WriteLine(try1.isStringOfIntNegative);
            Console.WriteLine(try1.isThisNumberUsebel);
        }
    }
}
public class uExdInt
{
    public uExdInt(string stringOfInput)
    {
        stringOfInt = stringOfInput;
        isStringOfIntNegative = IsNegative(stringOfInt);
        ArrayOfuInt = CreateAUExdInt(stringOfInt);
    }
    public bool isStringOfIntNegative;
    public uIntWithPadding[] ArrayOfuInt;
    public bool isThisNumberUsebel = true;
    private string stringOfInt;
    private bool AreDigitsOnly(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return false;
        foreach (char character in text)
        {
            if (character < '0' || character > '9')
                return false;
        }
        return true;
    }
    private bool IsNegative(string text)
    {
        if (text[0] == '-') 
        {
            stringOfInt= stringOfInt.Replace("-", "");
            return true;
        }

        return false;
    }
    public static uExdInt operator +(uExdInt a, uExdInt b)
    {
        List<uIntWithPadding> result = new List<uIntWithPadding>();
        ulong carry = 0;
        int max = Math.Max(a.ArrayOfuInt.Length, b.ArrayOfuInt.Length);
        for (int i = 0; i < max; i++)
        {
            ulong sum = carry;
            if (i < a.ArrayOfuInt.Length)
                sum += (uint)a.ArrayOfuInt[i].Value;
            if (i < b.ArrayOfuInt.Length)
                sum += (uint)b.ArrayOfuInt[i].Value;
            carry = sum / 1000000000;
            result.Add(new uIntWithPadding((uint)(sum % 1000000000), 9));
        }
        return new uExdInt(result);
    }
    private uIntWithPadding[] CreateAUExdInt(string stringOfInt)
    {
        int xSqur10 = 0;
        if (!AreDigitsOnly(stringOfInt))
        {
            isThisNumberUsebel = false;
            return null;
        }   
        char[] charOfInt = stringOfInt.ToCharArray();
        uIntWithPadding[] uExdInt;
        if (charOfInt.Length % 9 == 0) { uExdInt = new uIntWithPadding[(charOfInt.Length / 9)]; }
        else { uExdInt = new uIntWithPadding[(charOfInt.Length / 9) + 1]; }
        uExdInt[0] = ConvertToUInt(charOfInt, xSqur10, (charOfInt.Length % 9));
        xSqur10 += (charOfInt.Length % 9);
        for (int i = 1; i < (uExdInt.Length); i++)
        {
                
                uExdInt[i]  = ConvertToUInt(charOfInt, xSqur10, 9);
                xSqur10 += 9;
        }
        return uExdInt;
    }
    private static uIntWithPadding ConvertToUInt(char[] charArray, int startIndex, int length) 
    {
        uint result;
        uIntWithPadding ConvertToUIntResult;
        do
        {
            string str = new string(charArray, startIndex, length);
            if (uint.TryParse(str, out result)) 
            {
                ConvertToUIntResult = new uIntWithPadding(result, (uint)length);
                return ConvertToUIntResult;
            }
            else
            {
                   length--;
                if (length == 0) { return ConvertToUIntResult = new uIntWithPadding(0, (uint)length); }
            }
        } while (true);
    }
}
public struct uIntWithPadding
{
    public uint Value;
    private uint TotalDigits;

    public uIntWithPadding(uint value, uint totalDigits)
    {
        Value = value;
        TotalDigits = totalDigits;
    }
    public override string ToString()
    {
        return Value.ToString($"D{TotalDigits}");
    }
}