using RealEstateAgency.Data.Interfaces;
using RealEstateAgency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAgency.Data.Repositories
{
    public class AgentRepository : Repository<Agent>, IAgentRepository
    {
        public AgentRepository(ApplicationDbContext context) : base(context) { }
    }
}
