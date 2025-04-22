
using CertificateApp1;
using System.Diagnostics.Contracts;
using System.Xml.Linq;

namespace CertificateApp1
{
    public class ServiceInFile : ServiceBase
    {
        private const string fileName = "points.txt";
        private string fullFileName;

        public override event PointAddedDelegate PointAdded;
        public ServiceInFile(string name, string contractor)
            : base(name, contractor)
        {
        }

        public override void AddPoint(float point, string treatmentType)
        {
            if (point >= 0 && point <= 10)
            {
                var fullFileName = $"{Name}_{Contractor}_{fileName}";
                using (var writer = File.AppendText(fullFileName))
                {
                    writer.WriteLine(point);
                }

                if (PointAdded != null)
                {
                    PointAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("Incorrect point value was entered");
            }

        }

        public override Statistics GetStatistics(string treatmentType)
        {
            var pointsFromFile = this.ReadPointsFromFile();
            var statistics = new Statistics();

            foreach (var point in pointsFromFile)
            {
                statistics.AddPoint(point);
            }
            return statistics;

        }

        private List<float> ReadPointsFromFile()
        {
            var points = new List<float>();
            if (File.Exists(fullFileName))
            {
                using (var reader = new StreamReader(fullFileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (float.TryParse(line, out float number))
                        {
                            points.Add(number);
                        }
                    }
                }
            }
            return points;
        }

    }
}

