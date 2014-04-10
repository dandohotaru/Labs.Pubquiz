using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Labs.Pubquiz.Domain.Common;
using Labs.Pubquiz.Domain.Common.Handlers;

namespace Labs.Pubquiz.Domain.Questions.Handlers
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