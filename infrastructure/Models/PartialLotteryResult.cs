using System;
using System.Collections.Generic;
using System.Text;

namespace infrastructure.Models
{
    public class PartialLotteryResult
    {
        public int? Ball1 { get; set; }
        public int? Ball2 { get; set; }
        public int? Ball3 { get; set; }
        public int? Ball4 { get; set; }
        public int? Ball5 { get; set; }
        public int? Ball6 { get; set; }
        public bool IsFull { get; set; }
    }
}
