using System;
using System.Collections.Generic;

#nullable disable

namespace TestApp
{
    public partial class Test
    {
        public Test()
        {
            Completedtests = new HashSet<Completedtest>();
            Questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Creationdate { get; set; }

        public virtual ICollection<Completedtest> Completedtests { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
