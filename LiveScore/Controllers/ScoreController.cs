using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using BasicInfrastructureWeb.Controllers.Api;
using LiveScore.Models;
using LiveScore.Service;
using Newtonsoft.Json;

namespace LiveScore.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ScoreController : BaseApiController<Score>
    {
        private readonly ScoreService _service;

        public ScoreController(ScoreService service) :base(service)
        {
            _service = service;
        }

        [System.Web.Mvc.HttpPut]
        public async Task<Score> SetTimeLeft(int id, int timeLeft)
        {
            return await _service.SetTimeLeft(id, timeLeft);
        }
        [System.Web.Mvc.HttpPut]
        public async Task<Score> GoalForHomeTeam(int id)
        {
            return await _service.GoalForHomeTeam(id);
        }
        [System.Web.Mvc.HttpPut]
        public async Task<Score> GoalForAwayTeam(int id)
        {
            return await _service.GoalForAwayTeam(id);
        }
        [System.Web.Mvc.HttpPut]
        public async Task<Score> RemoveFromHomeTeam(int id)
        {
            return await _service.RemoveFromHomeTeam(id);
        }
        [System.Web.Mvc.HttpPut]
        public async Task<Score> RemoveFromAwayTeam(int id)
        {
            return await _service.RemoveFromAwayTeam(id);
        }
    }
}
