
using System.Text;

namespace Infinit_Int_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            ExdInt try1= new ExdInt("78947894776556576567432457899876554322345678990984");
            ExdInt try2 = new ExdInt("-13289904904944447329887432000");
            //-010492101402599735957892490764618768939099731814395465278650124480062913088000 Code output
            //-1049210014025997359578924907646187689390997318143954065278650124480062913088000 https://www.calculator.net/big-number-calculator.html output
            //Not the same output with the same input. Why?
            ExdInt result = try1 - try2; 
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
        isStringOfIntNegative = IsIntNegative;
    }

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
        if (!AreDigitsOnly(stringOfInt))
        {
            isThisNumberUsable = false;
            return null;
        }
        char[] charOfInt = stringOfInt.ToCharArray();
        int length = charOfInt.Length;
        int numChunks = (length % 9 == 0) ? (length / 9) : (length / 9) + 1;
        uIntWithPadding[] uExdInt = new uIntWithPadding[numChunks];
        int start = 0;
        int chunkLength = length % 9 == 0 ? 9 : length % 9;
        for (int i = 0; i < numChunks; i++)
        {
            uExdInt[i] = ConvertToUInt(charOfInt, start, chunkLength);
            start += chunkLength;
            chunkLength = 9; 
        }
        return uExdInt;
    }

    private static uIntWithPadding ConvertToUInt(char[] charArray, int startIndex, int length)
    {
        uint result;
        uIntWithPadding ConvertToUIntResult;

        while (length > 0)
        {
            try
            {
                if (startIndex + length > charArray.Length)
                    length = charArray.Length - startIndex;
                string str = new string(charArray, startIndex, length);
                if (uint.TryParse(str, out result))
                {
                    ConvertToUIntResult = new uIntWithPadding(result, (uint)str.Length);
                    return ConvertToUIntResult;
                }
                else
                {
                    length--;
                }
            }
            catch
            {
                return new uIntWithPadding(0, 0);
            }
        }

        return new uIntWithPadding(0, 0);
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
        if (a.isStringOfIntNegative != b.isStringOfIntNegative)
        {
            if (a > b)
            {
                b.isStringOfIntNegative = false;
                return new ExdInt(a - b, false);
            }
            else
            {
                a.isStringOfIntNegative = false;
                return new ExdInt(b - a, true);
            }
        }
        List<uIntWithPadding> result = new List<uIntWithPadding>();
        long carry = 0;
        int max = Math.Max(a.ArrayOfuInt.Length, b.ArrayOfuInt.Length);
        for (int i = 0; i < max; i++)
        {
            long sum = carry;
            if (i < a.ArrayOfuInt.Length)
                sum += a.ArrayOfuInt[a.ArrayOfuInt.Length - 1 - i].Value; 
            if (i < b.ArrayOfuInt.Length)
                sum += b.ArrayOfuInt[b.ArrayOfuInt.Length - 1 - i].Value;
            carry = sum / 1000000000;
            uint newValue = (uint)(sum % 1000000000);
            uint totalDigits = (i == max - 1) ? (uint)newValue.ToString().Length : 9;
            result.Add(new uIntWithPadding(newValue, totalDigits));
        }
        if (carry > 0)
        {
            result.Add(new uIntWithPadding((uint)carry, (uint)carry.ToString().Length));
        }
        result.Reverse();
        return new ExdInt(result, a.isStringOfIntNegative);
    }

    public static ExdInt operator -(ExdInt a, ExdInt b)
    {
        if (a.isStringOfIntNegative != b.isStringOfIntNegative)
        {
            if (a > b) 
            {
                b.isStringOfIntNegative = false;
                return new ExdInt(a + b);
            }
            else
            {
                b.isStringOfIntNegative = true;
                return new ExdInt(b + a);
            }
        }
        bool isResultNegative = false;
        if (a < b)
        {
            isResultNegative = true;
            var temp = a;
            a = b;
            b = temp;
        }
        List<uIntWithPadding> result = new List<uIntWithPadding>();
        long borrow = 0;
        int max = Math.Max(a.ArrayOfuInt.Length, b.ArrayOfuInt.Length);

        for (int i = 0; i < max; i++)
        {
            long diff = borrow;
            if (i < a.ArrayOfuInt.Length)
            {
                diff += a.ArrayOfuInt[a.ArrayOfuInt.Length - 1 - i].Value;
            }
            if (i < b.ArrayOfuInt.Length)
            {
                diff -= b.ArrayOfuInt[b.ArrayOfuInt.Length - 1 - i].Value;
            }
            if (diff < 0)
            {
                int borrowIndex = a.ArrayOfuInt.Length - 1 - i - 1;
                while (borrowIndex >= 0 && a.ArrayOfuInt[borrowIndex].Value == 0)
                {
                    a.ArrayOfuInt[borrowIndex].Value = 999999999;
                    borrowIndex--;
                }
                if (borrowIndex >= 0)
                {
                    a.ArrayOfuInt[borrowIndex].Value--;
                }
                diff += 1000000000;
            }

            uint newValue = (uint)(diff % 1000000000);
            uint totalDigits = (i == max - 1) ? (uint)newValue.ToString().Length : 9;
            result.Add(new uIntWithPadding(newValue, totalDigits));
        }

        while (result.Count > 1 && result[0].Value == 0)
        {
            result.RemoveAt(0);
        }
        result.Reverse();
        return new ExdInt(result, isResultNegative);
    }
   /* public static ExdInt operator *(ExdInt a, ExdInt b)
    {
        bool isResultNegative = a.isStringOfIntNegative != b.isStringOfIntNegative;
        int resultLength = a.ArrayOfuInt.Length + b.ArrayOfuInt.Length;
        List<uIntWithPadding> result = new List<uIntWithPadding>(new uIntWithPadding[resultLength]);
        for (int i = 0; i < resultLength; i++)
        {
            result[i] = new uIntWithPadding(0, 0);
        }
        for (int i = 0; i < a.ArrayOfuInt.Length; i++)
        {
            for (int j = 0; j < b.ArrayOfuInt.Length; j++)
            {
                long product = (long)a.ArrayOfuInt[a.ArrayOfuInt.Length - 1 - i].Value * (long)b.ArrayOfuInt[b.ArrayOfuInt.Length - 1 - j].Value;
                int position = i + j;
                long sum = product + result[position].Value;
                result[position] = new uIntWithPadding((uint)(sum % 1000000000), (uint)(sum % 1000000000).ToString().Length);
                int carryPosition = position + 1;
                while (carryPosition < result.Count && sum >= 1000000000)
                {
                    sum /= 1000000000;
                    result[carryPosition].Value += (uint)sum;
                    carryPosition++;
                    sum = result[carryPosition].Value;
                }
            }
        }
        while (result.Count > 1 && result[0].Value == 0)
        {
            result.RemoveAt(0);
        }
        result.Reverse();
        return new ExdInt(result, isResultNegative);
    }
   */


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
    #endregion
}


#region uIntWithPadding
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
        return Value.ToString(TotalDigits == 9 ? "D9" : $"D{TotalDigits}");
    }
}
#endregion

