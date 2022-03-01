using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace cc_client_update
{
    class CommandLineOptions
    {
        [Option('o', "oldFolder", MetaValue = "FOLDER", Required = true, HelpText = "原client文件夹目录")]
        public string oldFolder { get; set; }

        [Option('n', "newFolder", MetaValue = "FOLDER", Required = false, HelpText = "新client文件夹目录")]
        public string newFolder { get; set; }


        [Option('c', "fullName", MetaValue = "NAME", Required = true, HelpText = "client运行fullName")]
        public String clientFullName { get; set; }

        [Option('u', "fullName", MetaValue = "NAME", Required = true, HelpText = "updateClient运行fullName")]
        public String updateClientFullName { get; set; }

    }
}

