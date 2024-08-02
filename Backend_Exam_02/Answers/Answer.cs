using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Exam_02.Answers
{
    internal class Answer : ICloneable, IEquatable<Answer>
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public Answer(int id, string text)
        {
            Id = id;
            Text = text;
        }

        public object Clone()
        {
            return new Answer(Id, Text);
        }

        public bool Equals(Answer? other)
        {
            if (other == null) return false;
            return Id == other.Id;
        }

        public override string? ToString()
        {
            return $"{Id}-{Text}";
        }
    }
}
