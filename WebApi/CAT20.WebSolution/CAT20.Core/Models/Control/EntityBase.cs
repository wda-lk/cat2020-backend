using CAT20.Core.Models.Interfaces;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CAT20.Core.Models.Control
{
    public abstract class EntityBase : IEntityBase
    {
        private State _state = State.Unchanged;

        public int ID { get; set; }
        //[JsonIgnore]
        //public string User { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public byte[] TimeStamp { get; set; }
        //[JsonIgnore]
        //public State State { get { return _state; } set { _state = value; } }
        //public DateTime? DateCreated { get; set; }
        //[JsonIgnore]
        //public DateTime? DateModified { get; set; }
        //public string AuditReference { get; set; }
    }
}
