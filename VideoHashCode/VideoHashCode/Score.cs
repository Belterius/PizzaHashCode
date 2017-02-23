using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoHashCode
{
    public class Score
    {
        public double value { get; set; }
        public Cache cache { get; set; }
        public Request request { get; set; }

        public Score(Cache cache, double value, Request req)
        {
            this.value = value;
            this.cache = cache;
            this.request = req;
        }
    }
}
