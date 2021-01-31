using infrastructure.Models;

namespace infrastructure.Services
{
    public interface ILotteryNumberGenerator
    {
        FinalLotteryResult GetFinalResult(PartialLotteryResult partialResult);
        PartialLotteryResult GetPartialLotteryResult(PartialLotteryResult partialResult);
    }
}