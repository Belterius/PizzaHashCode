﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoHashCode
{
    class Program
    {
        public static string Reverse(string s) {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        static void Main(string[] args)
        {
            switch(args.Length) {
                case 0:
                    Console.WriteLine("Please, pass an input file as a parameter");
                    Console.ReadLine();
                    return;

                case 1: break;

                default:
                    Console.WriteLine("Please, pass only one file");
                    Console.ReadLine();
                    return;
            }

            FileAttributes file_attr = File.GetAttributes(args[0]);
            if (file_attr.HasFlag(FileAttributes.Directory)) {
                Console.WriteLine("Please, pass a file not a directory");
                Console.ReadLine();
                return;
            }

            Directory.CreateDirectory(Environment.CurrentDirectory + "\\out");

            string file_in = args[0];
            string file_out = Environment.CurrentDirectory + "\\out\\" + Reverse(Reverse(file_in).Split('.')[1].Split('\\')[0]) + ".out";

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
            reader = new StreamReader(file_in);

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

            i = 0;
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
            List<Score> sortedScore = requestScore.OrderBy(x => x.value).Reverse().ToList();

            foreach(Score score in sortedScore)
            {
                score.cache.AddVideo(score.request);
            }
            //////////////////////////////////////////

            // Parsing out
            int nUsedCache = 0;
            foreach (Cache cacheServer in listCaches) {
                if (cacheServer.CurrentCapacity != 0) {
                    nUsedCache++;
                }
            }

            using (StreamWriter outputFile = new StreamWriter(file_out)) {
                outputFile.WriteLine(nUsedCache);
                foreach(Cache cacheServer in listCaches) {
                    if (cacheServer.CurrentCapacity != 0) {
                        outputFile.Write(cacheServer.cacheID);
                        foreach(Video video in cacheServer.cachedVideos) {
                            outputFile.Write(" " + video.videoID);
                        }

                        outputFile.WriteLine("");
                    }
                }
            }

            //Console.ReadLine();
        }
    }
}
