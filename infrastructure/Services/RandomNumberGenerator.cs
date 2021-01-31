using System;
using System.Collections.Generic;
using System.Linq;

namespace infrastructure.Services
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        public RandomNumberGenerator(IRndWrapper rndWrapper)
        {
            _rndWrapper = rndWrapper;
        }

        private readonly IRndWrapper _rndWrapper;

        // NB this uses a simple algorithm to select the random value between the min and max (inclusive), check if the number is excluded
        // and if so try again until we have an acceptable number. For a simple implementation such as a lottery where we are choosing 6 
        // (or possibly 7) numbers out of 49 it works ok, however if we start selecting a higher proportion of numbers out of the available pool 
        // we will start to run into problems with repeated attempts to select an acceptable number, culminating with an infinite loop once all 
        // acceptable numbers have been exhausted.
        // An alternative, if we had to support for example the efficient ranking of an entire set of numbers, would have been to "map" the random 
        // seed value to a range of numbers from 0 to limit - 1, then subtract the number of excluded numbers, and then "remap" back to the appropriate 
        // value: eg for a range of 1 to 10, where 1 to 5 were already taken, a seed value of 0 would give 6 (the first available number), 1 would give 
        // 7 ... 4 would give 10; 4 being the highest possible seed value in this case
        public int GenerateNextNumber(int lowerLimit, int upperLimit, List<int> excludedNumbers)
        {
            int seedVal = upperLimit - lowerLimit;

            excludedNumbers = excludedNumbers
                .Distinct()
                .Where(x => x >= lowerLimit && x <= upperLimit)
                .ToList();

            int randonlySelectedValue = 0;
            do
            {
                randonlySelectedValue = (int)(_rndWrapper.GetNextRnd() * seedVal) + 1;
            } while (excludedNumbers.Contains(randonlySelectedValue));

            return randonlySelectedValue;
        }
    }
}
