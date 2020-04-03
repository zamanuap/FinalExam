using System;
using System.Collections.Generic;
using System.Text;

namespace Pocos
{
    public class CustomerPoco : IPoco
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Province { get; set; }

        public virtual CarPoco Cars { get; set; }
    }
}
