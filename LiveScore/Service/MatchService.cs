using System.Threading.Tasks;
using BasicInfrastructure.Persistence;
using LiveScore.Models;
using LiveScoresCore.Service;

namespace LiveScore.Service
{
    public class MatchService : Service<Match>
    {
        private readonly IRepository<Score> _repository;
        private readonly IRepository<Team> _teamRepository;

        public MatchService(IRepository<Match> repository,
            IRepository<Team> teamRepository) : base(repository)
        {
            _teamRepository = teamRepository;
        }
    }
}