
using System;
using System.Collections.Generic;
using System.Text;
using AlbumMuzyczny;


// Zapisywanie kolekcji do pliku JSON
//collection.SaveCollectionToJson("baza danych.json");

// Wczytywanie kolekcji z pliku JSON
//collection.LoadCollectionFromJson("baza_danych.json");

namespace TestAlbumu
{
    class Program
    {
        static char Menu()
        {
            Console.Clear();
            Console.WriteLine("\n\t\tA - Dodaj płytę do bazy danych");
            Console.WriteLine("\n\t\tB - Wyświetl wszystkie płyty");
            Console.WriteLine("\n\t\tC - Wyświetl sczegółowe informacje na temat płyty");
            Console.WriteLine("\n\t\tD - Wyświetl wykonawców");
            Console.WriteLine("\n\t\tE - Wyświetl szegółowe informacje na temat wybranego utworu z danej płyty");
            Console.WriteLine("\n\t\tK - Koniec");
            return Console.ReadKey(true).KeyChar;

        }
        static void Main(string[] args)
        {
            MusicCollection collection = new MusicCollection();
            string file_path = @"C:\c#\baza danych.json";
            char c;

            do
            {
                c = Menu();
                switch (c)
                {
                    case 'a':
                    case 'A':
                        Disc newDisc = collection.AddingDisc();
                        collection.AddDisc(newDisc);
                        collection.SaveCollectionToJson(file_path);

                        break;
                    case 'b':
                    case 'B':
                        collection.LoadCollectionFromJson(file_path);
                        collection.DisplayAllDiscs();
  
                        break;
                    case 'c':
                    case 'C':
                        collection.LoadCollectionFromJson(file_path);
                        collection.DisplayInformationDisc();


                        break;
                    case 'd':
                    case 'D':
                        collection.LoadCollectionFromJson(file_path);
                        collection.showPerformersOnAlbum();

                        break;
                    case 'e':
                    case 'E':
                        collection.LoadCollectionFromJson(file_path);
                        collection.DisplaySongDetailsOnAlbum();

                        break;
                    
                }
            }
            while (!(c == 'k' || c == 'K'));
        }
    }
}
