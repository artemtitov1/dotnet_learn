using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Building
{
    public class Factory : IReadable<Factory>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Factory() 
        {
            Id = 0;
            Name = string.Empty;
            Description = string.Empty;
        }


        public Factory(int id, string name, string description) 
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public List<Factory> Read(string filepath)
        {
            List<Factory> factories = new List<Factory>();

            using (StreamReader reader = new StreamReader(filepath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] attributes = line.Split('\t');
                    Factory factory = new Factory(Convert.ToInt32(attributes[0]), attributes[1], attributes[2]);
                    factories.Add(factory);
                }
            }
            return factories;
        }
    }
}
