using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapGame
{
    class Card
    {
        private int id { get; set; }
        
        public Card(int id)
        {
            this.id = id;
        }

        public int getId()
        {
            return id;
        }

        public void setId(int newId)
        {
            id = newId;
        }
    }
}
