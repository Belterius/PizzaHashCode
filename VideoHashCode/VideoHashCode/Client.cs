using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoHashCode
{
    public class Client
    {
        public int clientID { get; set; }
        public int latenceDataCenter { set; get; }
        public Dictionary<Cache, int> linkedCache;

        public Client(int clientID)
        {
            this.clientID = clientID;
            linkedCache = new Dictionary<Cache, int>();
        }
        public Client(int clientID, int latenceDataCenter)
        {
            this.clientID = clientID;
            this.latenceDataCenter = latenceDataCenter;
            linkedCache = new Dictionary<Cache, int>();
        }

    }
}
