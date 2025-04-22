using CertificateApp1;

namespace CertificateApp1
{
    public class ServiceInMemory : ServiceBase
    {
        public override event PointAddedDelegate PointAdded;

        private List<float> points = new List<float>();
        public ServiceInMemory(string name, string contractor)
            : base(name, contractor)
        {
        }

        public override void AddPoint(float point, string treatmentType)
        {
            if (point >= 0 && point <= 10)
            {
                this.points.Add(point);
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
            var statistics = new Statistics();

            foreach (var point in this.points)
            {
                statistics.AddPoint(point);
            }
            return statistics;

        }
    }
}
