using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;

namespace MidTermProj
{//
    public class Country: IComparable<Country>,IEquatable<Country>{
        private string name;
        private string continent;
        private long population;
        //public enum Fieldname {Name , Continent, Population}
    // 
        //constructor
        public Country(string Name = @"N/A", string Continent = @"N/A", long Population = 0)
        {
            name = Name;
            continent = Continent ;
            population = Population;
        }
        public string Name
        {
          get{return name;}
          set{name = value;}  
        }
        public string Continent
        {
          get{return continent;}
          set{continent = value;}  
        }
        public long Population
        {
          get{return population;}
          set{population = value;}  
        }
    //
    //
        public override string ToString()
        {
            return String.Format("{0,-45}{1,-10}{2,10:N0}", arg0:Name,arg1:Continent,arg2:Population);
        }

        public int CompareTo(Country other)
        {
            //throw new NotImplementedException();
            return name.CompareTo(other.name);
            
        }
        public int compare(Country c1, Country c2){
                string country1 = c1.Name; //obj.method
                string country2 = c2.Name;
                
                return country1.CompareTo(country2); 
            }
          
    // obj is Country country && name == country.name
        public override bool Equals(object obj)
        {
            return Equals(obj as Country);
        }
        public bool Equals(Country other){
            return name.Equals(other.name);

        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, continent, population);
        }
    public static void findCountryName(
        string cname,
        List<Country> countryList)
        {
        Country toFind = new Country(cname, "", 0);
        bool found = countryList.Contains(toFind);
        
        if(found){
            int k = countryList.IndexOf(toFind),
                l = countryList.LastIndexOf(toFind);
                
                countryList.Find(x => x.name.Contains(cname));
                Console.WriteLine("\nFind: Part where name contains \"Pakistan\": {0}",countryList.Find(x => x.name.Contains(cname)));
            
            /*if(k == l)
                Console.WriteLine("The only country found is {0}", countryList.get(k));
            else{
                for(int j = k; j <= l; j++)
                    if(countryList.get(j).equals(toFind))
                        System.out.printf("We find: %s at index %d", countryList.get(j), j);
            }*/
        }
    }
    public static  List<Country> readTxtFillList(string fileName)
        {
            int found = 0;   
           
            List<Country> countryList = new List<Country>();
            
            //bool fileExists = true;
            //bool fileEND = false;
            //FileReader fr = null;
            
            Console.WriteLine($"Does it exist? {File.Exists(fileName)}");
            
            Console.WriteLine("we are going to try to open the file"+ fileName);

           /*try
            {
            // Open the text file using a stream reader.
            using (var sr = new StreamReader(fileName))
            {
                // Read the stream as a string, and write the string to the console.
                Console.WriteLine(sr.ReadToEnd());
                Console.WriteLine($"70th lne Does it exist? {File.Exists(fileName)}");
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }*/
        if(File.Exists(fileName)){
 
            using (StreamReader sr = new StreamReader(fileName))
            {
            string line = string.Empty;
            //int position = line.IndexOf(":");
            
            
            while ((line = sr.ReadLine()) != null)
            {
                //Console.WriteLine("Its inside");
                               //string[] test = line.Split(",");


                    int position = line.IndexOf(": ");
                    found = line.IndexOf(":");
                    string Name=line.Substring(0,27).Trim();
                    string con =line.Substring(47,11).Trim();
                    string popl=(line.Substring(position+1));
                    int startIndex = line.IndexOf(popl);
                    int endIndex = line.LastIndexOf(popl);
                    int length = endIndex - startIndex + 1;
                    string substring1 = line.Substring(startIndex, endIndex + popl.Length - startIndex);
                    Console.WriteLine("Substring;       {0}", substring1); 

                    long pop = Int64.Parse(substring1);
                    countryList.Add(new Country(Name,con,pop));
                    
                    //Console.WriteLine("Its inside");
                   

                    //Console.WriteLine("Total nodes in myList are : " + countryList.Count);
                
            }
            
            //FileInfo fi = new FileInfo(fileName);
            //Console.WriteLine("File Size in Bytes: {0}", size);
            //Console.Writeline("{0} create a list of country succesfully! There {1} countries\n", fileName, countryList.size());
}
 
        }
        
            
            
            return countryList;
            
        }      
        public static void displayCountryList(List<Country> countrylist)
         {
            Console.WriteLine("At this moment we are displaying the country");
            foreach(Country i in countrylist){
                Console.WriteLine($"{i} ");
            }
        }

       
    }
    


}
