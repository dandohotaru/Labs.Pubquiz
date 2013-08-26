using System;
using System.Collections.Generic;
using Labs.Pubquiz.Domain.Common;

namespace Labs.Pubquiz.Domain.Security
{
    public class Profile : Entity, IProfile
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