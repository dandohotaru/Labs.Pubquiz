using System;
using System.Collections.Generic;
using System.Linq;
using Labs.Pubquiz.Domain.Questions.Commands;
using Labs.Pubquiz.Reports.Questions.FindQuestionsByIds;
using Labs.Pubquiz.Tests.Common;
using NUnit.Framework;

namespace Labs.Pubquiz.Tests.Questions
{
    [TestFixture]
    public class AddQuestionTests : TestBase
    {
        [Test]
        public void ShouldStoreQuestionWhenNewQuestionIsAdded()
        {
            // Given
            var questionId = Guid.NewGuid();
            var command = new AddQuestionCommand
                {
                    QuestionId = questionId,
                    Text = "What is the capital of Belgium?",
                    Tags = new List<string> {"Geography", "Cities"},
                };

            // When
            Writer.Process(command);

            // Then
            var query = new FindQuestionsByIdsQuery()
                .AddQuestionIds(questionId);
            var result = Reader.Process(query);
            Assert.That(result.Questions.Single(p => p.Id == questionId), Is.Not.Null);
            result.Dump();
        }
    }
}