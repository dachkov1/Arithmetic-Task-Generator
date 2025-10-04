using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticTaskGenerator;

public class TaskGeneratorSubtraction : TaskGenerator
{
    private const char _operationSymbol = '-';

    protected override object CorrectAnswer => Subtract(RandomNumbers);

    public TaskGeneratorSubtraction(double difficulty,int numbersCount)
    {
        Difficulty = difficulty;
        NumbersCount = numbersCount;

    }

    protected override void CreateTask()
    {
        do
        {
            Randomizer randomizer = new Randomizer(Difficulty);
            RandomNumbers = randomizer.GetRandomNumbers().Take(NumbersCount).OrderByDescending(n => n).ToArray();
        } while ((int)CorrectAnswer < 0);
    }

    public override string ToString()
    {
        if (RandomNumbers == null || RandomNumbers.Length == 0)
            return "Invalid task";

        string expression = string.Join($" {_operationSymbol} ", RandomNumbers);

        return $"{expression} = ";
    }

    
}
