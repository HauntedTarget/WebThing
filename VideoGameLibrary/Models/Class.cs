using System;
using static VideoGameLibrary.Models.Game;

namespace VideoGameLibrary.Models
{
    public class Game
    {
        public enum Platform
        {
            Playstation = 0,
            XBox = 1,
            Nintendo = 2,
            Steam = 3,
            Epic = 4
        }

        private static int nextID = 0;
        public int? ID { get; set; } = nextID++;
        public int? Year { get; set; }
        public string? GameTitle { get; set; }
        public string? Image { get; set; }
        public string? LoanerName { get; set; }
        public string? Genre { get; set; }
        public string? ERSBRating { get; set; }
        public DateTime? LoanDate { get; set; }
        public Platform platform { get; set; }

        public Game()
        {
        }

        public Game(string title, Platform platform, string genre, int year, string rating, string image = "")
        {
            GameTitle = title;
            this.platform = platform;
            Genre = genre;
            Year = year;
            ERSBRating = rating;
            Image = image;
        }

        public Game(string title, Platform platform, int year, string rating)
        {
            GameTitle = title;
            Year = year;
            ERSBRating = rating;
        }

        public Game(string title, Platform platform, int year, string rating, DateTime dateTime, string image = "")
        {
            GameTitle = title;
            Year = year;
            ERSBRating = rating;
            LoanDate = dateTime;
            Image = image;
        }

        public Game(string title, Platform platform, int year, string rating, string image = "")
        {
            GameTitle = title;
            Year = year;
            ERSBRating = rating;
            Image = image;
        }
    }
}
