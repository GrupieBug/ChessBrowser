using System;
using System.Security.Policy;


namespace Chess {
    class ChessGame
    {
        public string Event { get; set; }
        public string Site { get; set; }
        public string Round { get; set; }
        public string White { get; set; }
        public string Black { get; set; }
        public int WhiteElo { get; set; }
        public int BlackElo { get; set; }
        public string EventDate { get; set; }
        string moves { get; set; }
        // Represents one instance of a Chess game, such as the players, round, result, moves, event name and date, ...

    }
}
