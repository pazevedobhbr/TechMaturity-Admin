using System;
using TechMaturity.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace TechMaturity.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact (DisplayName = "Create Category with Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<TechMaturity.Domain.Validation.DomainExceptionValidation>();

        }

        [Fact(DisplayName = "Create Category with Invalid Id")]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                .Throw<TechMaturity.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");

        }

        [Fact(DisplayName = "Create Category with Name too Short")]
        public void CreateCategory_NameTooShort_DomainExceptionNameTooShort()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<TechMaturity.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");

        }




    }
}

