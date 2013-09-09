using System.ComponentModel;

namespace Labs.Pubquiz.Domain.Games.Entities
{
    public enum QuizStatus
    {
        [Description("Pending")]
        Pending = 0,

        [Description("Running")]
        Running = 1,

        [Description("Finished")]
        Finished = 2,
    }
}