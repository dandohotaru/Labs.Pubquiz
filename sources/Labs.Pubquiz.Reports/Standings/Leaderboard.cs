using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Labs.Pubquiz.Reports.Standings
{
    [DataContract]
    public class Leaderboard
    {
        [DataMember]
        public Guid GameId { get; set; }

        [DataMember]
        public string GameName { get; set; }

        [DataMember]
        public List<Player> Players { get; set; }
    }
}