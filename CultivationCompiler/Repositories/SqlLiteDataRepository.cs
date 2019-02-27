using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Dapper;
using CultivationCompiler.Models.OSM;

namespace CultivationCompiler.Repositories
{

    public class SqlLiteDataRepository
    {
        public string DBPath { get; set; }

        public void CreateSchema()
        {
            using (var con = DbConnection())
            {
                con.Open();

                con.Execute(
                    @"create table File
                        (
                        FileId              INTEGER PRIMARY KEY AUTOINCREMENT,
                        DataType            TEXT,
                        Name                TEXT,
                        MinLatitude         REAL,
                        MinLongitude        REAL,
                        MaxLongitude        REAL,
                        MaxLatitude         REAL,
                        FileTimestamp       TEXT,
                        CreatedTimestamp    TEXT
                        )");

                con.Execute(
                    @"create table Node
                        (
                        NodeId              INTEGER PRIMARY KEY,
                        Latitude            REAL,
                        Longitude           REAL,
                        Visible             INTEGER
                        )");

                // OSM Tables
                con.Execute(
                    @"create table Way
                        (
                        WayId               INTEGER PRIMARY KEY
                        )");

                con.Execute(
                    @"create table Tag
                        (
                        TagId              INTEGER PRIMARY KEY AUTOINCREMENT,
                        Key                TEXT,
                        Value              TEXT
                        )");

                con.Execute(
                    @"create table WayNode
                        (
                        WayId               INTEGER,
                        NodeId              INTEGER,
                        PRIMARY KEY(WayId,NodeId)
                        )");

                con.Execute(
                    @"create table Relation
                        (
                        RelationId          INTEGER PRIMARY KEY
                        )");

                con.Execute(
                    @"create table NodeRelation
                        (
                        RelationId          INTEGER,
                        NodeId              INTEGER,
                        PRIMARY KEY(RelationId,NodeId)
                        )");

                con.Execute(
                    @"create table WayRelation
                        (
                        RelationId          INTEGER,
                        WayId               INTEGER,
                        PRIMARY KEY(RelationId,WayId)
                        )");

                con.Execute(
                    @"create table NodeTag
                        (
                        NodeId             INTEGER,
                        TagId              INTEGER,
                        PRIMARY KEY(NodeId,TagId)
                        )");


                con.Execute(
                    @"create table WayTag
                        (
                        WayId              INTEGER,
                        TagId              INTEGER,
                        PRIMARY KEY(WayId,TagId)
                        )");

                con.Execute(
                    @"create table RelationTag
                        (
                        RelationId         INTEGER,
                        TagId              INTEGER,
                        PRIMARY KEY(RelationId,TagId)
                        )");


                // GeoJson tables
                con.Execute(
                    @"create table Polygon
                        (
                        PolygonId           INTEGER PRIMARY KEY
                        )");

                con.Execute(
                    @"create table Coordinate
                        (
                        CoordinateId        INTEGER PRIMARY KEY AUTOINCREMENT,
                        Latitude            REAL,
                        Longitude           REAL
                        )");

                con.Execute(
                    @"create table PolygonCoordinate
                        (
                        PolygonId           INTEGER,
                        CoordinateId        INTEGER,
                        PRIMARY KEY(PolygonId,CoordinateId)
                        )");

                //con.Execute(@"CREATE UNIQUE INDEX ix_GridSquare_Name ON GridSquares (Name ASC);");
            }
        }

        public void BeginTransaction()
        {

        }

        public void CreateNode(Node node)
        {
            using (var con = DbConnection())
            {
                var query = @"INSERT INTO Node (NodeId, Latitude, Longitude, Visible) VALUES 
                            (@NodeId, @Latitude, @Longitude, @Visible);";

                con.Open();
                con.Query(query, node);
            }
        }

        private SQLiteConnection DbConnection()
        {
            return new SQLiteConnection("Data Source=" + DBPath);
        }

    }
}
