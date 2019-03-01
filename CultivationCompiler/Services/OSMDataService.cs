using CultivationCompiler.Common;
using CultivationCompiler.Models;
using CultivationCompiler.Models.OSM;
using CultivationCompiler.Parsers;
using CultivationCompiler.Processors;
using CultivationCompiler.Repositories;
using OsmSharp.Complete;
using OsmSharp.Streams;
using OsmSharp.Streams.Complete;
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

        //private List<Node> nodes;

        //public void ReadOSMData(string filename)
        //{
        //    nodes = new List<Node>();

        //    CultivationCompilerProcessor.Instance.RaiseEventLogMessage("This is in readosmdata", this, EventLogLevel.Debug);

        //    var dataRepository = new SqlLiteDataRepository();

        //    var databaseFilename = Path.ChangeExtension(filename, ".db");
        //    dataRepository.DBPath = databaseFilename;

        //    dataRepository.CreateSchema();

        //    int nodeCount = 0;

        //    using (XmlReader reader = XmlReader.Create(filename))
        //    {
        //        reader.MoveToContent();
        //        reader.Read();

        //        while (!reader.EOF && reader.ReadState == ReadState.Interactive)
        //        {
        //            if (reader.NodeType == XmlNodeType.Element && reader.Name == "node")
        //            {
        //                var matchedElement = (XElement) XNode.ReadFrom(reader);

        //                if (matchedElement != null)
        //                {
        //                    long nodeId = long.Parse(matchedElement.Attribute("id").Value);
        //                    string latitude = matchedElement.Attribute("lat").Value;
        //                    string longitude = matchedElement.Attribute("lat").Value;

        //                    Node node = new Node();
        //                    node.NodeId = nodeId;
        //                    node.Latitude = double.Parse(latitude);
        //                    node.Longitude = double.Parse(longitude);
        //                    node.Visible = true;

        //                    nodes.Add(node);

        //                    nodeCount++;


        //                    //CultivationCompilerProcessor.Instance.RaiseEventLogMessage("Writing node", this, EventLogLevel.Debug);

        //                    //dataRepository.CreateNode(node);

        //                }
        //            }
        //            else
        //                reader.Read();
        //        }

        //    }

        //    int asdf = 0;

        //}





        //public void ReadOSMDatax(string filename, OsmDataFormat format)
        //{
        //    CultivationCompilerProcessor.Instance.RaiseEventLogMessage("This is in readosmdata", this, EventLogLevel.Debug);

        //    using (var fileStream = File.OpenRead(filename))
        //    {
        //        // create source stream.
        //        OsmStreamSource source = null;

        //        switch (format)
        //        {
        //            case OsmDataFormat.Xml:
        //                source = new XmlOsmStreamSource(fileStream);

        //                break;
        //            case OsmDataFormat.Pbf:
        //                source = new PBFOsmStreamSource(fileStream);

        //                break;
        //        }


        //        // filter all powerlines and keep all nodes.
        //        //var filtered = from osmGeo in source
        //        //               where osmGeo.Type == OsmSharp.OsmGeoType.Node ||
        //        //                (osmGeo.Type == OsmSharp.OsmGeoType.Way && osmGeo.Tags != null && osmGeo.Tags.Contains("power", "line"))
        //        //               select osmGeo;

        //        // convert to complete stream.
        //        // WARNING: nodes that are partof powerlines will be kept in-memory.
        //        //          it's important to filter only the objects you need **before** 
        //        //          you convert to a complete stream otherwise all objects will 
        //        //          be kept in-memory.
        //        //var complete = source.ToComplete();

        //        //source.curr

        //        //List<ICompleteOsmGeo> completeFlat = source.ToComplete().ToList();

        //        //foreach (var element in completeFlat)
        //        //{
        //        //    Console.WriteLine(element.ToString());

        //        //    if (element.Type == OsmSharp.OsmGeoType.Way)
        //        //    {
        //        //        int asfd = 0;
        //        //    }

        //        //}

        //        //Console.ReadLine();

        //        //int i = 0;

        //        //source.MoveNext();


        //        //do
        //        //{

        //        //    var current = source.Current();

        //        //    if (current !=null)
        //        //    {
        //        //        Console.WriteLine(current.ToString());

        //        //        if (current.Type == OsmSharp.OsmGeoType.Way)
        //        //        {
        //        //            int asfd = 0;
        //        //        }
        //        //    }



        //        //    i++;
        //        //    source.MoveNext();
        //        //}
        //        //while (i < source.LongCount());


        //        //complete.MoveNext()

        //        //return complete;
        //    }
        //}
    }
}
