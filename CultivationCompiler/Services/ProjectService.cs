using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CultivationCompiler.Models;

namespace CultivationCompiler.Services
{
    public class ProjectService
    {
        public Project LoadProject(string filePath)
        {
            Project project = new Project();
            XmlSerializer serializer = new XmlSerializer(typeof(Project));

            using (StreamReader reader = new StreamReader(filePath))
            {
                project = (Project)serializer.Deserialize(reader);
                reader.Close();
            }

            serializer = null;
            return project;

        }

    }
}
