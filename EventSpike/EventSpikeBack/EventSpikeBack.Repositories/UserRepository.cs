using EventSpikeBack.Domain;
using EventSpikeBack.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EventSpikeBack.Context;
using EventSpikeBack.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventSpikeBack.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly EventSpikeBackDbContext _context;
        public readonly IMapper _mapper;

        public UserRepository(EventSpikeBackDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(UserDomain user)
        {
            var userEntity = _mapper.Map<UserEntity>(user);
            _context.User.Add(userEntity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var userId = _context.User.FirstOrDefault( u =>u.Id == id);
            _context.User.Remove(userId);
            _context.SaveChanges();

        }

        public UserDomain Get(int id)
        {
            var userEntity = _context.User.FirstOrDefault(u => u.Id == id);
            return _mapper.Map<UserDomain>(userEntity);
        }

        public List<UserDomain> GetAll()
        {
            var user = _context.User;
            return _mapper.ProjectTo<UserDomain>(user).ToList();
        }

        public void Update(UserDomain user)
        {
            var userEntity = _mapper.Map<UserEntity>(user);
            _context.User.Update(userEntity);
            _context.SaveChanges();
        }
    }
}