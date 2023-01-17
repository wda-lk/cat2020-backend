using System;

namespace CAT20.Model
{
    public class ClassStream
    {
        public Guid Id { get; set; }
        public Guid ClassId { get; set; }
        public string Class { get; set; }
        public Guid? SectionId { get; set; }
        public string Section { get; set; }
        public Guid StreamId { get; set; }
        public string Stream { get; set; }
        public Guid StatusId { get; set; }
        public string Status { get; set; }
    }
}