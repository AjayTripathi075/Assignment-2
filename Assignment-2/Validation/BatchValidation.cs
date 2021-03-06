using Assignment_2.Models;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Assignment_2.Validation
{
    public class BatchValidation : AbstractValidator<Batch>
    {
        public BatchValidation()
        {
            RuleFor(x => x.BatchId).Null().WithMessage("BatchId Should Contain a Guid Format");
            //RuleFor(x => x.BatchId).Must(guid => GuidValidator.IsGuid(guid.ToString())).WithMessage("Please Enter BatchId in GuidFormat");
            RuleFor(x => x.ExpiryDate).NotEmpty().WithMessage("ExpiryDate is Required ");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Status is Required ");
            RuleFor(p => p.BusinessUnit).NotEmpty().WithMessage("BusinessUnit is Required");
            RuleFor(p => p.Acl).NotEmpty().WithMessage("Acl is Required");
            RuleForEach(p => p.Acl.ReadUsers).NotEmpty().WithMessage("ReadUsers is Required").ChildRules(child =>
            {
                child.RuleFor(x => x.User).NotEmpty().WithMessage("User is required").NotNull();
            });
            RuleForEach(p => p.Attributes).NotEmpty().WithMessage("Attribute is Required").ChildRules(child =>
            {
                child.RuleFor(x => x.Key).NotEmpty().WithMessage("Key is required").NotNull();
                child.RuleFor(x => x.Value).NotEmpty().WithMessage("Value is required").NotNull();
            });
            RuleForEach(p => p.Acl.ReadGroups).NotEmpty().WithMessage("ReadGroups is Required").ChildRules(child =>
            {
                child.RuleFor(x => x.GroupName).NotEmpty().WithMessage("Group Name is required").NotNull();
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

          
        }
  
    }

    public static class GuidValidator
    {
        private static readonly Regex isGuid = new Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", RegexOptions.Compiled);
        public static bool IsGuid(string candidate)
        {
            if (candidate != null)
            {
                if (isGuid.IsMatch(candidate))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
