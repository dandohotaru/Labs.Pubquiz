using System;
using System.Runtime.Serialization;
using Labs.Pubquiz.Domain.Common;
using Labs.Pubquiz.Domain.Common.Handlers;

namespace Labs.Pubquiz.Domain.Questions.Handlers
{
    [DataContract]
    public class RemoveAnswerCommand : Command<RemoveAnswerCommand>
    {
        [DataMember]
        public Guid AnswerId { get; set; }
    }
}