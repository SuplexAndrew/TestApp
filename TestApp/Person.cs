﻿using System;
using System.Collections.Generic;

#nullable disable

namespace TestApp
{
    public partial class Person
    {
        public Person()
        {
            Completedtests = new HashSet<Completedtest>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Completedtest> Completedtests { get; set; }
    }
}
