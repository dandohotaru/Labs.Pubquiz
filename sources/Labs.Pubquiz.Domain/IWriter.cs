using Labs.Pubquiz.Domain.Common;
using Labs.Pubquiz.Domain.Common.Handlers;

namespace Labs.Pubquiz.Domain
{
    public interface IWriter
    {
        void Process(ICommand command);
    }
}