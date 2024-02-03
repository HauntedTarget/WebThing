using System.Reflection.Metadata.Ecma335;
using VideoGameLibrary.Interfaces;
using VideoGameLibrary.Models;

namespace VideoGameLibrary.Data
{
    public class GameLibraryDAL : IDataAccessLayer
    {
        private static List<Game> GameLibrary = new()
        {
            new Game("God of War: Ragnarok", Game.Platform.Playstation, "Action", 2022, "M", "https://assets-prd.ignimgs.com/2021/09/09/god-of-war-ragnarok-button-1631231879154.jpg?width=300&crop=1%3A1%2Csmart&auto=webp&dpr=2"),
            new Game("Halo Infinite", Game.Platform.XBox, "FPS", 2001, "M", "https://oyster.ignimgs.com/wordpress/stg.ign.com/2020/07/halo_infinite_keyart_primary_vertical-748a0db8be6c497d86f83ad76265060f-720x915.png?fit=bounds&width=1280&height=720&dpr=2"),
            new Game("Super Mario Galaxy", Game.Platform.Nintendo, "3rd Person Platformer", 2007, "E", "https://assets-prd.ignimgs.com/2020/09/04/super-mario-galaxy-1-button-1599258841533.jpg?width=300&crop=1%3A1%2Csmart&auto=webp&dpr=2"),
            new Game("Portal 2", Game.Platform.Steam, "Puzzle", 2011, "E 10+", "https://assets-prd.ignimgs.com/2021/12/08/portal2-1638924084230.jpg?width=300&crop=1%3A1%2Csmart&auto=webp&dpr=2"),
            new Game("Fortnite", Game.Platform.Epic, "Battle Royale", 2017, "T", "https://assets-prd.ignimgs.com/2023/06/09/fortnitewilds-1686353306240.jpg?width=300&crop=1%3A1%2Csmart&auto=webp&dpr=2")
        };

        public void AddGame(Game game)
        {
            GameLibrary.Add(game);
        }

        public Game? GetGame(int id)
        {
            return GameLibrary.FirstOrDefault(m => m.ID == id);
        }

        public IEnumerable<Game> GetGames()
        {
            return GameLibrary;
        }

        public void RemoveGame(int id)
        {
            Game? found = GetGame(id);
            if (found != null) GameLibrary.Remove(found);
        }

        void UpdateGame(Game game)
        {
            int index;
            index = GameLibrary.FindIndex(x => x.ID == game.ID);
            GameLibrary[index] = game;
        }

        void IDataAccessLayer.UpdateGame(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
