using Pocos;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer
{
    public class CarLogic : BaseLogic<CarPoco>
    {
        public CarLogic(IDataRepository<CarPoco> repository) : base(repository)
        {
        }
        protected override void Verify(CarPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (CarPoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Make))
                {
                    exceptions.Add(new ValidationException(107, "Must have a make"));
                }

            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
        public override void Add(CarPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override void Update(CarPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
    }
}
