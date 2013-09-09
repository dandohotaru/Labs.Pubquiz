using System;
using System.Runtime.Serialization;
using Labs.Pubquiz.Domain.Common;

namespace Labs.Pubquiz.Domain.Questions.Commands
{
    [DataContract]
    public class RemoveQuestionCommand : Command<RemoveQuestionCommand>
    {
        [DataMember]
        public Guid QuestionId { get; set; }
    }
}