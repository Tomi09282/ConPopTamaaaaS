using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConPop
{
    public class CityDataProvider : ICityMethods
    {
       public static List<City> Lista = new List<City>();


        public int CityCount()
        {
            return Lista.Count();
        }

        public bool IsContinuousGrowing(List<int> populationDatas)
        {
            if (populationDatas.OrderBy(x => x) == populationDatas)
            {
                return true;
            }
            return false;



        }

        public void LoadFromCSV(string path)
        {
            StreamReader sr = new StreamReader("cities.csv");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                Lista.Add(new City(sr.ReadLine()));
            }

            // File.ReadAllLines(path).Select(x => x).ToList().ForEach(x => Lista.Add(new City(x))); //linq 1 sor


            /*
            var file = File.ReadLines(path);

            foreach (var sor in file)
            {
                Lista.Add(new City(sor));
            }
            */

        }

        public void SaveToCSV(string path, List<City> cities, string charCode = "UTF-8")
        {
            StreamWriter sw = new StreamWriter(path);

                sw.WriteLine("CITY_CODE;CITY_NAME;Y2010;Y2020;Y2030;Y2040;Y2050");
            foreach (City elem in cities)
            {
                sw.WriteLine($"{elem.Code1};{elem.Name1};{elem.NepessegLista[0]};{elem.NepessegLista[1]};{elem.NepessegLista[2]};{elem.NepessegLista[3]};{elem.NepessegLista[4]}");
            }

            //------------------------------------------------------------------------------------
            /*
            List<string> formazott = new List<string>();

            formazott.Add("CITY_CODE;CITY_NAME;Y2010;Y2020;Y2030;Y2040;Y2050");

            foreach (City elem in cities)
            {
                formazott.Add($"{elem.Code1};{elem.Name1};{elem.NepessegLista[0]};{elem.NepessegLista[1]};{elem.NepessegLista[2]};{elem.NepessegLista[3]};{elem.NepessegLista[4]}");
            }

            File.WriteAllLines(path, formazott, encoding: Encoding.GetEncoding(charCode));
            */
        }

        public List<City> Top10City(int year) // 2010 2020 2030 2040 2050

        // year.ToString()[2] 20'2'0 -> "2" 20'3'0 -> "3" (Nepesseg lista 3. eleme Y2030)

        //Nepesseglista: [521512,125125,125125,12512,125125]
        // RESP:         [2010 : ELso index | 2020 : Masodik index]
        {
            return Lista.OrderBy(x => x.NepessegLista[Convert.ToInt32(year.ToString()[2]) - 1]).Take(10).ToList();
        }
    }
}
