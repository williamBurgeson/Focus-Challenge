using System.Collections.Generic;

namespace infrastructure.Services
{
    public interface IRandomNumberGenerator
    {
        int GenerateNextNumber(int lowerLimit, int upperLimit, List<int> excludedNumbers);
    }
}