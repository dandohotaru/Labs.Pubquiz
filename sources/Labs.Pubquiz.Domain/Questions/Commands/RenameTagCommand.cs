using System;
using System.Runtime.Serialization;
using Labs.Pubquiz.Domain.Common;

namespace Labs.Pubquiz.Domain.Questions.Commands
{
    [DataContract]
    public class RenameTagCommand : Command<RenameTagCommand>
    {
        [DataMember]
        public Guid TagId { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}