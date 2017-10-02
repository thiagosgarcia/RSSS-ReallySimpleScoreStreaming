using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasicInfrastructure.Persistence;
using BasicInfrastructure.Service;
using BasicInfrastructureWeb.DependencyResolution;
using LiveScore.Models;
using LiveScore.Service;
using StructureMap;

namespace LiveScore.App_Start
{
    public static class IoC
    {
        public static IContainer Initialize()
        {
            return new Container(c =>
            {
                c.AddRegistry<AppRegistry>();

#if DEBUG
                c.For<AppDbContext>().Use<AppDbContext>().Ctor<string>("DefaultConnection");
#else
                c.For<AppDbContext>().Use<AppDbContext>().Ctor<string>("ProductionConnection");
#endif

                c.For<IService<Match>>().Use<MatchService>();
                c.For<IRepository<Match>>().Use<Repository<Match, AppDbContext>>();

                c.For<IService<Score>>().Use<ScoreService>();
                c.For<IRepository<Score>>().Use<Repository<Score, AppDbContext>>();

                c.For<IService<Team>>().Use<BaseService<Team>>();
                c.For<IRepository<Team>>().Use<Repository<Team, AppDbContext>>();

            });
        }
    }
}