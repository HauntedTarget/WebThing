using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using System;
using System.ComponentModel.DataAnnotations;
using static VideoGameLibrary.Models.Game;

namespace VideoGameLibrary.Models
{
    public class Game
    {
        public enum PlatformType
        {
            Playstation = 0,
            XBox = 1,
            Nintendo = 2,
            Steam = 3,
            Epic = 4
        }

        [Key] [Required] public int ID { get; set; }
        public int? Year { get; set; }
        public string? GameTitle { get; set; }
        public string? Image { get; set; }
        public string? LoanerName { get; set; }
        public string? Genre { get; set; }
        public string? ERSBRating { get; set; }
        public DateTime? LoanDate { get; set; }
        [Required] public PlatformType Platform { get; set; }

        public Game()
        {

        }

        public Game(string title, PlatformType platform, string genre, int year, string rating, string image = "")
        {
            GameTitle = title;
            this.Platform = platform;
            Genre = genre;
            Year = year;
            ERSBRating = rating;
            Image = image;
        }

        public Game(string title, PlatformType platform, int year, string rating)
        {
            GameTitle = title;
            Year = year;
            ERSBRating = rating;
        }

        public Game(string title, PlatformType platform, int year, string rating, DateTime dateTime, string image = "")
        {
            GameTitle = title;
            Year = year;
            ERSBRating = rating;
            LoanDate = dateTime;
            Image = image;
        }

        public Game(string title, PlatformType platform, int year, string rating, string image = "")
        {
            GameTitle = title;
            Year = year;
            ERSBRating = rating;
            Image = image;
        }
    }
}
