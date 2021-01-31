using System;
using System.Collections.Generic;
using System.Text;

namespace infrastructure.Services
{
    // NB wrapping the generation of the rnd in a separate class will make it easier to put unit 
    // tests around the random number generator
    public class RndWrapper : IRndWrapper
    {
        public double GetNextRnd() => new Random().NextDouble();
    }
}
