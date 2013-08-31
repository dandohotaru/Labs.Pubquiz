using System;
using System.Runtime.Serialization;
using Labs.Pubquiz.Domain.Common.Commands;

namespace Labs.Pubquiz.Domain.Questions.Commands
{
    [DataContract]
    public class RemoveQuestionCommand : Command<RemoveQuestionCommand>
    {
        [DataMember]
        public Guid QuestionId { get; set; }
    }
}