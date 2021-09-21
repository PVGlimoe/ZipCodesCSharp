using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ZipCodes
{
    class Program
    {
        public static List<DanishZipCode> listOfZipCodes;
        static void Main(string[] args)
        {
            listOfZipCodes = GetDanishZipCodes();
           
            Console.WriteLine("Enter zip code");

            Console.WriteLine(UserInput());
            
        }

        public static string UserInput()
        {
            string city = "";
            bool correctFormat = false;

            while (!correctFormat)
            {
  
                string userZipCode = Console.ReadLine().ToString();
                var c = listOfZipCodes.Where(x => x.ZipCode == userZipCode).FirstOrDefault();
                if (c != null)
                {
                    city = c.City;
                    correctFormat = true;
                } else
                {
                    Console.WriteLine("Faulty Input, try again!");
                }   
            }
            return city;
        }

        public static List<DanishZipCode> GetDanishZipCodes()
        {

            List<DanishZipCode> listOfZipCodes = new List<DanishZipCode>();
            using (StreamReader streamReader = new StreamReader(@"C:\csvFiles\zipCodes\danske-postnumre-byer-ny.csv"))
            {

                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (line.Contains("postnummer")) continue;
                    string[] data = line.Split(';');
                    if (data[0].Equals("")) continue;

                    var zipCode = data[0];
                    var city = data[1];

                    DanishZipCode zip = new DanishZipCode(zipCode, city);
                    listOfZipCodes.Add(zip);
                }
            }
            return listOfZipCodes;
        }
    }

    public class DanishZipCode
    {

        public string ZipCode { get; set; }
        public string City { get; set; }

        public DanishZipCode(string zipCode, string city)
        {
            ZipCode = zipCode;
            City = city;

        }
    }
}
