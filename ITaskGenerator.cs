using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticTaskGenerator;

public interface ITaskGenerator
{
    object CorrectAnswer { get; }
    public void GenerateTask();


}
