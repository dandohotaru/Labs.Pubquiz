using System;
using Labs.Pubquiz.Domain.Questions.Commands;
using Labs.Pubquiz.Tests.Common;
using NUnit.Framework;

namespace Labs.Pubquiz.Tests.Questions
{
    [TestFixture]
    public class AddQuestionTests : TestBase
    {
        [Test]
        public void ShouldPersistQuestionToTheUnderlyingDataStoreWhenNewQuestionIsAdded()
        {
            // Given
            var command = new AddQuestionCommand
                              {
                                  QuestionId = Guid.NewGuid(),
                                  Text = "What is the capital of Belgium?",
                              };

            // When
            Dispatcher.Send(command);

            // Then
            // ToDo: Implement query handlers and verify data.
        }
    }
}