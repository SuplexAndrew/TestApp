using System;
using System.Collections.Generic;

#nullable disable

namespace TestApp
{
    public partial class Completedtest
    {
        public Completedtest()
        {
            Answers = new HashSet<Answer>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Testid { get; set; }
        public int Personid { get; set; }

        public virtual Person Person { get; set; }
        public virtual Test Test { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
