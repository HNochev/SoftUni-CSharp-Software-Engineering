using System;

namespace _02._Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            int period = int.Parse(Console.ReadLine());
            int doctors = 7;
            int untretedPatients = 0;
            int treatedPatients = 0;
            int allPatients = 0;
            int counter = 0;
            for (int i = 0; i < period; i++)
            {
                int patients = int.Parse(Console.ReadLine());
                counter++;
                if (counter == 3)
                {
                    if (untretedPatients > treatedPatients)
                    {
                        doctors++;
                    }
                    counter = 0;
                }
                int difference = doctors - patients;
                if(difference<0)
                {
                    untretedPatients = untretedPatients + Math.Abs(difference);
                    treatedPatients = treatedPatients + doctors;
                }
                else
                {
                    treatedPatients = treatedPatients + patients;
                }
            }
            Console.WriteLine($"Treated patients: {treatedPatients}.");
            Console.WriteLine($"Untreated patients: {untretedPatients}.");

        }
    }
}
