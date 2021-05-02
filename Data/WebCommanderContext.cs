using Microsoft.EntityFrameworkCore;
using WebCommand.Models;

namespace webcommand.Data
{

    public class WebCommanderContext : DbContext
    {
        public WebCommanderContext(DbContextOptions<WebCommanderContext> opt) :base(opt)
        {


        }

        public DbSet<Command> Commands { get; set; }

    }


}