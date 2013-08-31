using System;
using System.Collections.Generic;
using Labs.Pubquiz.Domain.Common.Entities;

namespace Labs.Pubquiz.Domain.Security.Entities
{
    public class Profile : Entity<Profile>, IProfile
    {
        public string UserName { get; set; }

        public string UserLink { get; set; }
    }

    public class FacebookProfile : Profile
    {
        public DateTimeOffset Birthday { get; set; }
    }

    public class LinkedinProfile : Profile
    {
        public string Position { get; set; }
    }

    public class TwitterProfile : Profile
    {
        public IList<string> Tweets { get; set; }
    }
}