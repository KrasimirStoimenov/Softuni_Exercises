using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models
{
    public class SongPerformer
    {
        /*SongPerformer
        •	SongId – Integer, Primary Key
        •	Song – the performer’s Song (required)
        •	PerformerId – Integer, Primary Key
        •	Performer – the song’s Performer (required)
        */

        public int SongId { get; set; }
        [Required]
        public Song Song { get; set; }

        public int PerformerId { get; set; }
        [Required]
        public Performer Performer { get; set; }
    }
}
