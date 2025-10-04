using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticTaskGenerator;

public class TaskGeneratorMultiplication :TaskGenerator
{

    private const char _operationSymbol = 'x';
   
    protected override object CorrectAnswer
    {
        get
        {
            return Multiply(RandomNumbers);
        }
    }

    public TaskGeneratorMultiplication(double difficulty,int numbersCount)
    {
        Difficulty = difficulty ;
        NumbersCount = numbersCount;
    }
    protected override void CreateTask()
    {
        Randomizer randomizer = new Randomizer(Difficulty);
        RandomNumbers = randomizer.GetRandomNumbers().Take(NumbersCount).ToArray();
    }
    public override string ToString()
    {
        if (RandomNumbers == null || RandomNumbers.Length == 0)
            return "Invalid task";

        // Join all numbers with the operation symbol between them
        string expression = string.Join($" {_operationSymbol} ", RandomNumbers);

        // Add the equals sign
        return $"{expression} = ";
    }

   
}
