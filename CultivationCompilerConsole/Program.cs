using CultivationCompiler.Processors;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivationCompilerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            var cultivationCompilerConsoleManager = new CultivationCompilerConsoleManager();

            var title = @"
    ___                  _____                                
   /   | ___  _________ / ___/________  ____  ___  _______  __
  / /| |/ _ \/ ___/ __ \\__ \/ ___/ _ \/ __ \/ _ \/ ___/ / / /
 / ___ /  __/ /  / /_/ /__/ / /__/  __/ / / /  __/ /  / /_/ / 
/_/  |_\___/_/   \____/____/\___/\___/_/ /_/\___/_/   \__, /  
   ______      ____  _             __  _             /____/   
  / ____/_  __/ / /_(_)   ______ _/ /_(_)___  ____            
 / /   / / / / / __/ / | / / __ `/ __/ / __ \/ __ \           
/ /___/ /_/ / / /_/ /| |/ / /_/ / /_/ / /_/ / / / /           
\____/\__,_/_/\__/_/ |___/\__,_/\__/_/\____/_/ /_/            
   ______                      _ __                           
  / ____/___  ____ ___  ____  (_) /__  _____                  
 / /   / __ \/ __ `__ \/ __ \/ / / _ \/ ___/                  
/ /___/ /_/ / / / / / / /_/ / / /  __/ /                      
\____/\____/_/ /_/ /_/ .___/_/_/\___/_/                       
                    /_/                           

By Nick Hoddinott
Copyright (c) 2019
";


            Console.WriteLine(title);
            Console.WriteLine("");


            if (args.Length == 0)
            {
                Console.WriteLine("Usage: CultivationCompilerConsole.exe C:\\PathTo\\Project.xml");
            }
            else
            {
                var projectFilename = args[0];
                cultivationCompilerConsoleManager.Start(projectFilename);

            }



            Console.ReadLine();

        }


    }
}
