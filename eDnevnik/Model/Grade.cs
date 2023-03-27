using eDnevnik.Serializer;

namespace eDnevnik.Model
{
    public class Grade : ISerializable
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
        public int GradeValue{ get; set; }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            SubjectId = Convert.ToInt32(values[1]);
            StudentId = Convert.ToInt32(values[2]);
        }

        public string[] ToCSV()
        {
            string[] csvValues = { Id.ToString(), SubjectId.ToString(), StudentId.ToString() };
            return csvValues;
        }
    }
}
