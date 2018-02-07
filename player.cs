using System;
using System.Collections.Generic;

namespace consolegame {
    public class Player {
        public string name;
        public int health;
        private List<Card> hand;
        public Deck deck;
        public int black_mana;
        public List<Card> played_lands;
        public List<Card> played_creatures;
        // public Player target;

        public Player (string Humanname) {
            Random rand = new Random ();
            name = Humanname;
            health = 20;
            deck = new Deck ();
            hand = deck.draw5 ();
            black_mana = 0;
        }

        public void startTurn (Player target) {
            // this.target = target;
            hand.Add (deck.draw ());
            black_mana = played_lands.Count;
            display (played_lands);
            display (played_creatures);
            display (hand);
            //CW smth 
            turnOptions(target);

            string inputLine = Console.ReadLine ();
            // Switch 
            //2 play land
            //3 play creature
            //4 play spell
            //5 attack
            //6 display
            //7 show opposing player creatures??? 
            //8 endturn reset creature tapped

            //remove creature

        }

        public void attack (Player target) {
            this.display(played_creatures,"available");
            System.Console.WriteLine ("Which creature would you like to attack with?");
            string inputLine = Console.ReadLine ();
            int x = 0;
            if (Int32.TryParse (inputLine, out x)) {
                if (x > played_creatures.Count - 1) {
                    System.Console.WriteLine ("Creature index out of range!");
                    this.attack(target);
                } else {
                    target.defend(target,this,played_creatures[x] as Creature, x);
                }
            } else {
                System.Console.WriteLine ("Input was not an integer!");
                this.attack (target);
            }
        }

        public object defend(Player me, Player attacker, Creature attacking_creature, int attackIdx) {
            this.display(played_creatures,"available");
            System.Console.WriteLine ("Which creature would you like to defend with?");
            System.Console.WriteLine ("input index or none");
            string inputLine = Console.ReadLine ();
            if (inputLine == "none"){
                return attacking_creature.battle(this,attacker);
            }           
            int x = 0;
            if (Int32.TryParse (inputLine, out x)) {
                if(!attacking_creature[x].tapped) {
                    System.Console.WriteLine("Creature has already defended!");
                    return this.defend(me, attacker, attacking_creature,attackIdx);
                }       
                    if (x > played_creatures.Count - 1) {
                        System.Console.WriteLine ("Creature index out of range!");
                        return this.defend(me, attacker, attacking_creature,attackIdx);
                    } else {
                        return attacking_creature.battle(this,attacker,attackIdx,x,played_creatures[x]);
                    }
            } else {
                System.Console.WriteLine ("Input was not an integer!");
                return this.defend (me, attacker, attacking_creature,attackIdx);
            }
        }
    }
}