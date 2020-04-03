using System;
using System.Collections.Generic;
using System.Text;

namespace Pocos
{
    public class CarPoco : IPoco
    {
        public Guid Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public DateTime MyProperty { get; set; }

        public virtual IEnumerable<CustomerPoco> Customers { get; set; }
    }
}
