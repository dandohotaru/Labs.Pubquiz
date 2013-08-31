using System;
using System.Runtime.Serialization;
using Labs.Pubquiz.Domain.Common.Commands;

namespace Labs.Pubquiz.Domain.Questions.Commands
{
    [DataContract]
    public class AddAnswerCommand : Command<AddAnswerCommand>
    {
        [DataMember]
        public Guid AnswerId { get; set; }

        [DataMember]
        public Guid QuestionId { get; set; }

        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public bool Correct { get; set; }
    }
}