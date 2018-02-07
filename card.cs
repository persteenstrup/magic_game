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
<<<<<<< HEAD
        }

        public virtual void play(Player me, Player target) {  // with virtual in the parent function and override in the child function, it should run the child version of play when called on a generic "card" class
            // if (this.type == "land") {
            //     // Land landcard = this as Land;
            // }
            // if (this.type == "creature") {
            //     Creature creatureCard = this as Creature;
            //     creatureCard.play(me, target);
            // }
            // if (this.type == "spell") {
            //     Spell spellCard = this as Spell;
            //     spellCard.play(me, target);
            // }
=======
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
>>>>>>> 012a3e6735792399b255eacba4c7a1317d64a112
        }
    }
}