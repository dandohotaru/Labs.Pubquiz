using System;
using System.Runtime.Serialization;
using Labs.Pubquiz.Domain.Common;
using Labs.Pubquiz.Domain.Common.Handlers;

namespace Labs.Pubquiz.Domain.Questions.Handlers
{
    [DataContract]
    public class RemoveQuestionCommand : Command<RemoveQuestionCommand>
    {
        [DataMember]
        public Guid QuestionId { get; set; }
    }
}