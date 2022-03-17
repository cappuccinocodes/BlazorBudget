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
            Record user = _recordRepository.GetRecordData(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }
        [HttpPost]
        public void Post(Record user)
        {
            _recordRepository.AddRecord(user);
        }
        [HttpPut]
        public void Put(Record user)
        {
            _recordRepository.UpdateRecordDetails(user);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _recordRepository.DeleteRecord(id);
            return Ok();
        }
    }
}
