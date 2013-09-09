using System;
using System.Collections.Generic;
using Labs.Pubquiz.Reports.Common;

namespace Labs.Pubquiz.Reports.Questions.FindQuestionsByIds
{
    public class FindQuestionsByIdsQuery : Query<FindQuestionsByIdsResult>
    {
        public List<Guid> QuestionIds { get; set; }

        public FindQuestionsByIdsQuery AddQuestionIds(IEnumerable<Guid> questionIds)
        {
            if (QuestionIds == null)
                QuestionIds = new List<Guid>();
            QuestionIds.AddRange(questionIds);
            return this;
        }

        public FindQuestionsByIdsQuery AddQuestionIds(Guid questionId)
        {
            return AddQuestionIds(new[] {questionId});
        }
    }
}