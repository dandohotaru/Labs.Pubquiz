using System;
using System.Runtime.Serialization;
using Labs.Pubquiz.Reports.Common;

namespace Labs.Pubquiz.Reports.Standings
{
    [DataContract]
    public class Player : IResult
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