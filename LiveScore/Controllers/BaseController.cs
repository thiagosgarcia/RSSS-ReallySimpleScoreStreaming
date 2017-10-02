using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using BasicInfrastructure.Persistence;
using BasicInfrastructure.Service;
using BasicInfrastructureWeb.Controllers.Api;

namespace LiveScore.Controllers
{
    public class BaseController<T> : BaseApiController<> where T : Entity
    {
        private readonly IService<T> _service;

        public BaseController(IService<T> service)
        {
            _service = service;
        }

        [System.Web.Mvc.HttpGet]
        public async Task<IEnumerable<T>> Get()
        {
            return await _service.GetAll();
        }

        public async Task<T> Get(int id)
        {
            return await _service.Get(id);
        }

        [System.Web.Mvc.HttpPost]
        public async Task<T> Post([FromBody]T value)
        {
            return await _service.Add(value);
        }

        public async Task<T> Put(int id, [FromBody]T value)
        {
            return await _service.Update(value, id);
        }

        public async Task<bool> Delete(int id)
        {
            return await _service.Delete(id);
        }
    }
}
