using CertificateApp1;

namespace CertificateApp1
{
    public abstract class ServiceBase : IService
    {
        public delegate void PointAddedDelegate(object sender, EventArgs args);
        public abstract event PointAddedDelegate PointAdded;
        public ServiceBase(string name, string contractor)
        {
            this.Name = name;
            this.Contractor = contractor;
        }

        public string Name { get; private set; }
        public string Contractor { get; private set; }


        public abstract void AddPoint(float point, string treatmentType);



        public virtual void AddPoint(string point)
        {
            if (float.TryParse(point, out float result))
            {
                this.AddPoint(result);
            }
            else
            {
                throw new Exception($"String '{point}' is not a valid float number");
            }
        }

        public void AddPoint(int point)
        {
            float pointAsFloat = point;
            this.AddPoint(pointAsFloat);
        }

        public void AddPoint(double point)
        {
            float pointAsFloat = (float)point;
            this.AddPoint(pointAsFloat);
        }

        public void AddPoint(char point)
        {
            switch (point)
            {
                case 'A':
                case 'a':
                    this.AddPoint(10);
                    break;
                case 'B':
                case 'b':
                    this.AddPoint(8);
                    break;
                case 'C':
                case 'c':
                    this.AddPoint(6);
                    break;
                case 'D':
                case 'd':
                    this.AddPoint(4);
                    break;
                case 'E':
                case 'e':
                    this.AddPoint(2);
                    break;
                default:
                    throw new Exception("Incorrect letter entered");
            }
        }
        public abstract Statistics GetStatistics(string treatmentType);
    }


}

