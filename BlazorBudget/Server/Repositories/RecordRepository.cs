using BlazorBudget.Server.Models;
using BlazorBudget.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorBudget.Server.Repositories
{
    public interface IRecordRepository
    {
        public List<Record> GetRecordDetails();
        public void AddUser(Record record);
        public void UpdateRecordDetails(Record record);
        public Record GetRecordData(int id);
        public void DeleteRecord(int id);
    }

    public class RecordRepository: IRecordRepository
    {
        readonly DatabaseContext _dbContext;
        public RecordRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        //To Get all user details
        public List<Record> GetUserDetails()
        {
            try
            {
                return _dbContext.Records.ToList();
            }
            catch
            {
                throw;
            }
        }
        //To Add new user record
        public void AddUser(Record record)
        {
            try
            {
                _dbContext.Records.Add(user);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar user
        public void UpdateUserDetails(Record user)
        {
            try
            {
                _dbContext.Entry(user).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //Get the details of a particular user
        public Record GetUserData(int id)
        {
            try
            {
                Record? user = _dbContext.Records.Find(id);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
        //To Delete the record of a particular user
        public void DeleteUser(int id)
        {
            try
            {
                Record? user = _dbContext.Records.Find(id);
                if (user != null)
                {
                    _dbContext.Records.Remove(user);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
