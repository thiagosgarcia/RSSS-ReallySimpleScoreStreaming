﻿using System.Web.Http.Cors;
using BasicInfrastructure.Service;
using BasicInfrastructureWeb.Controllers.Api;
using LiveScore.Models;

namespace LiveScore.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TeamController : BaseApiController<Team>
    {
        public TeamController(IService<Team> service) : base(service)
        {
        }
    }
}
