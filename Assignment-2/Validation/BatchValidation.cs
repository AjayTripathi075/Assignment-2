using Assignment_2.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_2.Validation
{
    public class BusinessUnitValidator: AbstractValidator<Batch>
    {
        public BusinessUnitValidator()
        {
            RuleFor(x => x.BatchId);
            RuleFor(x => x.BusinessUnit.Description).NotEmpty().WithMessage("BusinessUnit is Required ").MinimumLength(3).WithMessage("BusinessUnit needs at least 3 characters");
            RuleFor(x => x.ExpiryDate).NotEmpty().WithMessage("ExpiryDate is Required ");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Status is Required ");
            RuleForEach(p => p.ReadUser).ChildRules(child =>
            {
                child.RuleFor(x => x.User).NotEmpty().WithMessage("User is required").NotNull();
            });
            RuleForEach(p => p.ReadGroup).ChildRules(child =>
            {
                child.RuleFor(x => x.GroupName).NotEmpty().WithMessage("Group Name is required").NotNull();
            });
            RuleForEach(p => p.Attribute).ChildRules(child =>
            {
                child.RuleFor(x => x.Key).NotEmpty().WithMessage("Key is required").NotNull();
                child.RuleFor(x => x.Value).NotEmpty().WithMessage("Value is required").NotNull();
            });

            RuleForEach(p => p.Files).ChildRules(child =>
            {
                child.RuleFor(x => x.FileName).NotEmpty().WithMessage("FileName is required").NotNull();
                child.RuleFor(x => x.FileSize).NotEmpty().WithMessage("FileSize is required").NotNull();
                child.RuleFor(x => x.MimeType).NotEmpty().WithMessage("MimeType is required").NotNull();
                child.RuleFor(x => x.Hash).NotEmpty().WithMessage("Hash is required").NotNull();
                child.RuleForEach(x => x.FileAttribute).NotEmpty().ChildRules(ch =>
                {
                    ch.RuleFor(x => x.Key).NotEmpty().WithMessage("File Attribute Key is Required");
                    ch.RuleFor(x => x.Value).NotEmpty().WithMessage("File Attribute Value is Required");

                });

            });

        }
    }
}
