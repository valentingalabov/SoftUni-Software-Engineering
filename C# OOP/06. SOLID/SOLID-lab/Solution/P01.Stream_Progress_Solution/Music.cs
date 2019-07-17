using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Stream_Progress_Solution
{
    public class Music : IResult
    {
        public int Length { get; set; }

        public int BytesSent { get; set; }

        public string Artist { get; set; }

        public string Album { get; set; }
    }
}
