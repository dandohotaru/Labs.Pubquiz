using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Labs.Pubquiz.Domain.Common;

namespace Labs.Pubquiz.Domain.Questions.Commands
{
    [DataContract]
    public class ModifyQuestionCommand : Command<ModifyQuestionCommand>
    {
        [DataMember]
        public Guid QuestionId { get; set; }

        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public List<string> Tags { get; set; }
    }
}