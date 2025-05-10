namespace ConPop
{
    //CITY_CODE;CITY_NAME;Y2010;Y2020;Y2030;Y2040;Y2050

    public class City
    {
        string Code, Name;
        List<int> nepesseglista;

        public City(string sor)
        {
            var data = sor.Split(";");
            Code = data[0];
            Name = data[1];
            nepesseglista.Add(Convert.ToInt32(data[2]));
            nepesseglista.Add(Convert.ToInt32(data[3]));
            nepesseglista.Add(Convert.ToInt32(data[4]));
            nepesseglista.Add(Convert.ToInt32(data[5]));
            nepesseglista.Add(Convert.ToInt32(data[6]));
        }

        public string Code1 { get => Code; set => Code = value; }
        public string Name1 { get => Name; set => Name = value; }
        public List<int> NepessegLista { get => nepesseglista; set => nepesseglista = value; }
    }
}