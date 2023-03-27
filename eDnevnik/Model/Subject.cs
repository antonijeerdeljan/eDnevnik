using eDnevnik.Serializer;

namespace eDnevnik.Model
{
    public class Subject : ISerializable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Subject()
        {
            
        }

        public Subject(string name)
        {
            Name = name;
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Name = values[1];
        }

        public string[] ToCSV()
        {
            string[] csvValues = { Id.ToString(), Name };
            return csvValues;
        }

        public override string ToString()
        {
            return Name;
        }
    
    }
}
