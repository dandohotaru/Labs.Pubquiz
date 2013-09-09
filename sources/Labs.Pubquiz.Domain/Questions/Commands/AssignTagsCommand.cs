using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Labs.Pubquiz.Domain.Common;

namespace Labs.Pubquiz.Domain.Questions.Commands
{
    [DataContract]
    public class AssignTagsCommand : Command<AssignTagsCommand>
    {
        [DataMember]
        public Guid QuestionId { get; set; }

        [DataMember]
        public List<string> Tags { get; set; }
    }
}