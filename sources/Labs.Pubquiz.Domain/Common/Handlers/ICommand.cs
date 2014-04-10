using System;

namespace Labs.Pubquiz.Domain.Common.Handlers
{
    public interface ICommand
    {
        Guid CommandId { get; }

        DateTimeOffset Stamp { get; }
    }
}