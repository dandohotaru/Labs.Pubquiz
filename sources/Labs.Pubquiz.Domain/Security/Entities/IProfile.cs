using System;

namespace Labs.Pubquiz.Domain.Security.Entities
{
    public interface IProfile
    {
        Guid Id { get; set; }

        string UserLink { get; set; }
    }
}