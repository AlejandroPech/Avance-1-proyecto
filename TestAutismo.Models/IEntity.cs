using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutismo.Models
{
    public interface IEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Update { get; set; }
    }
}
