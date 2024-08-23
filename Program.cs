
using System.Text;

namespace Infinit_Int_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExdInt try1= new ExdInt("100000000000000");
            ExdInt try2 = new ExdInt("1000");
            ExdInt result = try1 + try2; // output == 100000  wtf
            for (int i= 0; i < result.ArrayOfuInt.Length; i++)
            {
                Console.Write(result.ArrayOfuInt[i]);
            }
            Console.WriteLine("");
            Console.WriteLine(result.isStringOfIntNegative);
            Console.WriteLine(result.isThisNumberUsable);
        }
    }
}
public class ExdInt : IComparable<ExdInt>, IEquatable<ExdInt>
{
    #region Constructors
    public ExdInt(long intOfInput)
    {
        stringOfInt = intOfInput.ToString();
        isStringOfIntNegative = IsNegative(stringOfInt);
        ArrayOfuInt = CreateAUExdInt(stringOfInt);
    }
    public ExdInt(string stringOfInput)
    {
        stringOfInt = stringOfInput;
        isStringOfIntNegative = IsNegative(stringOfInt);
        ArrayOfuInt = CreateAUExdInt(stringOfInt);
    }
    protected ExdInt(IList<uIntWithPadding> uIntWithPadding, bool IsIntNegative = false)
    {
        ArrayOfuInt = uIntWithPadding.ToArray();
        stringOfInt = uIntWithPadding.ToString();
        isStringOfIntNegative = IsIntNegative;

    }
    protected ExdInt(ExdInt exdInt)
    {
        ArrayOfuInt = exdInt.ArrayOfuInt;
        stringOfInt = exdInt.ToString();
        isStringOfIntNegative = exdInt.isStringOfIntNegative;
    }

    protected ExdInt(ExdInt exdInt, bool IsIntNegative) 
    { 
        ArrayOfuInt = exdInt.ArrayOfuInt;
        stringOfInt = exdInt.ToString(); 
        isStringOfIntNegative = IsIntNegative;}


    public static implicit operator ExdInt(long intOfInput) { return new ExdInt(intOfInput); }
    public static implicit operator ExdInt(int intOfInput) { return new ExdInt(intOfInput); }
    public static implicit operator ExdInt(string stringOfInput) { return new ExdInt(stringOfInput); }

    #endregion

    #region Properties
    public bool isStringOfIntNegative;
    public uIntWithPadding[] ArrayOfuInt;
    public bool isThisNumberUsable = true;
    private string stringOfInt;
    #endregion

    #region Methods
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        if (isStringOfIntNegative) { sb.Append("-"); }
        for (int i = 0; i < ArrayOfuInt.Length; i++)
        {
            sb.Append(ArrayOfuInt[i].ToString());
        }
        return sb.ToString();
    }
    
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
    
    private uIntWithPadding[] CreateAUExdInt(string stringOfInt)
    {
        int xSqur10 = 0;
        if (!AreDigitsOnly(stringOfInt))
        {
            isThisNumberUsable = false;
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
                if (length == 0) { return ConvertToUIntResult = new uIntWithPadding(0, 0); }
                length--;
            }
        } while (true);
    }

    public int CompareTo(ExdInt? other)
    {
        if(other == null) { return 1; }
        if (isStringOfIntNegative && other.isStringOfIntNegative)
        {
            if (ArrayOfuInt.Length > other.ArrayOfuInt.Length) { return -1; }
            else if (ArrayOfuInt.Length < other.ArrayOfuInt.Length) { return 1; }
            else
            {

                if (ArrayOfuInt[0].Value > other.ArrayOfuInt[0].Value) { return -1; }
                else if (ArrayOfuInt[0].Value < other.ArrayOfuInt[0].Value) { return 1; }

                return 0;
            }
        }
        else if (!isStringOfIntNegative && !other.isStringOfIntNegative)
        {
            if (ArrayOfuInt.Length > other.ArrayOfuInt.Length) { return 1; }
            else if (ArrayOfuInt.Length < other.ArrayOfuInt.Length) { return -1; }
            else
            {
                if (ArrayOfuInt[0].Value > other.ArrayOfuInt[0].Value) { return 1; }
                else if (ArrayOfuInt[0].Value < other.ArrayOfuInt[0].Value)
                { return -1; }
                else { return 0; }
            }
        }
        else if (isStringOfIntNegative && !other.isStringOfIntNegative)
        {
            if (ArrayOfuInt[ArrayOfuInt.Length - 1].Value == other.ArrayOfuInt[other.ArrayOfuInt.Length - 1].Value)
            {
                return 0;
            }
            return -1;
        }
        else 
        {
            if (ArrayOfuInt[ArrayOfuInt.Length - 1].Value == other.ArrayOfuInt[other.ArrayOfuInt.Length - 1].Value)
            {
                return 0;
            }
            return 1; 
        } 
    }

    public bool Equals(ExdInt? other)
    {
        return CompareTo(other) == 0;
    }


    #endregion

    #region Operators
    public static ExdInt operator +(ExdInt a, ExdInt b)
    {
        List<uIntWithPadding> result = new List<uIntWithPadding>();
        long carry = 0;
        int max = Math.Max(a.ArrayOfuInt.Length, b.ArrayOfuInt.Length);
        Array.Reverse(a.ArrayOfuInt);
        Array.Reverse(b.ArrayOfuInt);
        for (int i = 0; i < max; i++)
        {
            long sum = carry;
            if (i < a.ArrayOfuInt.Length)
                sum += (uint)a.ArrayOfuInt[i].Value;
            if (i < b.ArrayOfuInt.Length)
                sum += (uint)b.ArrayOfuInt[i].Value;
            carry = sum / 1000000000;
            Console.WriteLine($"Sum: {sum} Carry: {carry}");
            result.Add(new uIntWithPadding((uint)(sum % 1000000000), (uint)Math.Log10(sum) + 1));
        }
        if (carry > 0)
        {
            result.Add(new uIntWithPadding((uint)carry, ((uint)Math.Log10(carry) + 1)));
        }
        result.Reverse();
        return new ExdInt(result);
    }
    public static ExdInt operator -(ExdInt a, ExdInt b)
    {
        if (a.isStringOfIntNegative != b.isStringOfIntNegative)
        {
            if (a >= b)
            {
                ExdInt exdInt = new ExdInt(a + b);
                return new ExdInt(exdInt);
            }
            else
            {
                ExdInt exdInt = new ExdInt(a + b);
                return new ExdInt(exdInt, true);
            }
        }
        else
        {

        }
        return new ExdInt(0);
    }

    public static bool operator >(ExdInt operand1, ExdInt operand2)
    {
        return operand1.CompareTo(operand2) > 0;
    }

    public static bool operator <(ExdInt operand1, ExdInt operand2)
    {
        return operand1.CompareTo(operand2) < 0;
    }

    public static bool operator >=(ExdInt operand1, ExdInt operand2)
    {
        return operand1.CompareTo(operand2) >= 0;
    }

    public static bool operator <=(ExdInt operand1, ExdInt operand2)
    {
        return operand1.CompareTo(operand2) <= 0;
    }
}
#endregion
public struct uIntWithPadding
{
    public uint Value;
    private uint TotalDigits;

    public uIntWithPadding(uint value, uint totalDigits)
    {
        Value = value;
        TotalDigits = totalDigits;
        Console.WriteLine($"Value: {Value} TotalDigits: {TotalDigits}");
    }
    public override string ToString()
    {
        return Value.ToString($"D{TotalDigits}");
    }
}


