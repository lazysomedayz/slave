using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace slave
{
    class Player
    {
        public List<Card> Cardlist { get; private set; }
        public bool Pass { get; set; }
        public string Name { get; set; }
        public int NumberOfCard => Cardlist.Count;

        public bool have3Club;
        public int position { get; set; }

        public Player(string name = "Unknown")
        {
            this.Name = name;
            Cardlist = new List<Card>();
            
        }
        public bool Have3Club
        {
            get
            {
                var CardListStr = new ArrayList();
                foreach (var item in Cardlist)
                {
                    CardListStr.Add(item.ToString());
                }
                if (CardListStr.Contains("3♣"))
                {
                    return have3Club = true;
                }
                return have3Club;
            }
            set
            {

            }
        }

        public bool WantToPass()
        {
            return Pass;
        }

        public void AddCard(Card card)
        {
            Cardlist.Add(card);         
        }

        public void DropCard(Card card)
        {
            Console.WriteLine("Which card do you want to drop in field? \n\n");
            Console.Write("Select the position of card in your hand. : ");
            int PositionOfCard = Int32.Parse(Console.ReadLine());
            Cardlist.RemoveAt(PositionOfCard);
        }

        public override string ToString()
        {
            string returntext = string.Format("==============================================================\n\nName : {0}\n", Name);
            returntext += string.Format("Cards :");
            Cardlist.ForEach(card => returntext += string.Format(" {0},", card.ToString()));
            returntext = returntext.TrimEnd(',');

            returntext += string.Format("\nYour position is : {0}", position);

            returntext += string.Format("\nHave 3♣? : {0}", Have3Club);

            returntext += string.Format("\n\n==============================================================");
            return returntext;
        }

        public void ShowTotalCard()
        {
            int TotalCard = Cardlist.Count;
            Console.WriteLine("{0}'s Card remaining: {1}",Name, TotalCard);
        }
    }
}
