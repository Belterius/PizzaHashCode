using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoHashCode
{
    public class Cache
    {
        int cacheID { get; set; }
        int capacity { get; set; }
        List<Video> cachedVideos;

        public Cache(int cacheID)
        {
            this.cacheID = cacheID;
            cachedVideos = new List<Video>();
        }
        public Cache(int cacheID, int capacity)
        {
            this.cacheID = cacheID;
            this.capacity = capacity;
        }
    }
}
