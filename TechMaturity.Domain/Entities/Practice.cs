using System;
using TechMaturity.Domain.Validation;

namespace TechMaturity.Domain.Entities
{
    public sealed class  Practice : Entity
    {

        public string Name { get; private set; }

        public Practice(string name)
        {
            ValidateDomain(name);

        }

        public Practice(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        //public ICollection<Product> Products { get; set; }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(String.IsNullOrEmpty(name), "Invalid name. Name is required.");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters.");

            Name = name;
        }

    }
}
