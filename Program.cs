namespace ConPop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //A kapott CSV állomány Európa nagyobb városainak a korábbi és a jövőbeli becsült népességszámait tartalmazza.
            // CITY_CODE;CITY_NAME;Y2010;Y2020;Y2030;Y2040;Y2050


            //todo: 1F Készítsen osztályt egy város adatainak tárolására! (City)
            //todo: 2F Készítsen (CityDataProvider) néven osztályt a városok adatainak kezelésére, ami a megadott (CitiesMethods) interfészt implementálja!

            //todo: Válaszoljon a következő kérdésekre a korábban létrehozott osztályok felhasználásával!

            //todo: 3F Hány város adatait tartalmazza a CSV fájl? (CityCount)
            //todo: 4F Melyik 10 város volt a legnépesebb 2020-ban? (Top10City)
            //todo: 5F Kérje be billentyűzetről egy város nevét! Ha nem létezik, akkor jelezze azt és kérje be újra! 
            //         Miután létező nevet adott meg, döntse el, hogy a város lakossága folyamatosan növekedett-e az évek alatt? (IsContinuousGrowing)
            //todo: 6F Írja (bigCities.CSV) fájlba a 2020-ban 1 millió főnél nagyobb népességgel rendelkező városokat! (SaveToCSV)
            //todo: 7F Írassa képernyőre azoknak a városoknak a nevét és népességváltozását, ahol 2050-ben kevesebben lesznek mint 2010-ben voltak!
            //todo:    A kiíratás népességcsökkenés szerint növevően rendezetten történjen! 
            //todo:    Tipp: Érdemes megfelelő metódussal vagy property-vel bővíteni az osztályt! (CityDataProvider)


            CityDataProvider provider = new CityDataProvider();

            provider.LoadFromCSV("cities.csv");


            Console.WriteLine("1.F: ");
            Console.Write(provider.CityCount());

            Console.WriteLine("2.F: ");
            foreach (var varos in provider.Top10City(2010))
            {
                Console.WriteLine(varos.Name1);
            }

            Console.WriteLine("3.F: ");
            // public static -> eléred a provideben a listat
            var bekert = "asgasdhjasfjhaikfjh";

            while (!CityDataProvider.Lista.Select(x => x.Name1).Distinct().Contains(bekert))
            {
                bekert = Console.ReadLine();
            }

            Console.WriteLine("6.F: ");
            provider.SaveToCSV("bigCities.CSV", CityDataProvider.Lista.Select(x => x).Where(x => x.NepessegLista[1] > 1000000).ToList());
            


        }
    }
}
