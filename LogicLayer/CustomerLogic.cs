using Pocos;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer
{
    public class CustomerLogic : BaseLogic<CustomerPoco>
    {
        public CustomerLogic(IDataRepository<CustomerPoco> repository) : base(repository)
        {
        }
        protected override void Verify(CustomerPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (CustomerPoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Name))
                {
                    exceptions.Add(new ValidationException(107, "Length must be 3 or more"));
                }
                
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
        public override void Add(CustomerPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override void Update(CustomerPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
    }
}
