using System;
using System.Collections.Generic;

#nullable disable

namespace TestApp
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
        }

        public int Id { get; set; }
        public string Questionbody { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public int Rigthanswer { get; set; }
        public int? Testid { get; set; }

        public virtual Test Test { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
