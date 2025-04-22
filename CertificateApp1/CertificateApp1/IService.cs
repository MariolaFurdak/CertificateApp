using CertificateApp1;
using static CertificateApp1.ServiceBase;

namespace CertificateApp1
{
    public interface IService
    {
        string Name { get; }
        string Contractor { get; }
        void AddPoint(float point, string treatmentType);
        void AddPoint(string point);
        void AddPoint(int point);
        void AddPoint(double point);
        void AddPoint(char point);
        Statistics GetStatistics(string treatmentType);

        event PointAddedDelegate PointAdded;
    }
}
