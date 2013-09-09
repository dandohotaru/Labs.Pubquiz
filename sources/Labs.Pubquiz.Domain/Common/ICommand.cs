using System;

namespace Labs.Pubquiz.Domain.Common
{
    public interface ICommand
    {
        Guid CommandId { get; }

        DateTimeOffset Stamp { get; }
    }
}