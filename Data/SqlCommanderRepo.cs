using System;
using System.Collections.Generic;
using System.Linq;
using WebCommand.Models;

namespace webcommand.Data
{
    public class SqlCommanderRepo : WebCommanderRepo
    {
        private readonly WebCommanderContext _context;

        public SqlCommanderRepo(WebCommanderContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command cmd)
        {
            if(cmd==null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Add(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if(cmd ==null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Remove(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
           return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(p=>p.id==id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()>=0);
        }

        public void UpdateCommand(Command command)
        {
            //nothing   
        }
    }
}