namespace eTickets.Models
{
    public class Artist_Painting
    {
        public int PaintingId { get; set; }
        public Painting Painting { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
