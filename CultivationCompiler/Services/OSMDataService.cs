using CultivationCompiler.Common;
using CultivationCompiler.Models;
using CultivationCompiler.Processors;
using OsmSharp.Complete;
using OsmSharp.Streams;
using OsmSharp.Streams.Complete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivationCompiler.Services
{
    public class OSMDataService
    {

        public void ReadOSMData(string filename, OSMDataFormat format)
        {
            CultivationCompilerProcessor.Instance.RaiseEventLogMessage("This is in readosmdata", this, EventLogLevel.Debug);

            using (var fileStream = File.OpenRead(filename))
            {
                // create source stream.
                OsmStreamSource source = null;

                switch (format)
                {
                    case OSMDataFormat.Xml:
                        source = new XmlOsmStreamSource(fileStream);

                        break;
                    case OSMDataFormat.Pbf:
                        source = new PBFOsmStreamSource(fileStream);

                        break;
                }


                // filter all powerlines and keep all nodes.
                //var filtered = from osmGeo in source
                //               where osmGeo.Type == OsmSharp.OsmGeoType.Node ||
                //                (osmGeo.Type == OsmSharp.OsmGeoType.Way && osmGeo.Tags != null && osmGeo.Tags.Contains("power", "line"))
                //               select osmGeo;

                // convert to complete stream.
                // WARNING: nodes that are partof powerlines will be kept in-memory.
                //          it's important to filter only the objects you need **before** 
                //          you convert to a complete stream otherwise all objects will 
                //          be kept in-memory.
                //var complete = source.ToComplete();

                //source.curr

                List<ICompleteOsmGeo> completeFlat = source.ToComplete().ToList();

                //foreach (var element in completeFlat)
                //{
                //    Console.WriteLine(element.ToString());

                //    if (element.Type == OsmSharp.OsmGeoType.Way)
                //    {
                //        int asfd = 0;
                //    }

                //}

                //Console.ReadLine();

                int i = 0;

                source.MoveNext();


                do
                {

                    var current = source.Current();

                    if (current !=null)
                    {
                        Console.WriteLine(current.ToString());

                        if (current.Type == OsmSharp.OsmGeoType.Way)
                        {
                            int asfd = 0;
                        }
                    }



                    i++;
                    source.MoveNext();
                }
                while (i < source.LongCount());


                //complete.MoveNext()

                //return complete;
            }
        }
    }
}
