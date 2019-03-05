using CultivationCompiler.Models;
using CultivationCompiler.Models.GeoJson;
using CultivationCompiler.Parsers;
using CultivationCompiler.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivationCompiler.Services
{
    public class GeoJsonDataService
    {
        private GeoJsonParser geoJsonParser;
        private GeoJsonData geoJsonData;

        private string databaseFilename;
        private SqlLiteDataRepository dataRepository;

        public GeoJsonDataService()
        {
            this.geoJsonParser = new GeoJsonParser();
        }

        public void ReadGeoJsonData(string filename, ImportMethod importMethod)
        {
            switch (importMethod)
            {
                case ImportMethod.Database:

                    //this.dataRepository = new SqlLiteDataRepository();
                    //this.databaseFilename = Path.ChangeExtension(filename, ".db");

                    //if (File.Exists(databaseFilename))
                    //{
                    //    File.Delete(databaseFilename);
                    //}

                    //dataRepository.DBPath = databaseFilename;

                    //dataRepository.CreateSchema();
                    //osmParser.ParseToDatabase(filename, databaseFilename);

                    break;
                case ImportMethod.Memory:

                    geoJsonData = geoJsonParser.ParseToMemory(filename);
                    break;
            }


        }

        //public Node NextNode()
        //{
        //    return null;
        //}

        //public Node FindNode(int nodeId)
        //{
        //    return null;
        //}
    }
}
