using BlazorBudget.Server.Models;
using BlazorBudget.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorBudget.Server.Repositories
{
    public interface ICategoryRepository
    {
        public List<Category> GetCategoryDetails();
        public void AddCategory(Category category);
        public void UpdateCategoryDetails(Category category);
        public Category GetCategoryData(int id);
        public void DeleteCategory(int id);
    }

    public class CategoryRepository : ICategoryRepository
    {
        readonly DatabaseContext _dbContext;

        public CategoryRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Category> GetCategoryDetails()
        {

            return _dbContext.Categories.ToList();

        }

        public void AddCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();

        }

        public void UpdateCategoryDetails(Category category)
        {

            _dbContext.Entry(category).State = EntityState.Modified;
            _dbContext.SaveChanges();

        }

        public Category GetCategoryData(int id)
        {
            Category? user = _dbContext.Categories.Find(id);
            if (user != null)
                return user;

            throw new ArgumentNullException();

        }
        //To Delete the category of a particular user
        public void DeleteCategory(int id)
        {
            Category? user = _dbContext.Categories.Find(id);
            if (user != null)
            {
                _dbContext.Categories.Remove(user);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
    }
}
