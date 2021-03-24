using FluentValidation;

namespace UserSelfDesk.Applcaiton.Master.Dto
{
    public class ReferenceMasterVmValidator : AbstractValidator<ReferenceMasterViewModel>
    {
        public ReferenceMasterVmValidator()
        {
            RuleFor(x => x.title).MaximumLength(100).NotEmpty();
            RuleFor(x => x.description).MaximumLength(250);
            RuleFor(x => x.refCode).MaximumLength(50).NotEmpty();
        }
    }
}
