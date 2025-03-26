using System;
using System.Collections.Generic;

abstract class PhoneDirectory
{
    public abstract void DisplayInfo();
    public abstract bool MatchesSearch(string search);
}

class Person : PhoneDirectory
{
    public string LastName { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }

    public Person(string lastName, string address, string phoneNumber)
    {
        LastName = lastName;
        Address = address;
        PhoneNumber = phoneNumber;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Person: {LastName}, {Address}, {PhoneNumber}");
    }

    public override bool MatchesSearch(string search)
    {
        return LastName.Equals(search, StringComparison.OrdinalIgnoreCase);
    }
}

class Organization : PhoneDirectory
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Fax { get; set; }
    public string ContactPerson { get; set; }

    public Organization(string name, string address, string phoneNumber, string fax, string contactPerson)
    {
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
        Fax = fax;
        ContactPerson = contactPerson;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Organization: {Name}, {Address}, {PhoneNumber}, {Fax}, Contact: {ContactPerson}");
    }

    public override bool MatchesSearch(string search)
    {
        return Name.Equals(search, StringComparison.OrdinalIgnoreCase);
    }
}

class Friend : Person
{
    public DateTime BirthDate { get; set; }

    public Friend(string lastName, string address, string phoneNumber, DateTime birthDate)
        : base(lastName, address, phoneNumber)
    {
        BirthDate = birthDate;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Friend: {LastName}, {Address}, {PhoneNumber}, Birthdate: {BirthDate:yyyy-MM-dd}");
    }
}

class Program
{
    static void Main()
    {
        List<PhoneDirectory> directory = new List<PhoneDirectory>
        {
            new Person("Романенко", "Циганська 52", "1234567890"),
            new Organization("ННiФТКН", "Рiвненська 14", "0372547173", "3717452730", "Шеф"),
            new Friend("Сохолотоцький", "Лiсова 25", "555-9876", new DateTime(2006, 10, 24))
        };

        Console.WriteLine("Каталог:");
        foreach (var entry in directory)
        {
            entry.DisplayInfo();
        }

        Console.WriteLine("\nВведiть прiзвище:");
        string search = Console.ReadLine();
        Console.WriteLine("Пошук:");
        foreach (var entry in directory)
        {
            if (entry.MatchesSearch(search))
            {
                entry.DisplayInfo();
            }
        }
    }
}