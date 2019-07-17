using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Stream_Progress_Solution
{
    public class StreamProgressInfo
    {
        private readonly IResult result;

        
        public StreamProgressInfo(IResult result)
        {
            this.result = result;
        }

        public int CalculateCurrentPercent()
        {
            return (this.result.BytesSent * 100) / this.result.Length;
        }
    }
}
