using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoHashCode
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader;
            string line;
            string[] inputParameter;

            int nVideos;
            int nEndpoints;
            int nRequestDescriptions;
            int nCaches;
            int sizeCaches;

            List<Cache> listCaches = new List<Cache>();
            List<Client> listClients = new List<Client>();
            List<Request> listRequests = new List<Request>();
            List<Video> listVideos = new List<Video>();

            // File to read
            string startupPath = Environment.CurrentDirectory;
            reader = new StreamReader(@"C:\Users\belterius\Source\Repos\PizzaHashCode\VideoHashCode\VideoHashCode\Examples\me_at_the_zoo.in");

            // First line : General Parameters
            line = reader.ReadLine();
            inputParameter = line.Split(' ');

            nVideos = Convert.ToInt32(inputParameter[0]);
            nEndpoints = Convert.ToInt32(inputParameter[1]);
            nRequestDescriptions = Convert.ToInt32(inputParameter[2]);
            nCaches = Convert.ToInt32(inputParameter[3]);
            sizeCaches = Convert.ToInt32(inputParameter[4]);

            // Creating cache servers
            int i = 0, j = 0;
            for (i = 0; i < nCaches; i++) {
                listCaches.Add(new Cache(i, sizeCaches));
            }

            // Second line : Videos
            line = reader.ReadLine();
            inputParameter = line.Split(' ');
            foreach(string size in inputParameter) {
                listVideos.Add(new Video(i++, Convert.ToInt32(size)));
            }

            // Loop Endpoints
            for(i = 0; i < nEndpoints; i++) {
                line = reader.ReadLine();
                inputParameter = line.Split(' ');

                int nCacheServers = Convert.ToInt32(inputParameter[1]);
                Client client = new Client(i, Convert.ToInt32(inputParameter[0]));

                // Cache servers
                for(j = 0; j < nCacheServers; j++) {
                    line = reader.ReadLine();
                    inputParameter = line.Split(' ');

                    int idCache = Convert.ToInt32(inputParameter[0]);
                    int latency = Convert.ToInt32(inputParameter[1]);

                    client.linkedCache.Add(listCaches[idCache], latency);
                }

                listClients.Add(client);
            }

            // Loop requests
            for(i = 0; i < nRequestDescriptions; i++) {
                line = reader.ReadLine();
                inputParameter = line.Split(' ');
                
                listRequests.Add(new Request(i, listVideos[Convert.ToInt32(inputParameter[0])], listClients[Convert.ToInt32(inputParameter[1])], Convert.ToInt32(inputParameter[2])));
            }

            ///////////////////////////////////////////
            List<Score> requestScore = new List<Score>();
            foreach (Request req in listRequests)
            {
                req.calculateScore();
                foreach(Score score in req.listScore)
                {
                    requestScore.Add(score);
                }
            }
            List<Score> sortedScore = requestScore.OrderBy(x => x.value).ToList();



            //////////////////////////////////////////

            foreach(Cache cacheServer in listCaches)
            {
            }

            Console.ReadLine();
        }
    }
}
