using System;

class Place
{
    public string Name { get; set; }
    public string Country { get; set; }

    public Place()
    {
        Name = "Невiдоме мiсце";
        Country = "Невiдома країна";
        Console.WriteLine("Викликано конструктор Place без параметрiв");
    }

    public Place(string name, string country)
    {
        Name = name;
        Country = country;
        Console.WriteLine("Викликано конструктор Place з параметрами");
    }

    ~Place()
    {
        Console.WriteLine("Знищено об'єкт Place");
    }

    public virtual void Show()
    {
        Console.WriteLine($"Мiсце: {Name}, Країна: {Country}");
    }
}

class Region : Place
{
    public int Population { get; set; }

    public Region() : base()
    {
        Population = 0;
        Console.WriteLine("Викликано конструктор Region без параметрiв");
    }

    public Region(string name, string country, int population) : base(name, country)
    {
        Population = population;
        Console.WriteLine("Викликано конструктор Region з параметрами");
    }

    ~Region()
    {
        Console.WriteLine("Знищено об'єкт Region");
    }

    public override void Show()
    {
        Console.WriteLine($"Область: {Name}, Країна: {Country}, Населення: {Population}");
    }
}

class City : Region
{
    public bool IsCapital { get; set; }

    public City() : base()
    {
        IsCapital = false;
        Console.WriteLine("Викликано конструктор City без параметрiв");
    }

    public City(string name, string country, int population, bool isCapital) : base(name, country, population)
    {
        IsCapital = isCapital;
        Console.WriteLine("Викликано конструктор City з параметрами");
    }

    ~City()
    {
        Console.WriteLine("Знищено об'єкт City");
    }

    public override void Show()
    {
        Console.WriteLine($"Мiсто: {Name}, Країна: {Country}, Населення: {Population}, Столиця: {(IsCapital ? "Так" : "Нi")}");
    }
}

class Megapolis : City
{
    public int Skyscrapers { get; set; }

    public Megapolis() : base()
    {
        Skyscrapers = 0;
        Console.WriteLine("Викликано конструктор Megapolis без параметрiв");
    }

    public Megapolis(string name, string country, int population, bool isCapital, int skyscrapers)
        : base(name, country, population, isCapital)
    {
        Skyscrapers = skyscrapers;
        Console.WriteLine("Викликано конструктор Megapolis з параметрами");
    }

    ~Megapolis()
    {
        Console.WriteLine("Знищено об'єкт Megapolis");
    }

    public override void Show()
    {
        Console.WriteLine($"Мегаполiс: {Name}, Країна: {Country}, Населення: {Population}, Столиця: {(IsCapital ? "Так" : "Нi")}, Хмарочоси: {Skyscrapers}");
    }
}

class Program
{
    static void Main1()
    {
        Place place = new Place("Парк", "Україна");
        place.Show();

        Region region = new Region("Київська область", "Україна", 1800000);
        region.Show();

        City city = new City("Київ", "Україна", 2900000, true);
        city.Show();

        Megapolis megapolis = new Megapolis("Нью-Йорк", "США", 8400000, false, 300);
        megapolis.Show();
    }
}
