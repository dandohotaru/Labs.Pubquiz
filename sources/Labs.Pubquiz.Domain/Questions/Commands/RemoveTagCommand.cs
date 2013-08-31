using System;
using System.Runtime.Serialization;
using Labs.Pubquiz.Domain.Common.Commands;

namespace Labs.Pubquiz.Domain.Questions.Commands
{
    [DataContract]
    public class RemoveTagCommand : Command<RemoveTagCommand>
    {
        [DataMember]
        public Guid TagId { get; set; }
    }
}