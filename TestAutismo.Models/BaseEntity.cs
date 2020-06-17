using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutismo.Models
{
    public class BaseEntity:IEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime? Update { get; set; }
    }
}
