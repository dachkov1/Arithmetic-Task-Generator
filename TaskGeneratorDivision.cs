using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticTaskGenerator;

public class TaskGeneratorDivision : TaskGenerator
{

    private const char _operationSymbol = ':';

    private int _firstNumber;
    private int _secondNumber;

    protected override object CorrectAnswer
    {
        get
        {
            return Divide(_firstNumber, _secondNumber);
        }
    }



    public TaskGeneratorDivision(double difficulty)
    {
        Difficulty = difficulty switch
        {
            <= 1.0 => 1.0,
            <= 2.0 => 2.0,
            <= 3.0 => 3.0,
            _ => 3.0

        };
        NumbersCount = 2;

    }
    protected override void CreateTask()
    {
        Randomizer randomizer = new Randomizer(Difficulty);
        RandomNumbers = randomizer.GetRandomNumbers()
            .Take(NumbersCount)
            .OrderByDescending(n => n)
            .ToArray();
        (_firstNumber, _secondNumber) = (RandomNumbers[0], RandomNumbers[1]);
    }
    protected override bool ProcessInput(string input)
    {
        (int correctResult, int correctRemainder) = ((int, int))CorrectAnswer;
        if (int.TryParse(input, out int singleNumber))
        {
            // For division, a single number is only correct if remainder is 0
            return singleNumber == correctResult && correctRemainder == 0;
        }

        int[] numbers = input.Split("\\").Select(int.Parse).ToArray();
        (int inputResult, int inputRemainder) = (numbers[0], numbers[1]);
        return(inputResult == correctResult && inputRemainder == correctRemainder);
    }

    protected override void PrintIncorrectMessage()
    {
        (int result,int remainder) = ((int,int))CorrectAnswer;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{ToString()} {result}\\{remainder}");
        Console.ResetColor();
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