using BlazorBudget.Server.Models;
using BlazorBudget.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorBudget.Server.Repositories
{
    public interface IRecordRepository
    {
        public List<Record> GetRecordDetails();
        public void AddRecord(Record record);
        public void UpdateRecordDetails(Record record);
        public Record GetRecordData(int id);
        public void DeleteRecord(int id);
    }

    public class RecordRepository : IRecordRepository
    {
        readonly DatabaseContext _dbContext;

        public RecordRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Record> GetRecordDetails()
        {
                var rec = _dbContext.Records
                    .Include(x => x.Category)
                    .ToList();

                return rec;
                
        }

        public void AddRecord(Record record)
        {
            _dbContext.Records.Add(record);
            _dbContext.SaveChanges();

        }

        public void UpdateRecordDetails(Record record)
        {

            _dbContext.Entry(record).State = EntityState.Modified;
            _dbContext.SaveChanges();

        }

        public Record GetRecordData(int id)
        {
            Record? user = _dbContext.Records.Find(id);
            if (user != null)
                return user;

            throw new ArgumentNullException();

        }
        //To Delete the record of a particular user
        public void DeleteRecord(int id)
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
    }
}
