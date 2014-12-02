using System;
using System.Web.Http;
using AttributeRouting.Web.Mvc;
using FacturacionLaMejor.domain.Entities;
using FacturacionLaMejor.domain.Services;
using FacturacionLaMejor.Api.Models;
using RestSharp;

namespace FacturacionLaMejor.Api.Controllers
{
    public class RegisterController : ApiController
    {
        readonly IReadOnlyRepository _readOnlyRepository;
        readonly IWriteOnlyRepository _writeOnlyRepository;


        public RegisterController(IReadOnlyRepository readOnlyRepository, IWriteOnlyRepository writeOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository;
            _writeOnlyRepository = writeOnlyRepository;
        }

        [HttpPost]
        [AcceptVerbs("POST", "HEAD")]
        [POST("signup")]
        public AuthModel signup([FromBody] RegisterModel model)
        {
            Account ac = new Account();
            ac.Name = model.DisplayName;
            ac.Email = model.Email;
            ac.Password = model.Password;

            var newUser = ac;
            var createdUser = _writeOnlyRepository.Create(newUser);

            var resp = SendSimpleMessage(model.Email, model.FirstName, model.LastName, model.DisplayName);
            var authModel = new AuthModel { Token = "SuperHash" };
            return authModel;
        }

        public static IRestResponse SendSimpleMessage(string destination, string firstname, string lastname, string displayname)
        {
            var client = new RestClient
            {
                BaseUrl = "https://api.mailgun.net/v2",
                Authenticator = new HttpBasicAuthenticator("api",
                    "key-9y9ypyn3hneqzpz6eojvfj3zzag92332")
            };
            var request = new RestRequest();
            request.AddParameter("domain",
                                "appcf01bdaa3c9642d09d34fcceafc37ac6.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "PrediLiga | Carlos <postmaster@appcf01bdaa3c9642d09d34fcceafc37ac6.mailgun.org>");
            String email = "<" + destination + ">";
            request.AddParameter("to", email);
            request.AddParameter("subject", "Register Process");
            String text = "Hello " + firstname + " " + lastname + ", congratulations on completing the Register process for Prediliga. \nYour registered username is " + displayname + ". \nTo finish the process, click the following link: http://localhost:8080/login .";
            request.AddParameter("text", text);
            request.Method = Method.POST;
            return client.Execute(request);
        }

    }
}
