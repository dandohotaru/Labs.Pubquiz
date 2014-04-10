using System;
using System.Runtime.Serialization;
using Labs.Pubquiz.Domain.Common;
using Labs.Pubquiz.Domain.Common.Handlers;

namespace Labs.Pubquiz.Domain.Questions.Handlers
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