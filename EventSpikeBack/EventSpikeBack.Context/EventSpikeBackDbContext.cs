using EventSpikeBack.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventSpikeBack.Context
{
    public class EventSpikeBackDbContext : DbContext
    {
        public EventSpikeBackDbContext(DbContextOptions<EventSpikeBackDbContext> options) : base(options)
        {
            
        }

        public virtual DbSet<UserEntity> User { get; set; }
    }
}