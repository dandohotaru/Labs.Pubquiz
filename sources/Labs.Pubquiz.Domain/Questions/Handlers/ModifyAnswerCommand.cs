using System;
using System.Runtime.Serialization;
using Labs.Pubquiz.Domain.Common;
using Labs.Pubquiz.Domain.Common.Handlers;

namespace Labs.Pubquiz.Domain.Questions.Handlers
{
    [DataContract]
    public class ModifyAnswerCommand : Command<ModifyAnswerCommand>
    {
        [DataMember]
        public Guid AnswerId { get; set; }

        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public bool Correct { get; set; }
    }
}