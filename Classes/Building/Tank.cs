using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Building
{
    public class Tank : IReadable<Tank>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Volume { get; set; }
        public int MaxVolume { get; set; }
        public int UnitId { get; set; }

        public Tank()
        {
            Id = 0;
            Name = string.Empty;
            Description = string.Empty;
            Volume = 0;
            MaxVolume = 0;
            UnitId = -1;
        }

        public Tank(int id, string name, string description, int volume, int maxVolume, int unitId)
        {
            Id = id;
            Name = name;
            Description = description;
            Volume = volume;
            MaxVolume = maxVolume;
            UnitId = unitId;
        }

        public List<Tank> Read(string filepath)
        {
            List<Tank> tanks = new List<Tank>();

            using (StreamReader reader = new StreamReader(filepath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] attributes = line.Split('\t');
                    Tank tank = new Tank(Convert.ToInt32(attributes[0]), attributes[1],
                        attributes[2], Convert.ToInt32(attributes[3]), Convert.ToInt32(attributes[4]), Convert.ToInt32(attributes[5]));
                    tanks.Add(tank);
                }
            }
            return tanks;
        }
    }
}
