using System.Linq;
using System.Web.Http;
using AttributeRouting.Web.Mvc;
using FacturacionLaMejor.domain.Entities;
using FacturacionLaMejor.domain.Services;

namespace FacturacionLaMejor.Api.Controllers
{
    public class LoginController : ApiController
    {
        readonly IReadOnlyRepository _readOnlyRepository;


        public LoginController(IReadOnlyRepository readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository;
        }

        [HttpGet]
        [AcceptVerbs("GET", "HEAD")]
        [GET("loadUsers")]
        public Account[] loadUsers()
        {
            Account[] users;
            users = _readOnlyRepository.GetAll<Account>().ToList().ToArray();
            return users;
        }

    }
}