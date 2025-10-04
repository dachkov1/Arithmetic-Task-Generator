using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticTaskGenerator;

public class Randomizer
{
    private HashSet<int> _randoms;

    public IEnumerable<int> Randoms => _randoms;
   // public int Count { get; set; }
    public int RangeMin { get; set; }
    public int RangeMax { get; set; }

    public Randomizer(double difficulty)
    {
        (RangeMin, RangeMax) = difficulty switch
        {
            <= 1.0 => (1, 11),
            <= 2.0 => (2, 21),
            <= 3.0 => (10, 51),
            <= 4.0 => (1, 11),
            <= 5.0 => (2, 21),
            <= 6.0 => (10, 51),             
            _ => ( 150, 3000)
        };
        Random random = new();
        _randoms = [];
        for(int i = 0; i < 10;i++)
            _randoms.Add(random.Next(RangeMin, RangeMax));
    }

    public int[] GetRandomNumbers()
    {
         return _randoms.ToArray();
    }

}
