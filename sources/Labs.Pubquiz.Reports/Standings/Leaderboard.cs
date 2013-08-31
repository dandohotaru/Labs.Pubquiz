using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Labs.Pubquiz.Reports.Common;

namespace Labs.Pubquiz.Reports.Standings
{
    [DataContract]
    public class Leaderboard : IResult
    {
        [DataMember]
        public Guid GameId { get; set; }

        [DataMember]
        public string GameName { get; set; }

        [DataMember]
        public List<Player> Players { get; set; }
    }
}