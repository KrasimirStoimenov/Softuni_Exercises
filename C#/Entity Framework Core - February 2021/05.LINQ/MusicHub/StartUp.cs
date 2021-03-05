namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportAlbumsInfo(context, 9));
            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var producerAlbums = context.Albums
                .Include(x => x.Songs)
                .Where(x => x.ProducerId == producerId)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    AlbumReleaseDate = a.ReleaseDate,
                    ProducerName = a.Producer.Name,
                    AlbumTotalPrice = a.Price,
                    AlbumSongs = a.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        Price = s.Price,
                        SongWriterName = s.Writer.Name
                    })
                    .OrderByDescending(s => s.SongName)
                    .ThenBy(s => s.SongWriterName)
                    .ToList()
                })
                .ToList()
                .OrderByDescending(x => x.AlbumTotalPrice);

            var sb = new StringBuilder();

            foreach (var album in producerAlbums)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}")
                    .AppendLine($"-ReleaseDate: {album.AlbumReleaseDate:MM/dd/yyyy}")
                    .AppendLine($"-ProducerName: {album.ProducerName}")
                    .AppendLine($"-Songs:");

                var counter = 1;

                foreach (var song in album.AlbumSongs)
                {
                    sb.AppendLine($"---#{counter++}")
                        .AppendLine($"---SongName: {song.SongName}")
                        .AppendLine($"---Price: {song.Price:F2}")
                        .AppendLine($"---Writer: {song.SongWriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {album.AlbumTotalPrice:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .Select(x => new
                {
                    SongName = x.Name,
                    WriterName = x.Writer.Name,
                    AlbumProducer = x.Album.Producer.Name,
                    Duration = x.Duration,
                    PerformerFullName = x.SongPerformers
                            .Select(p => p.Performer.FirstName + " " + p.Performer.LastName)
                            .FirstOrDefault()
                })
                .ToList()
                .Where(x => x.Duration.TotalSeconds > duration)
                .OrderBy(s => s.SongName)
                .ThenBy(w => w.WriterName)
                .ThenBy(p => p.PerformerFullName)
                .ToList();

            var sb = new StringBuilder();

            var counter = 1;
            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{counter++}")
                    .AppendLine($"---SongName: {song.SongName}")
                    .AppendLine($"---Writer: {song.WriterName}")
                    .AppendLine($"---Performer: {song.PerformerFullName}")
                    .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                    .AppendLine($"---Duration: {song.Duration.ToString("c")}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
