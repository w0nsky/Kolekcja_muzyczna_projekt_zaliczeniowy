
using System;
using System.Collections.Generic;
using System.Text;
using AlbumMuzyczny;

namespace TestAlbumu
{
    class Program
    {
        static char Menu()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("\n");
            //Napis wygenerowany przy pomocy https://patorjk.com/software/taag/#p=display&f=ANSI%20Regular&t=
            Console.WriteLine("██╗  ██╗ ██████╗ ██╗     ███████╗██╗  ██╗ ██████╗     ██╗ █████╗       ");
            Console.WriteLine("██║ ██╔╝██╔═══██╗██║     ██╔════╝██║ ██╔╝██╔════╝     ██║██╔══██╗      ");
            Console.WriteLine("█████╔╝ ██║   ██║██║     █████╗  █████╔╝ ██║          ██║███████║      ");
            Console.WriteLine("██╔═██╗ ██║   ██║██║     ██╔══╝  ██╔═██╗ ██║     ██   ██║██╔══██║      ");
            Console.WriteLine("██║  ██╗╚██████╔╝███████╗███████╗██║  ██╗╚██████╗╚█████╔╝██║  ██║      ");
            Console.WriteLine("╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚══════╝╚═╝  ╚═╝ ╚═════╝ ╚════╝ ╚═╝  ╚═╝      ");
            Console.WriteLine("                                                                       ");
            Console.WriteLine("███╗   ███╗██╗   ██╗███████╗██╗   ██╗ ██████╗███████╗███╗   ██╗ █████╗ ");
            Console.WriteLine("████╗ ████║██║   ██║╚══███╔╝╚██╗ ██╔╝██╔════╝╚══███╔╝████╗  ██║██╔══██╗");
            Console.WriteLine("██╔████╔██║██║   ██║  ███╔╝  ╚████╔╝ ██║       ███╔╝ ██╔██╗ ██║███████║");
            Console.WriteLine("██║╚██╔╝██║██║   ██║ ███╔╝    ╚██╔╝  ██║      ███╔╝  ██║╚██╗██║██╔══██║");
            Console.WriteLine("██║ ╚═╝ ██║╚██████╔╝███████╗   ██║   ╚██████╗███████╗██║ ╚████║██║  ██║");
            Console.WriteLine("╚═╝     ╚═╝ ╚═════╝ ╚══════╝   ╚═╝    ╚═════╝╚══════╝╚═╝  ╚═══╝╚═╝  ╚═╝");
            Console.WriteLine("                                                                       ");

            Console.WriteLine("\n\tA - Dodaj płytę do bazy danych");
            Console.WriteLine("\n\tB - Wyświetl wszystkie płyty");
            Console.WriteLine("\n\tC - Wyświetl sczegółowe informacje na temat płyty");
            Console.WriteLine("\n\tD - Wyświetl wykonawców");
            Console.WriteLine("\n\tE - Wyświetl szegółowe informacje na temat wybranego utworu z danej płyty");
            Console.WriteLine("\n\tK - Koniec");
            return Console.ReadKey(true).KeyChar;

        }
        static void Main(string[] args)
        {
            MusicCollection collection = new MusicCollection();
            string file_path = @"C:\c#\baza danych.json";
            char c;
            collection.LoadCollectionFromJson(file_path);
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
                        collection.DisplayAllDiscs();
                        break;
                    case 'c':
                    case 'C':
                        collection.DisplayInformationDisc();
                        break;
                    case 'd':
                    case 'D':
                        collection.showPerformersOnAlbum();

                        break;
                    case 'e':
                    case 'E':
                        collection.DisplaySongDetailsOnAlbum();
                        break;   
                }
            }
            while (!(c == 'k' || c == 'K'));
        }
    }
}
