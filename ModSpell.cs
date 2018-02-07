using System;
using System.Collections.Generic;
using System.Linq;

namespace magic_game
{
    public class ModSpell : Spell{
        
        public int attackMod; 
        public int defenseMod; 
        
        public ModSpell(int attack, int defense, String name, int cost){
            this.attackMod = attack;
            this.defenseMod = defense;
            this.name = name;
            this.color = "black";
            this.spellType = "mod";
            this.cost = cost;
            this.type = "spell";
            
        }   
        public void use(Creature creature){
            creature.defense += this.defenseMod;
            creature.attack += this.attackMod;
            //discard
        }
    }
}