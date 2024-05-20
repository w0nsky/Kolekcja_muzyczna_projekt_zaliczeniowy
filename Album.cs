using System;

namespace AlbumMuzyczny
{
    public class Song
    {
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public List<string> Performers { get; set; }
        public string Composer { get; set; }
        public int TrackNumber { get; set; }
    }

    public class Disc
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public TimeSpan Duration { get; set; }
        public List<Song> Songs { get; set; }
        public List<string> Performers { get; set; }
        public int DiscNumber { get; set; }
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
                type = Console.ReadLine();

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
        public void AddDisc()
        {
            Disc discToAdd = AddingDisc();
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
    }
}
