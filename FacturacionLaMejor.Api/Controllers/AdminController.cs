using System.Linq;
using System.Web.Http;
using AttributeRouting.Web.Mvc;
using FacturacionLaMejor.domain.Entities;
using FacturacionLaMejor.domain.Services;
using FacturacionLaMejor.Api.Models;

namespace FacturacionLaMejor.Api.Controllers
{
    public class AdminController : ApiController
    {
        readonly IReadOnlyRepository _readOnlyRepository;
        readonly IWriteOnlyRepository _writeOnlyRepository;

        public AdminController(IReadOnlyRepository readOnlyRepository, IWriteOnlyRepository writeOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository;
            _writeOnlyRepository = writeOnlyRepository;
        }

        [HttpPost]
        [AcceptVerbs("POST", "HEAD")]
        [POST("admin")]
        public AuthModel admin([FromBody] adminModel model)
        {
            League lea = new League();
            lea.Name = model.Name;
            lea.Day = model.Day;
            lea.Location = model.Location;

            var newLeague = lea;
            var createdLeague = _writeOnlyRepository.Create(newLeague);

            var authModel = new AuthModel { };
            return authModel;
        }

        [HttpPost]
        [AcceptVerbs("POST", "HEAD")]
        [POST("FinishEditing")]
        public AuthModel FinishEditing([FromBody] adminModel model)
        {
            var nlea = _readOnlyRepository.FirstOrDefault<League>(x => x.Id == model.Id);
            nlea.Name = model.Name;
            nlea.Day = model.Day;
            nlea.Location = model.Location;

            var eLeague = nlea;
            var editLeague = _writeOnlyRepository.Update(eLeague);

            var authModel = new AuthModel { };
            return authModel;
        }

        [HttpPost]
        [AcceptVerbs("POST", "HEAD")]
        [POST("deleteLeague")]
        public void deleteLeague([FromBody] adminModel model)
        {
            _writeOnlyRepository.Delete<League>(model.Id);
        }

        [HttpPost]
        [AcceptVerbs("POST", "HEAD")]
        [POST("Register")]
        public void Register([FromBody] AccountLeagueModel model)
        {
            AccountLeague acl = new AccountLeague();
            acl.idAccount = model.idAccount;
            acl.idLeague = model.idLeague;

            _writeOnlyRepository.Create(acl);
        }

        [HttpPost]
        [AcceptVerbs("POST", "HEAD")]
        [POST("addNewTeam")]
        public void NewTeam([FromBody] TeamModel model)
        {
            Team te = new Team();
            te.Name = model.Name;
            te.NumberOfPlayers = model.NumberOfPlayers;
            te.Coach = model.Coach;

            _writeOnlyRepository.Create(te);
        }

        [HttpPost]
        [AcceptVerbs("POST", "HEAD")]
        [POST("deleteTeam")]
        public void deleteTeam([FromBody] TeamModel model)
        {
            _writeOnlyRepository.Delete<Team>(model.Id);
        }

        [HttpPost]
        [AcceptVerbs("POST", "HEAD")]
        [POST("FinishEditing1")]
        public AuthModel FinishEditing1([FromBody] TeamModel model)
        {
            var ntea = _readOnlyRepository.FirstOrDefault<Team>(x => x.Id == model.Id);
            ntea.Name = model.Name;
            ntea.NumberOfPlayers = model.NumberOfPlayers;
            ntea.Coach = model.Coach;

            var eTeam = ntea;
            var editTeam = _writeOnlyRepository.Update(eTeam);

            var authModel = new AuthModel { };
            return authModel;
        }

        [HttpPost]
        [AcceptVerbs("POST", "HEAD")]
        [POST("addNewMatch")]
        public AuthModel addNewMatch([FromBody] MatchModel model)
        {
            Match mat = new Match();
            mat.Id = model.Id;
            mat.Team1 = model.Team1;
            mat.Team2 = model.Team2;
            mat.Day = model.Day;

            _writeOnlyRepository.Create(mat);

            var authModel = new AuthModel { };
            return authModel;
        }

