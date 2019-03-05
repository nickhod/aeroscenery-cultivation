using CultivationCompiler.Models.GeoJson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivationCompiler.Parsers
{
    public class GeoJsonParser
    {
        public GeoJsonData ParseToMemory(string filename)
        {
            var geoJsonData = new GeoJsonData();
            Parse(filename, false, null, geoJsonData);
            return geoJsonData;
        }

        public void ParseToDatabase(string filename, string databaseFilename)
        {
            Parse(filename, true, databaseFilename, null);
        }

        private void Parse(string filename, bool parseToDatabase, string databaseFilename, GeoJsonData geoJsonData)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (FileStream s = File.Open(filename, FileMode.Open))
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                while (reader.Read())
                {
                    // The first array in these MS building footprinnt GeoJson files should
                    // be the array we want to deserialize
                    if (reader.TokenType == JsonToken.StartArray)
                    {
                        while (reader.Read())
                        {
                            if (reader.TokenType == JsonToken.StartObject)
                            {
                                var tempObj = serializer.Deserialize<dynamic>(reader);

                                if (tempObj.geometry != null)
                                {
                                    var geometryJsonObj = tempObj.geometry;

                                    var feature = new Feature();
                                    var geometry = new Geometry();

                                    geometry.Type = (GeoJsonGeometryType)Enum.Parse(typeof(GeoJsonGeometryType), geometryJsonObj.type.Value);
                                    geometry.Coordinates = new List<Coordinate>();

                                    var coords = geometryJsonObj.coordinates.First;

                                    foreach (var obj in coords)
                                    {
                                        var lat = double.Parse(obj[0].Value.ToString());
                                        var lon = double.Parse(obj[1].Value.ToString());

                                        var coord = new Coordinate();
                                        coord.Lat = lat;
                                        coord.Lon = lon;

                                        geometry.Coordinates.Add(coord);
                                    }

                                    feature.Geometry = geometry;
                                    geoJsonData.Features.Add(feature);

                                }


                            }
                        }

                    }
                }
            }
        }

    }
}
