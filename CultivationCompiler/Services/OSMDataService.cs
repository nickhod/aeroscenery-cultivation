using CultivationCompiler.Common;
using CultivationCompiler.Models;
using CultivationCompiler.Models.OSM;
using CultivationCompiler.Parsers;
using CultivationCompiler.Processors;
using CultivationCompiler.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CultivationCompiler.Services
{
    public class OsmDataService
    {
        private OsmParser osmParser;
        private OsmData osmData;

        private string databaseFilename;
        private SqlLiteDataRepository dataRepository;

        public OsmDataService()
        {
            osmParser = new OsmParser();
        }

        public void ReadOSMData(string filename, ImportMethod importMethod)
        {
            switch (importMethod)
            {
                case ImportMethod.Database:

                    this.dataRepository = new SqlLiteDataRepository();
                    this.databaseFilename = Path.ChangeExtension(filename, ".db");

                    if (File.Exists(databaseFilename))
                    {
                        File.Delete(databaseFilename);
                    }

                    dataRepository.DBPath = databaseFilename;

                    dataRepository.CreateSchema();
                    osmParser.ParseToDatabase(filename, databaseFilename);

                    break;
                case ImportMethod.Memory:
                    osmData = osmParser.ParseToMemory(filename);
                    var asdf = "adf";
                    break;
            }


        }

        public Node NextNode()
        {
            return null;
        }

        public Node FindNode(int nodeId)
        {
            return null;
        }

    }
}
