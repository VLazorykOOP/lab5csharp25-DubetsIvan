using System;
using System.Collections.Generic;

struct BuyerStruct
{
    public string Surname;
    public string Name;
    public string Patronymic;
    public string Address;
    public string Phone;
    public string Card;

    public BuyerStruct(string surname, string name, string patronymic, string address, string phone, string card)
    {
        Surname = surname;          
        Name = name;
        Patronymic = patronymic;
        Address = address;
        Phone = phone;
        Card = card;
    }
}

record BuyerRecord(string Surname, string Name, string Patronumic, string Address, string Phone, string Card);

class Program_4
{
    public static void Main()
    {
        Console.WriteLine("Оберiть варiант реалiзацiї:");
        Console.WriteLine("1 - Структура (struct)");
        Console.WriteLine("2 - Кортежi (Tuple)");
        Console.WriteLine("3 - Записи (record)");

        int choise = int.Parse(Console.ReadLine());

        switch(choise)
        {
            case 1:
                UseStructs();
                break;
            case 2:
                UseTuples();
                break;
            case 3:
                UseRecords();
                break;
            default:
                Console.WriteLine("Error!");
                break;
        }
    }

    static void UseStructs()
    {
        List<BuyerStruct> buyers = new List<BuyerStruct>
        {
            new BuyerStruct("Дубець", "Iван", "Русланович", "Топорiвцi", "1234567890", "1111-2222-3333-4444"),
            new BuyerStruct("Вiтвiцький", "Павло", "Степанович", "Топорiвцi", "1230984567", "5555-7777-8888-9999"),
            new BuyerStruct("Сохолотоцький", "Микола", "Васильович", "Топорiвцi", "1029384756", "0000-1111-2222-3333")
        };

        ModifyList(buyers);

        Console.WriteLine("Структури: ");
        PrintList(buyers);
    }

    static void UseTuples()
    {
        List<Tuple<string, string, string, string, string, string>> buyers = new List<Tuple<string, string, string, string, string, string>>
        {
            Tuple.Create("Дубець", "Iван", "Русланович", "Топорiвцi", "1234567890", "1111-2222-3333-4444"),
            Tuple.Create("Вiтвiцький", "Павло", "Степанович", "Топорiвцi", "1230984567", "5555-7777-8888-9999"),
            Tuple.Create("Сохолотоцький", "Микола", "Васильович", "Топорiвцi", "1029384756", "0000-1111-2222-3333")
        };

        ModifyList(buyers);

        Console.WriteLine("Кортежi: ");
        PrintList(buyers);
    }

    static void UseRecords()
    {
        List<BuyerRecord> buyers = new List<BuyerRecord>
    {
        new BuyerRecord("Дубець", "Iван", "Русланович", "Топорiвцi", "1234567890", "1111-2222-3333-4444"),
        new BuyerRecord("Вiтвiцький", "Павло", "Степанович", "Топорiвцi", "1230984567", "5555-7777-8888-9999"),
        new BuyerRecord("Сохолотоцький", "Микола", "Васильович", "Топорiвцi", "1029384756", "0000-1111-2222-3333")
    };

        ModifyList(buyers);

        Console.WriteLine("Записи: ");
        PrintList(buyers);
    }

    static void ModifyList<T>(List<T> buyers)
    {
        buyers.RemoveRange(0, 3);

        buyers.Add((T)Activator.CreateInstance(typeof(T), "Доби", "Бiба", "Iгорович", "Запорiжжя", "101010101", "1111-1111-1111-1111"));
        buyers.Add((T)Activator.CreateInstance(typeof(T), "Доби", "Боба", "Iгорович", "Вiнниця", "202020202", "2222-2222-2222-2222"));
        buyers.Add((T)Activator.CreateInstance(typeof(T), "Мото", "Мото", "Вiнеамiнович", "Полтава", "303030303", "3333-3333-3333-3333"));
    }

    static void PrintList<T>(List<T> buyers)
    {
        foreach (var buyer in buyers)
        {
            Console.WriteLine(buyer);
        }
    }
}