using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoHashCode
{
    public class Cache
    {
        public int cacheID { get; set; }
        public int capacity { get; set; }

        public int CurrentCapacity
        {
            get
            {
                int total = 0;
                foreach (Video vid in cachedVideos)
                {
                    total += vid.size;
                }
                return total;
            }
            
        }
        
        public List<Video> cachedVideos;

        public Cache(int cacheID)
        {
            this.cacheID = cacheID;
            cachedVideos = new List<Video>();
        }
        public Cache(int cacheID, int capacity)
        {
            this.cacheID = cacheID;
            this.capacity = capacity;
            cachedVideos = new List<Video>();
        }

        public bool AddVideo(Request req)
        {
            if(CurrentCapacity + req.video.size <= capacity && !cachedVideos.Contains(req.video) && !videoInOtherCache(req))
            {

                cachedVideos.Add(req.video);
                return true;
            }
                return false;
        }

        public bool videoInOtherCache(Request req)
        {
            foreach (var linkedcache in req.client.linkedCache)
            {
               if(linkedcache.Key.cachedVideos.Contains(req.video))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
