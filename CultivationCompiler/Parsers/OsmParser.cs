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
        private long? currentNodeIndex;
        private long? currentWayIndex;
        private long? currentRelationIndex;

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
            reader.MoveToAttribute("minlat");
            double minLat = double.Parse(reader.Value);

            reader.MoveToAttribute("minlon");
            double minLon = double.Parse(reader.Value);

            reader.MoveToAttribute("maxlat");
            double maxLat = double.Parse(reader.Value);

            reader.MoveToAttribute("maxlon");
            double maxLon = double.Parse(reader.Value);

            var bounds = new Bounds();
            bounds.MinLat = minLat;
            bounds.MinLon = minLon;
            bounds.MaxLat = maxLat;
            bounds.MaxLon = maxLon;

            osmData.Bounds = bounds;

        }

        private void ParseTag(XmlReader reader, OsmData osmData)
        {
            reader.MoveToAttribute("k");
            string key = reader.Value;

            reader.MoveToAttribute("v");
            string value = reader.Value;

            var tag = new Tag(key, value);

            if (this.currentNodeIndex.HasValue)
            {
                osmData.Nodes[this.currentNodeIndex.Value]?.Tags.Add(tag);
            }
            else if (this.currentRelationIndex.HasValue )
            {
                osmData.Relations[this.currentRelationIndex.Value]?.Tags.Add(tag);
            }
            else if (this.currentWayIndex.HasValue)
            {
                osmData.Ways[this.currentWayIndex.Value]?.Tags.Add(tag);
            }
        }

        private void ParseWay(XmlReader reader, OsmData osmData)
        {
            this.currentNodeIndex = null;
            this.currentRelationIndex = null;

            reader.MoveToAttribute("id");
            long wayId = long.Parse(reader.Value);

            var way = new Way();
            way.WayId = wayId;

            osmData.Ways.Add(way.WayId, way);
            this.currentWayIndex = way.WayId;
        }

        private void ParseRelation(XmlReader reader, OsmData osmData)
        {
            this.currentNodeIndex = null;
            this.currentWayIndex = null;


            reader.MoveToAttribute("id");
            long relationId = long.Parse(reader.Value);

            var relation = new Relation();
            relation.RelationId = relationId;

            osmData.Relations.Add(relation.RelationId, relation);
            this.currentRelationIndex = relation.RelationId;

        }

        private void ParseMember(XmlReader reader, OsmData osmData)
        {
            if (this.currentRelationIndex.HasValue)
            {
                reader.MoveToAttribute("type");
                string type = reader.Value;

                reader.MoveToAttribute("ref");
                long refId = long.Parse(reader.Value);

                reader.MoveToAttribute("role");
                string role = reader.Value;

                var member = new Member();
                member.Ref = refId;
                member.Role = role;
                member.Type = type;

                osmData.Relations[this.currentRelationIndex.Value]?.Members.Add(member);
            }



        }

        private void ParseNd(XmlReader reader, OsmData osmData)
        {
            if (currentWayIndex.HasValue)
            {
                reader.MoveToAttribute("ref");
                long nodeReference = long.Parse(reader.Value);

                osmData.Ways[this.currentWayIndex.Value]?.NodeReferences.Add(nodeReference);

            }
        }

        private void ParseNode(XmlReader reader, OsmData osmData)
        {
            this.currentRelationIndex = null;
            this.currentNodeIndex = null;

            reader.MoveToAttribute("id");
            long nodeId = long.Parse(reader.Value);

            reader.MoveToAttribute("lat");
            string latitude = reader.Value;

            reader.MoveToAttribute("lon");
            string longitude = reader.Value;

            Node node = new Node();
            node.NodeId = nodeId;
            node.Latitude = double.Parse(latitude);
            node.Longitude = double.Parse(longitude);
            node.Visible = true;

            osmData.Nodes.Add(node.NodeId, node);
            this.currentNodeIndex = node.NodeId;

        }

    }
}
