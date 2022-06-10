using Assignment_2.Models;
using Assignment_2.Models.Data.Dto;
using Assignment_2.Repositories.IRepository;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment_2.Validation
{
    public class AddBatchRequestValidation : AbstractValidator<BatchDto>
    {
        public AddBatchRequestValidation(IBatchRepository batchRepository)
        {
           
            RuleFor(x => x.ExpiryDate).NotEmpty().WithMessage("ExpiryDate is Required ");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Status is Required ");
            RuleFor(x => x.BusinessUnitId).NotEmpty().Must(id => {
                var businessUnit = batchRepository.GetBusinessUnitsAsync().Result.ToList().FirstOrDefault(x => x.Id == id);
                if (businessUnit != null)
                {
                    return true;
                }
                return false;
            }).WithMessage("Business Unit Not Availabe , Please Enter Correct Business Unit");

            RuleFor(x => x.Acl).NotEmpty().NotNull().WithMessage("Acl Is Required");
            RuleForEach(p => p.Acl.ReadUsers).NotEmpty().WithMessage("ReadUsers is Required").ChildRules(child =>
            {
                child.RuleFor(x => x.User).NotEmpty().WithMessage("User is required").NotNull();
            });
            RuleForEach(p => p.Acl.ReadGroups).NotEmpty().WithMessage("ReadGroups is Required").ChildRules(child =>
            {
                child.RuleFor(x => x.GroupName).NotEmpty().WithMessage("Group Name is required").NotNull();
            });
            RuleForEach(p => p.Attributes).NotEmpty().WithMessage("Attribute is Required").ChildRules(child =>
            {
                child.RuleFor(x => x.Key).NotEmpty().WithMessage("Key is required").NotNull();
                child.RuleFor(x => x.Value).NotEmpty().WithMessage("Value is required").NotNull();
            });
            RuleForEach(p => p.Files).NotEmpty().WithMessage("Files Is Required").ChildRules(child =>
            {
                child.RuleFor(x => x.FileName).NotEmpty().WithMessage("FileName is required").NotNull();
                child.RuleFor(x => x.FileSize).NotEmpty().WithMessage("FileSize is required").NotNull();
                child.RuleFor(x => x.MimeType).NotEmpty().WithMessage("MimeType is required").NotNull();
                child.RuleFor(x => x.Hash).NotEmpty().WithMessage("Hash is required").NotNull();
                child.RuleForEach(x => x.FileAttributes).NotEmpty().ChildRules(ch =>
                {
                    ch.RuleFor(x => x.Key).NotEmpty().WithMessage("File Attribute Key is Required");
                    ch.RuleFor(x => x.Value).NotEmpty().WithMessage("File Attribute Value is Required");
                });
            });

        

        //RuleFor(x => x.businessUnit.Description).NotEmpty().Must(BusinessUnit => {
        //    var businessUnit = batchRepository.GetBusinessUnitsAsync().Result.ToList().FirstOrDefault(x => x.Description == BusinessUnit);
        //    if (businessUnit != null)
        //    {
        //        return true;
        //    }
        //    return false;
        //}).WithMessage("Business Unit Not Availabe , Please Enter Correct Business Unit");
    }
       

    }
  

}
