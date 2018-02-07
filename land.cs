using System;
using System.Collections.Generic;

namespace magic_game
{
    public class Land: Card {

        public Land() :base() {
            cost = 0;
            type = "land";
        }

        public override void play(Player me, Player target) {
            me.played_lands.Add(this);
            me.black_mana ++;
        }
    }
}