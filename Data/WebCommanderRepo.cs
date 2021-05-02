using System.Collections.Generic;
using WebCommand.Models;

namespace webcommand.Data
{
    public interface WebCommanderRepo
    {
        bool SaveChanges();
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);
        void DeleteCommand(Command cmd);
    }

}