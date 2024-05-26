using FitnessTrackingApp.ServerApp.IServices;
using FitnessTrackingApp.ServerApp.Other.Dto;
using FitnessTrackingApp.ServerApp.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackingApp.ServerApp.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    [EnableCors("corsapp")]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllUsersWeight(Guid id)
        {
            var allWeights = await _historyService.GetAllUserData(id);
            return Ok(allWeights);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserWeight([FromBody] HistoryPost historyPost)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var newData = await _historyService.AddNewData(historyPost);
                return Ok(newData);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while adding the workout.");
            }

        }
    }
}
