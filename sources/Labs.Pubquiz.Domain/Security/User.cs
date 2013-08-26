﻿using System.Collections.Generic;
using Labs.Pubquiz.Domain.Common;

namespace Labs.Pubquiz.Domain.Security
{
    public class User : Entity
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IList<Role> Roles { get; set; }

        public IList<Profile> Profiles { get; set; }
    }
}