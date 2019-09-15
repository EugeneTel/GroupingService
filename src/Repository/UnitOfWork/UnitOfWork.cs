using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Repositories;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public static bool Migrated = false;
        private AppDbContext _context;

        public UnitOfWork(
            AppDbContext context,
            UserRepository userRepository,
            GroupRepository groupRepository)
        {
            _context = context;
            Users = userRepository;
            Groups = groupRepository;

            //use only locally
            if (!Migrated)
            {
                _context.Database.Migrate();
                Migrated = true;
            }
        }
        public UserRepository Users { get; set; }

        public GroupRepository Groups { get; set; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}