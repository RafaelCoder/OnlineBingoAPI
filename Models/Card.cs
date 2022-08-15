using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OnlineBingoAPI.Models
{
    public class Card
    {
        public int ReferenceId { get; set; }
        public IList<Number> Numbers { get; set; }

        public Card()
        {
            Numbers = new List<Number>();
        }

        private bool NumberExists(int num) => Numbers.Any(n => n.Num == num);

        public void GenerateNumbers()
        {
            Numbers.Clear();

            Random random = new Random();

            for(int i = 1; i <= 25; i++)
            {
                int rng = 0;
                while(true)
                {
                    rng = random.Next(1, 99);
                    if (!NumberExists(rng))
                        break;
                }
                Numbers.Add(new Number(rng));
            }
        }

        public void SortNumbers()
        {
            List<Number> copy = new List<Number>();
            foreach(Number number in Numbers)
                copy.Add(new Number(number.Num));

            Numbers.Clear();

            Number del = null;

            while(copy.Count > 0)
            {
                int min = 999;
                foreach(Number number in copy)
                {
                    if (number.Num < min)
                    {
                        min = number.Num;
                        del = number;
                    }
                }
                if (del != null)
                {
                    Numbers.Add(new Number(del.Num));
                    copy.Remove(del);
                }
            }
        }

    }
}
