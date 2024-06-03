using System;
using System.Reflection;
using System.Text.Json;

namespace AlbumMuzyczny
{
    public struct Song
    {
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public List<string> Performers { get; set; }
        public string Composer { get; set; }
        public int TrackNumber { get; set; }

        public Song(string title, TimeSpan duration, List<string> performers, string composer, int trackNumber)
        {
            Title = title;
            Duration = duration;
            Performers = performers ?? new List<string>();
            Composer = composer;
            TrackNumber = trackNumber;
        }
    }

    public struct Disc
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public TimeSpan Duration { get; set; }
        public List<Song> Songs { get; set; }
        public List<string> Performers { get; set; }
        public int DiscNumber { get; set; }

        public Disc(string title, string type, TimeSpan duration, List<Song> songs, List<string> performers, int discNumber)
        {
            Title = title;
            Type = type;
            Duration = duration;
            Songs = songs ?? new List<Song>();
            Performers = performers ?? new List<string>();
            DiscNumber = discNumber;
        }
    }

    public class MusicCollection
    {
        public List<Disc> Discs { get; set; }

        public MusicCollection()
        {
            Discs = new List<Disc>();
        }
        public Disc AddingDisc()
        {
            Console.WriteLine("Podaj tytuł płyty");
            string title = Console.ReadLine();

            string type;
            do
            {
                Console.WriteLine("Podaj typ płyty (CD / DVD):");
                type = Console.ReadLine().ToUpper();

                if (type != "CD" && type != "DVD")
                {
                    Console.WriteLine("Błędny typ płyty. Wprowadź 'CD' lub 'DVD'.");
                }
            }
            while (type != "CD" && type != "DVD");

            List<Song> songList = new List<Song>();
            Console.WriteLine("Dodawanie piosenek:");
            string input;
            do
            {
                Song song = new Song();

                Console.WriteLine("Podaj tytuł piosenki:");
                song.Title = Console.ReadLine();

                Console.WriteLine("Podaj czas trwania piosenki (w formacie HH:mm:ss):");
                string durationInput = Console.ReadLine();
                if (TimeSpan.TryParse(durationInput, out TimeSpan duration))
                {
                    song.Duration = duration;
                }
                else
                {
                    Console.WriteLine("Błędny format czasu. Użyj formatu HH:mm:ss.");
                    continue; // Kontynuuj pętlę bez dodawania błędnie wprowadzonej piosenki
                }

                Console.WriteLine("Podaj wykonawców (naciśnij 'k' aby zakończyć):");
                song.Performers = new List<string>();
                string performerInput;
                do
                {
                    performerInput = Console.ReadLine();
                    if (performerInput.ToLower() != "k")
                    {
                        song.Performers.Add(performerInput);
                    }
                }
                while (performerInput.ToLower() != "k");

                Console.WriteLine("Podaj kompozytora:");
                song.Composer = Console.ReadLine();

                Console.WriteLine("Podaj numer utworu na płycie:");
                song.TrackNumber = Convert.ToInt32(Console.ReadLine());

                songList.Add(song);

                Console.WriteLine("Czy chcesz dodać kolejną piosenkę? (t/n)");

            } while (Console.ReadLine().ToLower() == "t");

            TimeSpan totalDuration = TimeSpan.Zero;
            foreach (var song in songList)
            {
                totalDuration += song.Duration;
            }

            List<string> performers = new List<string>();
            foreach (var song in songList)
            {

                foreach (var performer in song.Performers)
                {

                    if (!performers.Contains(performer))
                    {
                        performers.Add(performer);
                    }
                }
            }

            Console.WriteLine("Podaj numer albumu: ");
            int discNumber = Convert.ToInt32(Console.ReadLine());
            Disc disc = new Disc
            {
                Title = title,
                Type = type,
                Duration = totalDuration,
                Songs = songList,
                Performers = performers,
                DiscNumber = discNumber
            };

            return disc;



        }
        public void AddDisc(Disc discToAdd)
        {
            Discs.Add(discToAdd);
        }

        public void DisplayAllDiscs()
        {
            foreach (Disc disc in Discs)
            {
                Console.WriteLine(disc.Title);
            }
            Console.ReadKey();
        }

        // Zapis
        public void SaveCollectionToJson(string fileName)
        {
            string jsonString = JsonSerializer.Serialize(Discs);
            File.WriteAllText(fileName, jsonString);
            Console.WriteLine("Kolekcja zapisana do pliku JSON.");
        }

        //Odczyt
        public void LoadCollectionFromJson(string fileName)
        {
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                Discs = JsonSerializer.Deserialize<List<Disc>>(jsonString);
                Console.WriteLine("Kolekcja wczytana z pliku JSON.");
            }
            else
            {
                Console.WriteLine("Plik JSON nie istnieje.");
            }
        }

        //Szczegółowe informacje na temat płyty 
        public void DisplayInformationDisc() {
            Console.WriteLine("Podaj tytuł płyty: ");
            string whichTitle = Console.ReadLine().ToLower();

            bool found = false;

            foreach (Disc disc in Discs)
            {
                if(disc.Title.ToLower() == whichTitle)
                {
                    Console.Clear();
                    Console.WriteLine($"Tytuł płyty : {disc.Title} \nTyp płyty : {disc.Type}");
                    Console.WriteLine($"Czas łączny trwania utworów : {disc.Duration}");
                    Console.WriteLine("Spis utworów na płycie");
                    foreach(Song song in disc.Songs)
                    {
                        Console.WriteLine($"\t{song.TrackNumber}.{song.Title}");
                    }
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.Clear();
                Console.WriteLine($"Nie znaleziono płyty o nazwie {whichTitle}");
            }
            Console.ReadKey();
        }
        //Wyświetlenie wszystkich wykonawców na płycie 
        public void showPerformersOnAlbum()
        {
            Console.WriteLine("Podaj tytuł płyty: ");
            string whichTitle = Console.ReadLine().ToLower();
            
            bool found = false;

            foreach (Disc disc in Discs)
            {
                if (disc.Title.ToLower() == whichTitle)
                {
                    Console.Clear();
                    HashSet<string> uniquePerformers = new HashSet<string>();

                    foreach (Song song in disc.Songs)
                    {
                        foreach (string performer in song.Performers)
                        {
                            uniquePerformers.Add(performer);
                        }
                    }
                    Console.WriteLine($"Wykonawcy na płycie {disc.Title}");
                    foreach( string performer in uniquePerformers)
                    {
                        Console.WriteLine($"\t-{performer}");
                    }
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.Clear();
                Console.WriteLine($"Nie znaleziono płyty o nazwie {whichTitle}");
            }
            Console.ReadKey();
        }

        //Wyświetlenie szczegółowych informacji o płycie
        public void DisplaySongDetailsOnAlbum() {
            Console.WriteLine("Podaj tytuł płyty: ");
            string whichTitle = Console.ReadLine().ToLower();
            bool foundSong = false;
            bool foundAlbum = false;

            foreach (Disc disc in Discs)
            {
                if (disc.Title.ToLower() == whichTitle)
                {
                    Console.Clear();
                    Console.WriteLine($"Utwory na płycie: ");
                    foreach (Song song in disc.Songs)
                    {
                        Console.WriteLine($"\t{song.TrackNumber}.{song.Title}");
                    }
                    Console.WriteLine("Wybierz numer utworu o którym chcesz dowiedzieć się więcej");
                    int whichSong = Convert.ToInt16(Console.ReadLine());
                    Console.Clear();
                    foreach (Song song in disc.Songs)
                    {
                        if (song.TrackNumber == whichSong) {
                            Console.WriteLine($"\tTytuł Utworu: '{song.TrackNumber}'");
                            Console.WriteLine($"\tCzas trwania utworu: {song.Duration}");
                            Console.WriteLine($"\tSpis wykonawców utworu:");
                            int i = 1;
                            foreach(string performer in song.Performers)
                            {
                                Console.WriteLine($"\t\t{i}.{performer}");
                                i++;
                            }
                            Console.WriteLine($"\tKompozytor utworu: {song.Composer}");
                            foundSong = true;
                            break;
                        }   
                    }
                    if (!foundSong)
                    {
                        Console.Clear();
                        Console.WriteLine($"Nie znaleziono utworu o numerze {whichSong}");
                    }
                    foundAlbum = true;
                    break;
                }
            }
            if (!foundAlbum)
            {
                Console.Clear();
                Console.WriteLine($"Nie znaleziono płyty o nazwie {whichTitle}");
            }
            Console.ReadKey();
        }
    }
}
