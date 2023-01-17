using System.Collections.Generic;

namespace CAT20.Model
{
    public class StudentFee
    {
        public Student Student { get; set; }
        public IEnumerable<Fee> Fees { get; set; }
        public IEnumerable<Parent> Parents { get; set; }
    }
}