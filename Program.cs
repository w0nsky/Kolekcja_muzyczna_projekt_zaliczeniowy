
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
            char c;

            do
            {
                c = Menu();
                switch (c)
                {
                    case 'a':
                    case 'A':
                        collection.AddDisc();
                        
                        break;
                    case 'b':
                    case 'B':
                        collection.DisplayAllDiscs();

                        break;
                    case 'c':
                    case 'C':
                        Console.WriteLine("Test gita");

                        break;
                    case 'd':
                    case 'D':

                        break;
                    case 'e':
                    case 'E':

                        break;
                    
                }
            }
            while (!(c == 'k' || c == 'K'));
        }
    }
}
