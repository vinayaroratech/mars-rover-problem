using MarsRoverProblem.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

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
        public string GetPosition(string moves)
        {
            return _inMemoryPositionStore.GetHistoryByMoves(moves);
        }

        [HttpGet]
        public IDictionary<string, string> GetHistory()
        {
            return _inMemoryPositionStore.GetHistory();
        }

        [HttpPost]
        public string Post([FromBody] MovingRequestModel movingRequest)
        {
            _position.SetPosition(movingRequest.X, movingRequest.Y, movingRequest.Direction);
            _position.StartMoving(movingRequest.MaxPoints, movingRequest.Moves);
            _inMemoryPositionStore.Add(movingRequest.X, movingRequest.Y, movingRequest.Direction, movingRequest.Moves, _position.ToString());
            return _position.ToString();
        }
    }
}
