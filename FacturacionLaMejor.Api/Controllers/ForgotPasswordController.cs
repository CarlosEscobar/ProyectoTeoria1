using System;
using System.Web.Http;
using AttributeRouting.Web.Mvc;
using FacturacionLaMejor.domain.Entities;
using FacturacionLaMejor.domain.Services;
using FacturacionLaMejor.Api.Models;
using RestSharp;

namespace FacturacionLaMejor.Api.Controllers
{
    public class ForgotPasswordController : ApiController
    {
        readonly IReadOnlyRepository _readOnlyRepository;


        public ForgotPasswordController(IReadOnlyRepository readOnlyRepository)
        {

            _readOnlyRepository = readOnlyRepository;
        }

        [HttpPost]
        [AcceptVerbs("POST", "HEAD")]
        [POST("forgotpassword")]
        public AuthModel ForgotPassword([FromBody] ForgotPasswordModel model)
        {
            var resp = SendSimpleMessage(model.Email);
            var user = _readOnlyRepository.FirstOrDefault<Account>(x => x.Email == model.Email);
            var authModel = new AuthModel { Token = "SuperHash" };
            return authModel;
        }

        public static IRestResponse SendSimpleMessage(string destination)
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
            request.AddParameter("subject", "Restoring Password");
            String text = "Hi " + email + ", this authentication email will guide you on how to reset your password. \nClick on the following link to be guided: http://localhost:8080/resetpassword.";
            request.AddParameter("text", text);
            request.Method = Method.POST;
            return client.Execute(request);
        }

    }
}