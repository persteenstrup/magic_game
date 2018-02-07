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
        }   
        public void use(Object victim){
            victim.health -= this.damage;
        }
    }
}