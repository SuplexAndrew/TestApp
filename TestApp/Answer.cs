using System;
using System.Collections.Generic;

#nullable disable

namespace TestApp
{
    public partial class Answer
    {
        public int Id { get; set; }
        public int Questionid { get; set; }
        public int Value { get; set; }
        public int Completedtestid { get; set; }

        public virtual Completedtest Completedtest { get; set; }
        public virtual Question Question { get; set; }
    }
}
