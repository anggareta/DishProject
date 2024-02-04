using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestoProject.Services.StatsService
{
  public interface IStatsService
  {
    Task<int> GetVisits();
    Task IncrementVisits();
  }
}
