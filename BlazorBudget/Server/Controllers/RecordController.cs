using BlazorBudget.Server.Repositories;
using BlazorBudget.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorBudget.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private readonly IRecordRepository _recordRepository;
        public RecordController(IRecordRepository RecordRepository)
        {
            _recordRepository = RecordRepository;
        }
        [HttpGet]
        public async Task<List<Record>> Get()
        {
            return await Task.FromResult(_recordRepository.GetRecordDetails());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Record record = _recordRepository.GetRecordData(id);
            return Ok(record);
        }
        [HttpPost]
        public void Post(Record record)
        {
            _recordRepository.AddRecord(record);
        }
        [HttpPut]
        public void Put(Record record)
        {
            _recordRepository.UpdateRecordDetails(record);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _recordRepository.DeleteRecord(id);
            return Ok();
        }
    }
}
