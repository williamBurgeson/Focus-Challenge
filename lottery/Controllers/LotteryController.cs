using infrastructure.Models;
using infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lottery.Controllers
{
    [ApiController]
    [Route("api/lottery")]

    public class LotteryController
    {
        public LotteryController(ILotteryNumberGenerator lotteryNumberGenerator)
        {
            _lotteryNumberGenerator = lotteryNumberGenerator;
        }

        private readonly ILotteryNumberGenerator _lotteryNumberGenerator;

        [HttpPost, Route("partial-result")]
        public PartialLotteryResult GetPartialLotteryResult([FromBody] PartialLotteryResult partialResult) =>
            _lotteryNumberGenerator.GetPartialLotteryResult(partialResult);

        [HttpPost, Route("final-result")]
        public FinalLotteryResult GetFinalLotteryResult([FromBody] PartialLotteryResult partialResult) =>
            _lotteryNumberGenerator.GetFinalResult(partialResult);
    }
}
