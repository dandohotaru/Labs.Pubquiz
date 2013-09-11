using System;
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
                              };

            // When
            Writer.Process(command);

            // Then
            var query = new FindQuestionsByIdsQuery()
                .AddQuestionIds(questionId);
            var result = Reader.Process(query);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Questions, Is.Not.Null);
            Assert.That(result.Questions.Any(), Is.True);
            result.Dump();
        }
    }
}