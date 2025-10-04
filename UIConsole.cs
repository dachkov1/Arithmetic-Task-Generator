using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticTaskGenerator;

public static class UIConsole
{
    public static void WelcomeMessage()
    {
        Console.WriteLine("Select Exercise:" +
                "\n1. (+) Addition" +
                "\n2. (-) Subtraction" +
                "\n3. (x) Multiplication" +
                "\n4. (:) Division");
    }
    public static void SelectDifficultyMessage()
    {
        Console.WriteLine("Select Dificulty:");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("1.Easy");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("2.Moderate");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("3.Hard");
        Console.ResetColor();
    }
    public static void SelectNumbersCountMessage()
    {
        Console.WriteLine("Select Operands Count:(2-5)");
    }
    public static int InputOperation()
    {
        int operation;
        if (!int.TryParse(Console.ReadLine(), out operation))
        {
            Console.WriteLine("Invalid input");
            WelcomeMessage();
            operation = InputOperation();
        }
        if (operation > 4)
        {
            Console.WriteLine("Must be number between 1 and 4");
            WelcomeMessage();
            operation = InputOperation();
        }
        return operation;
    }

    public static double InputDifficulty()
    {
        double difficulty;
        if (!double.TryParse(Console.ReadLine(), out difficulty))
        {
            Console.WriteLine("Invalid input");
            SelectDifficultyMessage();
            difficulty = InputDifficulty();
        }
        return difficulty;

    }

    public static int InputNumbersCount()
    {
        int count;
        if (!int.TryParse(Console.ReadLine(), out count))
        {
            Console.WriteLine("Invalid input");
            SelectNumbersCountMessage();
            count = InputNumbersCount();
        }
        if (count < 2 || count > 5)
        {
            Console.WriteLine("Must be number between 2 and 5");
            SelectNumbersCountMessage();
            count = InputNumbersCount();
        }
        return count;
    }
    public static (int, double, int) GetUserInput()
    {
        WelcomeMessage();
        int operation = InputOperation();

        SelectDifficultyMessage();
        double difficulty = InputDifficulty();

        SelectNumbersCountMessage();
        int numbersCount = InputNumbersCount();

        return (operation, difficulty, numbersCount);
    }

}
