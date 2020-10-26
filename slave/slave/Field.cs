using System;
using System.Collections.Generic;

namespace slave
{
    class Field
    {
        public List<Player> players;
        private string lastcard;
        private readonly Deck deck;


        public Field(Deck deck)
        {
            players = new List<Player>();
            this.deck = deck;
        }
        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public string GetLatestCard()
        {
            return lastcard;
        }

        public void Play()
        {
        start:
            Intro();
            CardForPlayers();
            //CheckStatus();
            Gameplay();
            Console.WriteLine("Play Again? (y/n): ");
            if (Console.ReadLine().ToLower() == "y")
            {
                goto start;
            }
        }

        private void CardForPlayers()
        {
            for (int i = 0; i < 13; i++)
            {
                players.ForEach(player => player.AddCard(deck.Deal()));
            }
            players.ForEach(player => player.Cardlist.Sort());

        }
        public void Intro()
        {
            Console.WriteLine("============= WELCOME TO SLAVE GAME =============\n");

            for (int i = 0; i < 4; i++)
            {
                Console.Write("Enter Player {0} Name : ", i + 1);
                string Name = Console.ReadLine();
                AddPlayer(new Player(Name));
            }
        }
        public void Gameplay()
        {
            Console.Clear();
            Console.WriteLine("Latest Card : {0} \n\n\n", lastcard);
            players.ForEach(players => players.ShowTotalCard());
            Console.WriteLine("");
            Console.WriteLine(players[1]);
            Console.WriteLine("");
        }

        public void CheckStatus()
        {
            foreach (var item in players)
            {
                Console.WriteLine(item);
            }
        }
    }
}
