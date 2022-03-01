using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace cc_client_update
{
    class Program
    {
        private static string _oldFolder;
        private static string _newFolder;
        private static string _clientFullName;
        private static string _updateClientFullName;

        static void Main(string[] args)
        {

            var commandLineOptions = new CommandLineOptions();

            Parser.Default.ParseArguments<CommandLineOptions>(args).WithParsed(o =>
            {

                _oldFolder = o.oldFolder;
                _newFolder = o.newFolder;
                _clientFullName = o.clientFullName;
                _updateClientFullName = o.updateClientFullName;

            });

            var updateClient = new Update(_oldFolder, _newFolder, _clientFullName, _updateClientFullName);
            updateClient.DeleteAndUpdate();
        }
    }
}
