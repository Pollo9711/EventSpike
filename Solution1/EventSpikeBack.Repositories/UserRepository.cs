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
            var idEntity = _context.User.FirstOrDefault( u =>u.Id == id);
            _context.User.Remove(idEntity);
            _context.SaveChanges();

        }

        public UserDomain Get(int id)
        {
            
        }

        public List<UserDomain> GetAll()
        {
            
        }

        public void Update(UserDomain user)
        {
            
        }
    }
}