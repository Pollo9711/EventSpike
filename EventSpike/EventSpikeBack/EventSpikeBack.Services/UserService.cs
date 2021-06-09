using System;
using EventSpikeBack.Domain;
using EventSpikeBack.Interfaces.Services;
using System.Collections.Generic;
using EventSpikeBack.Interfaces.Repositories;

namespace EventSpikeBack.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }


        public void Add(UserDomain user)
        {
            if (user is null)
            {
                throw new Exception("user can't be null");
            }
            _repository.Add(user);

        }

        public void Delete(int id)
        {
            if (_repository.Get(id) is null)
            {
                throw new Exception("user can't be null");
            }
            _repository.Delete(id);
        }

        public UserDomain Get(int id)
        {
            var user = _repository.Get(id);
            if (user is null)
            {
                throw new Exception("user can't be null");
            }
            return user;

        }

        public List<UserDomain> GetAll()
        {
            return _repository.GetAll();

        }

        public void Update(UserDomain user)
        {
            if (user is null)
            {
                throw new Exception("user can't be null");
            }
            _repository.Update(user);
        }
    }
}