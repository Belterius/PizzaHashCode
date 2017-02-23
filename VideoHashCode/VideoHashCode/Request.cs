using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoHashCode
{
    public class Request
    {
        public int videoID { get; }
        public Video video { set; get; }
        public Client client { set; get; }
        public int score { get; set; }
        public int numberOfRequest { set; get; }

        public Request(int videoID)
        {
            this.videoID = videoID;
        }
        public Request(int videoID, Video myVideo, Client myClient, int myNumberOfRequest)
        {
            this.videoID = videoID;
            video = myVideo;
            client = myClient;
            numberOfRequest = myNumberOfRequest;
        }

        public int calculateScore()
        {
            int myScore = 0;
            return myScore;
        }
    }
}
