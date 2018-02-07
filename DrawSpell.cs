using System;
using System.Collections.Generic;
using System.Linq;

namespace magic_game
{
    public class DrawSpell : Spell{
        
        public int numberOfCards; 
        
        public DrawSpell(int numberOfCards, int cost, String name){
            this.numberOfCards = numberOfCards;
            this.cost = cost;
            this.color = "black";
            this.name =name;
            this.spellType = "draw";
            this.type = "spell";
        }   
        public void use(Player player){
            for(var i = 0; i <= this.numberOfCards;i++){
                player.deck.Draw();
            }
        }
    }
}