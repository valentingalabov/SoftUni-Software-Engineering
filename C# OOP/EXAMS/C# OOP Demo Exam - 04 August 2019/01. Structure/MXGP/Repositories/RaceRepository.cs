using MXGP.Models.Races.Contracts;
using MXGP.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace MXGP.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly IList<IRace> motorcycles;

        public RaceRepository()
        {
            this.motorcycles = new List<IRace>();
        }

        public void Add(IRace model)
        => this.motorcycles.Add(model);

        public IReadOnlyCollection<IRace> GetAll()
         => this.motorcycles.ToList();

        public IRace GetByName(string name)
        => this.motorcycles.FirstOrDefault(x => x.Name == name);

        public bool Remove(IRace model)
        => this.motorcycles.Remove(model);
    }
}
