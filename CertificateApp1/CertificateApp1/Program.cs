
using CertificateApp1;
using System.Data;

namespace CertificateApp1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Beauty Salon rating app!");

            IService service = null;
            while (service == null)
            {
                Console.WriteLine("Select data recording system:");
                Console.WriteLine("1. File");
                Console.WriteLine("2. Memory");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    service = new ServiceInFile("Beauty Salon", "Mariola");
                }
                else if (choice == "2")
                {
                    service = new ServiceInMemory("Beauty Salon", "Mariola");
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please try again..");
                }
            }

            service.PointAdded += EmployeeGraded;

            void EmployeeGraded(object project, EventArgs sender)
            {
                Console.WriteLine("New rating added!");
            }

            Console.WriteLine("*********************************************");
            Console.WriteLine("Enter ratings for individual treatments:");
            Console.WriteLine("*********************************************");


            while (true)
            {
                Console.WriteLine("Select the type of procedure to evaluate: 1 - Makeup, 2 - Nails, 3 - Hairstyle (q - end)");
                string treatmentChoice = Console.ReadLine();

                if (treatmentChoice.ToLower() == "q")
                {
                    break;
                }

                string treatmentType = "";
                switch (treatmentChoice)
                {
                    case "1":
                        treatmentType = "Makeup";
                        break;
                    case "2":
                        treatmentType = "Nails";
                        break;
                    case "3":
                        treatmentType = "Hairstyle";
                        break;
                    default:
                        Console.WriteLine("Incorrect choice of treatment.");
                        continue;
                }

                Console.WriteLine($"Rate {treatmentType}:");

                float speed = GetRating("Speed");
                service.AddPoint(speed, treatmentType);

                float durability = GetRating("Durability");
                service.AddPoint(durability, treatmentType);

                float finalEffect = GetRating("Final Effect");
                service.AddPoint(finalEffect, treatmentType);


                Console.WriteLine("Statistics:");


                var statistics = service.GetStatistics(treatmentType);
                Console.WriteLine($"{treatmentType}:");
                Console.WriteLine($"Średnia: {statistics.Average}");
                Console.WriteLine($"Minimum: {statistics.Min}");
                Console.WriteLine($"Maksimum: {statistics.Max}");
                Console.WriteLine($"Ocena literowa: {statistics.AverageLetter}");
            }
        }

        private static float GetRating(string category)
        {
            while (true)
            {
                Console.WriteLine($"Give a rating {category} (1-10):");
                if (float.TryParse(Console.ReadLine(), out float rating) && rating >= 1 && rating <= 10)
                {
                    return rating;
                }
                Console.WriteLine("Invalid rating. Please enter a number between 1-10.");
            }
        }
    }
}

