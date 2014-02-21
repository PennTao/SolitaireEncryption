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
        private  Tuple<char, char> J0; 
        private  Tuple<char, char> J1;
        public Deck(String deckfile)
        {
            cards = new LinkedList<Tuple<char, char>>();
            J0 = new Tuple<char, char>('J', '0');
            J1 = new Tuple<char, char>('J', '1');
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
        public int GetLoc(Tuple<char,char> node)
        {
            int idx = 0;
            LinkedListNode<Tuple<char, char>> runner;
            runner = cards.First;
            while (runner.Value != node)
            {
                idx++;
            }
            if (idx >= 54)
                return -1;
            return idx;
        }

        public int GenKeyStream()
        {
            
            LinkedListNode<Tuple<char, char>> idxJ0, idxJ1,temp,front,back;
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

            idxJ1 = cards.Find(J1);
            if (idxJ1.Next != null)
            {
                if (idxJ1.Next.Next != null)
                {
                    temp = idxJ1.Next.Next;
                    cards.Remove(idxJ1);
                    cards.AddAfter(temp, J1);
                }
                else
                {
                    cards.Remove(idxJ1);
                    cards.AddAfter(cards.First, J1);
                }
            }
            else 
            {
                cards.Remove(idxJ1);
                cards.AddAfter(cards.First.Next, J1);
            }

            if (GetLoc(J0) < GetLoc(J1))
            { 
            }




            return 0;
        }

    }
}
