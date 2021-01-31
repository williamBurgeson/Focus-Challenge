using infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace infrastructure.Services
{
    // NB we're differentiating between the partial result, i.e. representing the state of the system as the 
    // individual balls drop out of Guinevere into the little tray underneath, and the final result: this 
    // should give a better user experience at the front end
    public class LotteryNumberGenerator : ILotteryNumberGenerator
    {
        public LotteryNumberGenerator(IRandomNumberGenerator numberGenerator)
        {
            _numberGenerator = numberGenerator;
        }

        private readonly IRandomNumberGenerator _numberGenerator;

        public PartialLotteryResult GetPartialLotteryResult(PartialLotteryResult partialResult)
        {
            int populatedBalls = 0;

            var valuesToExclude = new List<int>();

            if (partialResult.Ball1.HasValue) { populatedBalls++; valuesToExclude.Add(partialResult.Ball1.Value); }
            if (partialResult.Ball2.HasValue) { populatedBalls++; valuesToExclude.Add(partialResult.Ball2.Value); }
            if (partialResult.Ball3.HasValue) { populatedBalls++; valuesToExclude.Add(partialResult.Ball3.Value); }
            if (partialResult.Ball4.HasValue) { populatedBalls++; valuesToExclude.Add(partialResult.Ball4.Value); }
            if (partialResult.Ball5.HasValue) { populatedBalls++; valuesToExclude.Add(partialResult.Ball5.Value); }
            if (partialResult.Ball6.HasValue) { populatedBalls++; valuesToExclude.Add(partialResult.Ball6.Value); }

            if (populatedBalls > 5)
            {
                partialResult.IsFull = true;
                return partialResult;
            }

            int nextBall = _numberGenerator.GenerateNextNumber(1, 49, valuesToExclude);

            switch (populatedBalls)
            {
                case 0: partialResult.Ball1 = nextBall; return partialResult;
                case 1: partialResult.Ball2 = nextBall; return partialResult;
                case 2: partialResult.Ball3 = nextBall; return partialResult;
                case 3: partialResult.Ball4 = nextBall; return partialResult;
                case 4: partialResult.Ball5 = nextBall; return partialResult;
                case 5: partialResult.Ball6 = nextBall; 
                    partialResult.IsFull = true; return partialResult;
                default: return partialResult;
            }
        }

        public FinalLotteryResult GetFinalResult(PartialLotteryResult partialResult)
        {
            if (!(partialResult.Ball1.HasValue &&
                partialResult.Ball2.HasValue &&
                partialResult.Ball3.HasValue &&
                partialResult.Ball4.HasValue &&
                partialResult.Ball5.HasValue &&
                partialResult.Ball6.HasValue))
            {
                return null;
            }

            var balls = new int[]
            {
                partialResult.Ball1.Value,
                partialResult.Ball2.Value,
                partialResult.Ball3.Value,
                partialResult.Ball4.Value,
                partialResult.Ball5.Value,
                partialResult.Ball6.Value
            }.OrderBy(x => x).ToList();

            return new FinalLotteryResult
            {
                Ball1 = balls[0],
                Ball2 = balls[1],
                Ball3 = balls[2],
                Ball4 = balls[3],
                Ball5 = balls[4],
                Ball6 = balls[5]
            };
        }
    }
}
