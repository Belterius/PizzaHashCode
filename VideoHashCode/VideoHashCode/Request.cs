using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoHashCode
{
    public class Request
    {
        public int requestID { get; }
        public Video video { set; get; }
        public Client client { set; get; }
        public List<Score> listScore;
        public int numberOfRequest { set; get; }

        public Request(int videoID)
        {
            this.requestID = videoID;
            listScore = new List<Score>();
        }
        public Request(int videoID, Video myVideo, Client myClient, int myNumberOfRequest)
        {
            this.requestID = videoID;
            video = myVideo;
            client = myClient;
            listScore = new List<Score>();
            numberOfRequest = myNumberOfRequest;
        }

        public void calculateScore()
        {
            foreach (KeyValuePair<Cache, int> entry in client.linkedCache)
            {
                // do something with entry.Value or entry.Key
                if(entry.Key.capacity == 0)
                {
                    Debug.WriteLine("ZEROOOOO capa");
                }
                if (video.size == 0)
                {
                    Debug.WriteLine("ZEROOOOO size");
                }
                listScore.Add(new Score(entry.Key, ((client.latenceDataCenter - entry.Value) * numberOfRequest) / ((double)((double)video.size / (double)entry.Key.capacity)), this));
            }

        }
    }
}
