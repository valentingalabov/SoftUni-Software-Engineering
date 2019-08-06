using MXGP.Models.Riders.Contracts;
using MXGP.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace MXGP.Repositories
{
    public class RiderRepository : IRepository<IRider>
    {
        private readonly IList<IRider> motorcycles;

        public RiderRepository()
        {
            this.motorcycles = new List<IRider>();
        }

        public void Add(IRider model)
        => this.motorcycles.Add(model);

        public IReadOnlyCollection<IRider> GetAll()
         => this.motorcycles.ToList();

        public IRider GetByName(string name)
        => this.motorcycles.FirstOrDefault(x => x.Name == name);

        public bool Remove(IRider model)
        => this.motorcycles.Remove(model);

    }
}
