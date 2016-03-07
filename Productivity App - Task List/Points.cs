using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdApp
{
    public class Points
    {
        public int _score { get; set; }

        private int AddPoints(int points)
        {
            _score += points;
            return _score;
        }
    }

}
