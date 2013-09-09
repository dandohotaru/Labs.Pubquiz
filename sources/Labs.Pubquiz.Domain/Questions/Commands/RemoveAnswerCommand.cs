using System;
using System.Runtime.Serialization;
using Labs.Pubquiz.Domain.Common;

namespace Labs.Pubquiz.Domain.Questions.Commands
{
    [DataContract]
    public class RemoveAnswerCommand : Command<RemoveAnswerCommand>
    {
        [DataMember]
        public Guid AnswerId { get; set; }
    }
}