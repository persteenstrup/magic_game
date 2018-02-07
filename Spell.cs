using System;
using System.Collections.Generic;
using System.Linq;

namespace magic_game
{
    public abstract class Spell : Card{
         public String spellType;
         
        
        protected Spell(){
            
        }
        public override void play(Player me, Player target) {

        }  

    }
}