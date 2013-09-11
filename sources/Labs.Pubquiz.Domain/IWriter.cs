using Labs.Pubquiz.Domain.Common;

namespace Labs.Pubquiz.Domain
{
    public interface IWriter
    {
        void Process(ICommand command);
    }
}