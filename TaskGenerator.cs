using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticTaskGenerator;

public abstract class TaskGenerator :Calculator
{

    protected double Difficulty;
    protected int NumbersCount;
    protected int[] RandomNumbers;

    protected abstract object CorrectAnswer { get; }

    public bool GenerateTask()
    {
        CreateTask();
        PrintTask();
        if (ProcessInput(GetInput()))
        {
            PrintCorrectMessage();
            return true;
        }
        else
        {
            PrintIncorrectMessage();
            return false;
        }

    }
    protected abstract void CreateTask();
    

    private void PrintTask()
    {
        Console.Write(ToString());
    }

    private static string GetInput()
    {
        return Console.ReadLine();
    }

    protected virtual bool ProcessInput(string input)
    {
        if (!int.TryParse(input, out int userAnswer))
        {
            throw new ArgumentException("Invalid input");
        }
        return (Convert.ToInt32(CorrectAnswer) == userAnswer);

    }

    protected virtual void PrintIncorrectMessage()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{ToString()} {CorrectAnswer}");
        Console.ResetColor();
    }

    private static void PrintCorrectMessage()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Correct!");
        Console.ResetColor();
    }

    

}
