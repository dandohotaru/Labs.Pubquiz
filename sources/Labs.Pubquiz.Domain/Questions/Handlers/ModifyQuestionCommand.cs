using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Labs.Pubquiz.Domain.Common;
using Labs.Pubquiz.Domain.Common.Handlers;

namespace Labs.Pubquiz.Domain.Questions.Handlers
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