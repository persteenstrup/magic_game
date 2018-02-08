using System;

namespace magic_game
{
    public class DamageSpell : Spell{
        
        public int damage; 
        
        public DamageSpell(int damage,int cost,String name){
            this.damage = damage;
            this.color = "black";
            this.name = name;
            this.spellType= "damage";
            this.type = "spell";
            this.cost = cost;
        }   
        public void use(Object victim){
            if(victim is Creature){
                Creature victim1 = victim as Creature;
            victim1.defense -= this.damage;
            //discard
            }else{
                Player Victim1 = victim as Player;
                Victim1.health -= this.damage;
                //discard
            }
        }
    }
}