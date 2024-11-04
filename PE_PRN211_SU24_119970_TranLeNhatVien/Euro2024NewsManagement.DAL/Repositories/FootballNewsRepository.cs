using Euro2024NewsManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euro2024NewsManagement.DAL.Repositories
{
    public class FootballNewsRepository
    {
        private Euro2024NewsManagementDbContext _context;

        public List<FootballNews> GetAllFootballNews()
        {
            _context = new();
            return _context.FootballNews.ToList();
        }


    }
}
