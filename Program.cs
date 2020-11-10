using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AdressBook
{
    class Program
    {
        class AdressBook
        {
            public string nameofperson, adressofperson, mailofperson, numberofperson;
            public AdressBook(string name, string adress, string mail, string number)
            {
                nameofperson = name;
                adressofperson = adress;
                mailofperson = mail;
                numberofperson = number;
            }
        }
        static void Main(string[] args)
        {
            List<AdressBook> person = new List<AdressBook>();

            string fileName = @"C:\Users\elin1\adressbok.txt";

            using (StreamReader file = new StreamReader(fileName))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] words = line.Split('#');

                }
                file.Close();

            }
            Console.WriteLine("Addressboken");
            Console.WriteLine("-------------------");
            for (int i = 0; i < person.Count(); i++)
            {
                if (person[i] != null)
                {
                    Console.WriteLine("{0,-10}{1,-20}{2,-30}{3,-40}",
                                      person[i].nameofperson, person[i].adressofperson, person[i].numberofperson, person[i].mailofperson);
                }
            }

            Console.WriteLine("Välkommen till adressboken!");
            Console.WriteLine("Skriv 'sluta' för att sluta!");
            string command;

            Random rand = new Random();
            do
            {
                Console.Write("> ");
                command = Console.ReadLine();
                if (command == "sluta")
                {
                    Console.WriteLine("Hej då! Tryck på en tangent för att avsluta programmet. ");
                }
                else if (command == "lägg in")
                {
                    Console.Write("Ange ett namn: ");
                    string name = Console.ReadLine();
                    Console.Write($"Ange en adress för {name}: ");
                    string adress = Console.ReadLine();
                    Console.Write($"Ange ett telefonnummer för {name}: ");
                    string number = Console.ReadLine();
                    Console.Write($"Ange en mailadress för {name}: ");
                    string mail = Console.ReadLine();
                    Console.WriteLine($"{name}  {adress} {number} {mail}");
                    person.Add(new AdressBook(name, adress, mail, number));
                }
                else if (command == "spara")
                {
                    using (StreamWriter writer = new StreamWriter(fileName))
                    {
                        for (int i = 0; i < person.Count(); i++)
                        {
                            writer.WriteLine("{0} {1} {2} {3}", person[i].nameofperson, person[i].adressofperson, person[i].numberofperson, person[i].mailofperson);
                        }
                    }
                }
                else if (command == "ta bort")
                {
                    Console.WriteLine("Vilken person vill du ta bort?: ");
                    string name = Console.ReadLine();
                    for (int i = 0; i < person.Count(); i++)
                    {
                        if (name == person[i].nameofperson)
                        {
                            Console.WriteLine($"hittade {name} på index {i}");
                            person.RemoveAt(i);
                        }
                    }
                }
                else if (command == "visa")
                {
                    Console.WriteLine("Adressboken!");
                    Console.WriteLine("-------------------");
                    for (int i = 0; i < person.Count(); i++)
                    {
                        if (person[i] != null)
                        {
                            Console.WriteLine("{0,-10}{1,-20}{2,-30}{3,-40}",
                                              person[i].nameofperson, person[i].adressofperson, person[i].numberofperson, person[i].mailofperson);
                        }
                    }
                    Console.WriteLine("-------------------");
                }
                else
                {
                    Console.WriteLine($"Okänt kommando: {command}");
                }
            } while (command != "sluta");
            Console.ReadKey();
        }
    }
}
