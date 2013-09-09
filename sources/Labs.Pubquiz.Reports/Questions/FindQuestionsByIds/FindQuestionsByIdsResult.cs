using System;
using System.Collections.Generic;
using Labs.Pubquiz.Reports.Common;

namespace Labs.Pubquiz.Reports.Questions.FindQuestionsByIds
{
    public class FindQuestionsByIdsResult : Result
    {
        public List<QuestionInfo> Questions { get; set; }

        public List<AnswerInfo> Answers { get; set; }
    }

    public class QuestionInfo
    {
        public Guid Id { get; set; }

        public string Text { get; set; }
    }

    public class AnswerInfo
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public bool Correct { get; set; }

        public Guid QuestionId { get; set; }
    }
}