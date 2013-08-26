using System;

namespace Labs.Pubquiz.Domain.Security
{
    public interface IProfile
    {
        Guid Id { get; set; }

        string UserLink { get; set; }
    }
}