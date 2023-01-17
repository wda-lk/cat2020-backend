using System;

namespace CAT20.Model
{
    public class Class
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public Guid StatusId { get; set; }
        public string Status { get; set; }
    }
}