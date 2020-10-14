using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Microservice.Entities
{
    public abstract class BaseEntity
    {
        //use this class as the base class for our future entities. 
        //Here we can define the common and secured properties like Id, CreatedDate etc.
        public int Id { get; set; }
    }
}
