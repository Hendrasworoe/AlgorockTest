using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectNumberChecker : MonoBehaviour
{
    private List<int> BigestCommonDivisorOf(int input)
    {
        List<int> result = new List<int>();
        int upper_limit = input;

        for (int i = 1; i < upper_limit; i++)
        {
            if (input % i == 0)
            {
                int div = input / i;

                result.Add(i);
                if (div != i)
                {
                    result.Add(div);
                }

                upper_limit = div;
            }
        }

        result.Sort();

        return result;
    }

    private int SumListIntMember(List<int> inputList)
    {
        int result = 0;

        foreach (var item in inputList)
        {
            result += item;
        }

        return result;
    }

    public string PerfectNumberCheck(List<int> dataInput)
    {
        string result = "";
        foreach (var number in dataInput)
        {
            var BCD = BigestCommonDivisorOf(number);
            var sum_BCD = SumListIntMember(BCD);
            sum_BCD -= number;

            if (sum_BCD == number)
            {
                result += "Perfect\n";
            }
            else if (sum_BCD == number - 1 || sum_BCD == number + 1)
            {
                result += "Hampir\n";
            }
            else
            {
                result += "Bukan\n";
            }
        }
        return result.Remove(result.Length - 1, 1);
    }
}
