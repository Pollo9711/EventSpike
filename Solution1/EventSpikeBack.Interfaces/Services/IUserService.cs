using System.Collections.Generic;
using EventSpikeBack.Domain;

namespace EventSpikeBack.Interfaces.Services
{
    public interface IUserService 
    {
        List<UserDomain> GetAll();
        UserDomain Get(int id);
        void Update(UserDomain user);
        void Add(UserDomain user);
        void Delete(int id);
    }
}