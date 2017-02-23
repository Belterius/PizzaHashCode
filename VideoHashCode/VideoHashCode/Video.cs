using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoHashCode
{
    public class Video
    {
        public int size { set; get; }
        public int videoID { get; }

        public Video(int videoID, int videoSize)
        {
            this.videoID = videoID;
            size = videoSize;
        }
    }
}
