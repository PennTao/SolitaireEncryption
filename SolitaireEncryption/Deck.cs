using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SolitaireEncryption
{
    class Deck
    {
        private LinkedList<Tuple<char,char>> cards;
        public Deck(String deckfile)
        {

          
            try
            {
                StreamReader file = new StreamReader(deckfile);
                for (int i = 0; i < 54; i++)
                {
                    cards.AddLast(new Tuple<char, char>(file.ReadLine().Split(' ')[0][0], file.ReadLine().Split(' ')[1][0]));
                }
                file.Close();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        public int GenKeyStream()
        {
            var J0 = new Tuple<char, char>('J', '0');
            var J1 = new Tuple<char, char>('J', '1');
            LinkedListNode<Tuple<char, char>> idxJ0, idxJ1,temp;
            idxJ0 = cards.Find(J0);
            if (idxJ0.Next != null)
            {
                temp = idxJ0.Next;
                cards.Remove(idxJ0);
                cards.AddAfter(temp, J0);
            }
            else
            {
                cards.Remove(idxJ0);
                cards.AddAfter(cards.First, J0);
            }
            return 0;
        }

    }
}
