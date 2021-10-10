using MarsRoverProblem.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace MarsRoverProblem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PositionsController : ControllerBase
    {
        private readonly ILogger<PositionsController> _logger;
        private readonly IPosition _position;
        private readonly IInMemoryPositionStore _inMemoryPositionStore;

        public PositionsController(ILogger<PositionsController> logger, IPosition position, IInMemoryPositionStore inMemoryPositionStore)
        {
            _logger = logger;
            _position = position;
            _inMemoryPositionStore = inMemoryPositionStore;
        }

        [HttpGet("{moves}")]
        public IActionResult GetPosition(string moves)
        {
            return Ok(new
            {
                value = _inMemoryPositionStore.GetHistoryByMoves(moves)
            });
        }

        [HttpGet]
        public IActionResult GetHistory()
        {
            return Ok(_inMemoryPositionStore.GetHistory()
                .Select(s => new
                {
                    s.Key,
                    s.Value
                }));
        }

        [HttpPost]
        public IActionResult Post([FromBody] MovingRequestModel movingRequest)
        {
            try
            {
                _position.SetPosition(movingRequest.X, movingRequest.Y, movingRequest.Direction);
                _position.StartMoving(movingRequest.MaxPoints, movingRequest.Moves);
                _inMemoryPositionStore.Add(movingRequest.X, movingRequest.Y, movingRequest.Direction, movingRequest.Moves, _position.ToString());
                return Ok(new { value = _position.ToString() });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
