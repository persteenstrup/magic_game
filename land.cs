using System;
using System.Collections.Generic;

namespace magic_game
{
    public class Land: Card {

        public Land() :base() {
            cost = 0;
            type = "land";
        }

        public overide void play(Player me, Player target) {
            me.played_lands.add(this);
            me.black_mana ++;
        }
    }
}