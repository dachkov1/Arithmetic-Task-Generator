using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;


namespace ArithmeticTaskGenerator;

public class StartUp
{
    static void Main()
    {
        
        try
        {
            (int operation, double difficulty,int numbersCount) = UIConsole.GetUserInput();

            TaskGenerator myTask = operation switch
            {
                1 => new TaskGeneratorAddition(difficulty,numbersCount),
                2 => new TaskGeneratorSubtraction(difficulty,numbersCount),
                3 => new TaskGeneratorMultiplication(difficulty,numbersCount),
                4 => new TaskGeneratorDivision(difficulty),
                _ => throw new ArgumentException("Invalid operation")
            };
            int correctCount = 0;
            for (int i = 0; i < 10; i++)
            {
                if(myTask.GenerateTask())
                    correctCount++;
            }
            double percentage = (double)correctCount / 10 * 100;
            Console.WriteLine($"{percentage}%");
            Console.ReadLine();
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);         
        }
        Console.ReadLine();
    }

}
