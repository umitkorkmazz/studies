using DapperApp.Library1.Models;
using DapperApp.Library1.Queries;
using System;

namespace DapperApp.ConsoleUI
{
    internal class Program
    {
        static PersonQueries personQueries = new PersonQueries();

        static void Main(string[] args)
        {
            //https://github.com/btkacademy/csharp-basic
            //https://github.com/btkacademy/design-patterns

            Console.WriteLine("Liste");
            Console.WriteLine("create");
            Console.WriteLine("update");
            Console.WriteLine("delete");
            Console.WriteLine("filiter");

            Console.Write("Yapılcak işlemi seçiniz : ");
            string choose = Console.ReadLine();
            Console.Clear();
            switch (choose)
            {
                case "create":
                    CreatePerson();
                    break;
                case "update":
                    Console.WriteLine("Kişi Listesi");
                    WritePersonList();
                    UpdatePerson();
                    Console.ReadLine();
                    Console.Clear();
                    WritePersonList();
                    break;
                case "delete":
                    Console.WriteLine("Kişi Listesi");
                    WritePersonList();
                    DeletePerson();
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "Liste":
                    WritePersonList();
                    break;
                case "filiter":
                    Console.WriteLine("Kişi Listesi");
                    WritePersonList();
                    FiliterPersons();                  
                    break;
            }
        }

        static void CreatePerson()
        {
            Person person = new Person();

            Console.Write("Adı = ");
            person.Name = Console.ReadLine();
            Console.Write("Soyadı = ");
            person.Surname = Console.ReadLine();

            personQueries.CreatePerson(person);
            Console.WriteLine("Kayıt eklendi id = {0}", person.Id);
        }
        static void WritePersonList()
        {
            var persons = personQueries.GetPersons();

            foreach (var person in persons)
            {
                Console.WriteLine("Id = {0}, Adı = {1}, Soyad = {2}",
                    person.Id,
                    person.Name,
                    person.Surname);
            }
        }
        static void UpdatePerson()
        {
            Console.Write("Güncellenicek kişinin Id'sini girin : ");
            int newId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Kişinin yeni adını gir : ");
            string newName = Console.ReadLine();
            Console.Write("Kişinin yeni soyadını gir : ");
            string newSurame = Console.ReadLine();
            personQueries.UpdatePerson(newId, newName, newSurame);
            Console.WriteLine("Kayıt güncellendi id = {0}", newId);

        }
        static void DeletePerson()
        {
            Console.Write("Silinecek kişinin Id'sini girin : ");
            int deleteId = Convert.ToInt32(Console.ReadLine());
            personQueries.DeletePerson(deleteId);
            Console.WriteLine("Kayıt silindi id = {0}", deleteId);

        }
        static void FiliterPersons()
        {
            Console.Write("Filitrelenecek isim : ");
            string find = Console.ReadLine();
            var Person = personQueries.FilterPersons(find);

            foreach (var person in Person)
            {
                Console.WriteLine("Id = {0}, Adı = {1}, Soyad = {2}",
                    person.Id,
                    person.Name,
                    person.Surname);
            }

        }

        //Update, Delete methodları yazılacak
        //Filtreli listeleme yapılabilir (Adı x ile başlayanları listelesin gibi ...)
    }
}
