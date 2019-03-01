using CultivationCompiler.Models.OSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CultivationCompiler.Parsers
{
    public class OsmParser
    {
        public OsmData ParseToMemory(string filename)
        {
            var osmData = new OsmData();
            Parse(filename, false, null, osmData);
            return osmData;
        }

        public void ParseToDatabase(string filename, string databaseFilename)
        {
            Parse(filename, true, databaseFilename, null);
        }

        private void Parse(string filename, bool parseToDatabase, string databaseFilename, OsmData osmData)
        {
            using (XmlReader reader = XmlReader.Create(filename))
            {
                reader.MoveToContent();
                reader.Read();

                while (!reader.EOF && reader.ReadState == ReadState.Interactive)
                {

                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        switch (reader.Name.ToLower())
                        {
                            case "bounds":
                                ParseBounds(reader, osmData);
                                break;

                            case "node":
                                ParseNode(reader, osmData);
                                break;

                            case "tag":
                                ParseTag(reader, osmData);
                                break;

                            case "way":
                                ParseWay(reader, osmData);
                                break;

                            case "nd":
                                ParseNd(reader, osmData);
                                break;

                            case "relation":
                                ParseRelation(reader, osmData);
                                break;

                            case "member":
                                ParseMember(reader, osmData);
                                break;
                        }

                        reader.Read();

                    }
                    else
                    {
                        reader.Read();
                    }
                }

            }
        }

        private void ParseBounds(XmlReader reader, OsmData osmData)
        {
        }

        private void ParseTag(XmlReader reader, OsmData osmData)
        {
        }

        private void ParseWay(XmlReader reader, OsmData osmData)
        {
        }

        private void ParseRelation(XmlReader reader, OsmData osmData)
        {
        }

        private void ParseMember(XmlReader reader, OsmData osmData)
        {
        }

        private void ParseNd(XmlReader reader, OsmData osmData)
        {
        }

        private void ParseNode(XmlReader reader, OsmData osmData)
        {
            var matchedElement = (XElement)XNode.ReadFrom(reader);

            if (matchedElement != null)
            {
                long nodeId = long.Parse(matchedElement.Attribute("id").Value);
                string latitude = matchedElement.Attribute("lat").Value;
                string longitude = matchedElement.Attribute("lat").Value;

                Node node = new Node();
                node.NodeId = nodeId;
                node.Latitude = double.Parse(latitude);
                node.Longitude = double.Parse(longitude);
                node.Visible = true;

                osmData.Nodes.Add(node.NodeId, node);
            }
        }

    }
}