        [HttpPost]
        [AcceptVerbs("POST", "HEAD")]
        [POST("deleteGame")]
        public void deleteGame([FromBody] MatchModel model)
        {
            _writeOnlyRepository.Delete<Match>(model.Id);
        }

        [HttpPost]
        [AcceptVerbs("POST", "HEAD")]
        [POST("FinishEditing2")]
        public AuthModel FinishEditing2([FromBody] MatchModel model)
        {
            var nmat = _readOnlyRepository.FirstOrDefault<Match>(x => x.Id == model.Id);
            nmat.Team1 = model.Team1;
            nmat.Team2 = model.Team2;
            nmat.Day = model.Day;

            var eMatch = nmat;
            var editTeam = _writeOnlyRepository.Update(eMatch);

            var authModel = new AuthModel { };
            return authModel;
        }

        [HttpPost]
        [AcceptVerbs("POST", "HEAD")]
        [POST("addLT")]
        public AuthModel addLT([FromBody] LeagueTeamModel model)
        {
            LeagueTeam lt = new LeagueTeam();
            lt.Id = model.id;
            lt.idLeague = model.idLeague;
            lt.idTeam = model.idTeam;

            _writeOnlyRepository.Create(lt);

            var authModel = new AuthModel { };
            return authModel;
        }

        [HttpPost]
        [AcceptVerbs("POST", "HEAD")]
        [POST("addLM")]
        public AuthModel addLM([FromBody] LeagueMatchModel model)
        {
            LeagueMatch lm = new LeagueMatch();
            lm.Id = model.id;
            lm.idLeague = model.idLeague;
            lm.idMatch = model.idMatch;

            _writeOnlyRepository.Create(lm);

            var authModel = new AuthModel { };
            return authModel;
        }

        [HttpGet]
        [AcceptVerbs("GET", "HEAD")]
        [GET("leagues/available")]
        public League[] loadLeagues()
        {
            League[] leagues;
            leagues = _readOnlyRepository.GetAll<League>().ToList().ToArray();
            return leagues;
        }

        [HttpGet]
        [AcceptVerbs("GET", "HEAD")]
        [GET("loadallUsers")]
        public Account[] loadallUsers()
        {
            Account[] ausers;
            ausers = _readOnlyRepository.GetAll<Account>().ToList().ToArray();
            return ausers;
        }

        [HttpGet]
        [AcceptVerbs("GET", "HEAD")]
        [GET("loadTeams")]
        public Team[] loadTeams()
        {
            Team[] tteams;
            tteams = _readOnlyRepository.GetAll<Team>().ToList().ToArray();
            return tteams;
        }

        [HttpGet]
        [AcceptVerbs("GET", "HEAD")]
        [GET("loadMatches")]
        public Match[] loadMatches()
        {
            Match[] mats;
            mats = _readOnlyRepository.GetAll<Match>().ToList().ToArray();
            return mats;
        }

        [HttpGet]
        [AcceptVerbs("GET", "HEAD")]
        [GET("loadAL")]
        public AccountLeague[] loadAL()
        {
            AccountLeague[] accleags;
            accleags = _readOnlyRepository.GetAll<AccountLeague>().ToList().ToArray();
            return accleags;
        }

        [HttpGet]
        [AcceptVerbs("GET", "HEAD")]
        [GET("loadLT")]
        public LeagueTeam[] loadLT()
        {
            LeagueTeam[] leagteams;
            leagteams = _readOnlyRepository.GetAll<LeagueTeam>().ToList().ToArray();
            return leagteams;
        }

        [HttpGet]
        [AcceptVerbs("GET", "HEAD")]
        [GET("loadLM")]
        public LeagueMatch[] loadLM()
        {
            LeagueMatch[] leagmatches;
            leagmatches = _readOnlyRepository.GetAll<LeagueMatch>().ToList().ToArray();
            return leagmatches;
        }
    }
}