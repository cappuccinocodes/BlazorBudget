using FluentValidation;

namespace BlazorBudget.Shared.Models
{
    public interface IValidateCategory
    {
        Task<bool> CheckIfUnique(string category, CancellationToken cancellationToken);
    }

    public class Category
    {
        public int CategoryId { get; set; }
        
        public string Name { get; set; } 

        public IEnumerable<Record> Records { get; set; } 
    }

    public class CategoryValidator : AbstractValidator<Category>
    {
        private readonly IValidateCategory _validateCategory;

        public CategoryValidator(IValidateCategory validateCategory)
        {
            _validateCategory = validateCategory;
            
            RuleFor(x => x.Name)
                .NotEmpty()
                .MustAsync(BeUnique).WithMessage("Email already registered");
        }

        private async Task<bool> BeUnique(string email, CancellationToken token)
        {
            return await _validateCategory.CheckIfUnique(email, token);
        }
    }
}
