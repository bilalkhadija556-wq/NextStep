using NextStepMVC.Models;
using System.Collections.Generic;

namespace NextStepMVC.Repositories.Interfaces
{
    public interface IOpportunityRepository
    {
        List<Opportunity> GetAll();

        Opportunity GetById(int id);

        List<Opportunity> Search(string search);

        void Add(Opportunity opportunity);

        void Update(Opportunity opportunity);

        void Delete(int id);
    }
}
