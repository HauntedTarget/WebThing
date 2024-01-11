namespace WebThing.Models
{
    public class Movie
    {
        private static int nextID = 0;
        public int? ID { get; set; } = nextID++;

        public string Title { get; set; }
        public int? Year { get; set; }
        public float? Rating { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public Movie() { }

        public Movie(string title, int year, float rating) 
        {
            Title = title;
            Year = year;
            Rating = rating;
        }

        public Movie(string title, int year, float rating, DateTime dateTime)
        {
            Title = title;
            Year = year;
            Rating = rating;
            ReleaseDate = dateTime;
        }
    }
}
