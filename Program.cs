using System;
using System.Collections.Generic;
using System.IO;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;

namespace MidTermProj
{
    class Program
    {
        static void Main(string[] args)
        {
             var dir = Combine(GetFolderPath(SpecialFolder.MyDocuments),"Code", "Chapter09", "WorkingWithFileSystems");
             CreateDirectory(dir);
 
            // define file paths
            string textFile = Combine(dir, "Countries.txt");
            List<Country> countryList = Country.readTxtFillList(textFile);
            Console.WriteLine("Is it done");
            Country.displayCountryList(countryList);
            Console.WriteLine("After soring the list");
            countryList.Sort();
            Country.displayCountryList(countryList);
            Country.findCountryName("Vietnam",countryList);
            Country x=new Country("Vietnam","",0);
            Country y=new Country("Vietnam","",0);
            WriteLine($"{x.Equals(y)}");
        }

    }
}
