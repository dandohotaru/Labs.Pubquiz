using System;

namespace Labs.Pubquiz.Domain.Common.Commands
{
    public interface ICommand
    {
        Guid CommandId { get; }

        DateTimeOffset Stamp { get; }
    }
}