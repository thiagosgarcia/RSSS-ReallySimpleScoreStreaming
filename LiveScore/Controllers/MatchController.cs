using System.Web.Http.Cors;
using BasicInfrastructure.Service;
using BasicInfrastructureWeb.Controllers.Api;
using LiveScore.Models;

namespace LiveScore.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MatchController : BaseApiController<Match>
    {
        public MatchController(IService<Match> service) : base(service)
        {
        }
    }
}
