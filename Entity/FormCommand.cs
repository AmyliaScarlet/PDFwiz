using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFwiz.Entity
{
    public class FormCommand
    {
        private readonly FormCommandType _command;
        private readonly string _commandArgs;
        public FormCommand(FormCommandType command, string commandArgs) 
        { 
            _command = command;
            _commandArgs = commandArgs;
        }

        public FormCommandType FormCommandType => _command;
        public string CommandArgs => _commandArgs;


        public override bool Equals(object obj)
        {
            return obj is FormCommand command &&
                   _command == command._command &&
                   _commandArgs == command._commandArgs;
        }

        public override int GetHashCode()
        {
            int hashCode = 1236871729;
            hashCode = hashCode * -1521134295 + _command.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_commandArgs);
            return hashCode;
        }
    }


}
