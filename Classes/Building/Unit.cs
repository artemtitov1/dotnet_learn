using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Building
{
    public class Unit : IReadable<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FactoryId { get; set; }
        public Unit()
        {
            Id = 0;
            Name = string.Empty;
            Description = string.Empty;
            FactoryId = -1;
        }
        public Unit(int id, string name, string description, int factoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            FactoryId = factoryId;
        }
        public List<Unit> Read(string filepath)
        {
            List<Unit> units = new List<Unit>();

            using (StreamReader reader = new StreamReader(filepath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] attributes = line.Split('\t');
                    Unit unit = new Unit(Convert.ToInt32(attributes[0]), attributes[1],
                        attributes[2], Convert.ToInt32(attributes[3]));
                    units.Add(unit);
                }
            }
            return units;
        }
    }
}
