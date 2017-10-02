using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicInfrastructure.Persistence;
using BasicInfrastructure.Service;
using LiveScore.Models;
using LiveScoresCore.Service;
using PagedList;

namespace LiveScore.Service
{
    public class ScoreService : Service<Score>
    {
        private readonly IRepository<Score> _repository;

        public ScoreService(IRepository<Score> repository) : base(repository)
        {
            _repository = repository;
        }

        public Task<Score> Update(Score entity, int id )
        {
            return base.Update(entity, id);
        }

        public async Task<Score> SetTimeLeft(int id, int timeLeft)
        {
            var score = await _repository.Get(id);
            score.TimeLeft = timeLeft;
            return await Update(score);
        }

        public async Task<Score> GoalForAwayTeam(int id)
        {
            var score = await _repository.Get(id);
            score.AwayTeamGoals++;

            return await Update(score);
        }
        public async Task<Score> GoalForHomeTeam(int id)
        {
            var score = await _repository.Get(id);
            score.HomeTeamGoals++;

            return await Update(score);
        }

        public async Task<Score> RemoveFromHomeTeam(int id)
        {
            var score = await _repository.Get(id);
            score.HomeTeamGoals = score.HomeTeamGoals <= 0? 0 : score.HomeTeamGoals - 1;

            return await Update(score);
        }
        public async Task<Score> RemoveFromAwayTeam(int id)
        {
            var score = await _repository.Get(id);
            score.AwayTeamGoals = score.AwayTeamGoals <= 0 ? 0 : score.AwayTeamGoals - 1;

            return await Update(score);
        }
    }
}