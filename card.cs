using System;
using System.Collections.Generic;
using System.Linq;

namespace magic_game
{
    public abstract class Card{
        public int cost;
        public String color;
        public String type;

        public String name;
        protected Card(){
            color = "black";

        }
    }
}