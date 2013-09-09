using System;
using System.Runtime.Serialization;

namespace Labs.Pubquiz.Reports.Standings
{
    [DataContract]
    public class Player
    {
        [DataMember]
        public Guid PlayerId { get; set; }

        [DataMember]
        public Guid UserId { get; set; }

        [DataMember]
        public string Alias { get; set; }

        [DataMember]
        public int Points { get; set; }

        [DataMember]
        public int CorrectAnswers { get; set; }

        [DataMember]
        public int WrongAnswers { get; set; }
    }
}