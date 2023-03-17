using System;
using System.Collections.Generic;
using ChessGame;

namespace Chess
{
    static class PgnReader
    {
        public PgnReader()
        {
        }

        public List<ChessGame> getGames(string path)
        {
            string[] readText = File.ReadAllLines(path);
            bool new_game = true;
            bool next_game = false;
            string moves = "";
            List<ChessGame> allGames = new List<ChessGame>();
            ChessGame game = new ChessGame();
            foreach (string s in readText)
            {
                if (new_game)
                {

                    if (s.StartsWith("[Event"))
                    {
                        
                        game.Event = getSubstring(s);
                    }
                    else if (s.StartsWith("[Site"){
                        game.Site = getSubstring(s);
                    }
                    else if (s.StartsWith("[Round"){
                        game.Round = getSubstring(s);
                    }
                    else if (s.StartsWith("[White"){
                        game.White = getSubstring(s);
                    }
                    else if (s.StartsWith("[Black"){
                        game.Black = getSubstring(s);
                    }
                    else if (s.StartsWith("[WhiteElo"){
                        game.WhiteElo = int (getSubstring(s));
                    }
                    else if (s.StartsWith("[BlackElo"){
                        game.BlackElo = int (getSubstring(s));
                    }
                    else if (s.StartsWith("[Result"){
                        string result = getSubstring(s);

                        if (result == "1/2-1/2")
                        {
                            game.Result = "D";
                        }
                        else if (result == "1-0")
                        {
                            game.Result = "W";
                        }
                        else if (result == "0-1")
                        {
                            game.Result = "B";
                        }
                    }
                    else if (s.StartsWith("[EventDate"){
                        game.EventDate = getSubstring(s);
                    }
                    else if (s == '\n')
                    {
                        new_game = false;
                    }
                }
                else
                {
                    if (!next_game)
                    {
                        if (s != '\n')
                        {
                            moves += s;
                        }
                        else
                        {
                            next_game = true;
                        }
                    }
                    else
                    {
                        allGames.Add(game);
                        new_game = true;
                        game = new ChessGame();
                        next_game = false;
                    }
                }
            }
            return allGames;
        }

        public string getSubstring(string s)
        {
            int startIndex = s.IndexOf('"');
            int endIndex = s.IndexOf('"', s.IndexOf('"') + 1);
            int length = endIndex - startIndex + 1;
            return s.Substring(startIndex, length);
        }
    }
}
