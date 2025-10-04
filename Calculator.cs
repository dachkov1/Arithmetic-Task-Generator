using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticTaskGenerator;

public abstract class Calculator
{
    protected int Add(params int[] numbers) => numbers.Sum();
    protected int Subtract(params int[] numbers)
    {
        int result = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            result -= numbers[i];
        }
        return result;
    }
    protected int Multiply(params int[] numbers) => numbers.Aggregate(1, (acc, n) => acc * n);
    protected (int result, int remainder) Divide(int a, int b)
    {

        int result = a / b;
        int remainder = a % b;              
        return (result, remainder);
    }
    
}
