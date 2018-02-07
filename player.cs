using System;
using System.Collections.Generic;

namespace magic_game {
    public class Player {
        public string name;
        public int health;
        public int black_mana;
        public Deck deck;
        public List<Card> played_lands;
        private List<Card> hand;
        public List<Creature> played_creatures;
        // public Player target;

        public Player (string Humanname) {
            Random rand = new Random ();
            name = Humanname;
            health = 20;
            deck = new Deck ();
            hand = deck.Draw5 ();
            black_mana = 0;
        }

        public void startTurn (Player target) {
            // this.target = target;
            hand.Add (deck.Draw ());
            black_mana = played_lands.Count;
            display (played_lands);
            display (played_creatures);
            display (hand);
            turnOptions (target);

        }
        public void turnOptions (Player target) {
            bool validChoice = false;
            while (!validChoice) {
                Console.WriteLine ("What would you like to do? (Select by number.)\n1. Play a card from your hand.\n2. Attack {0}.\n3. Display cards.\n4. End turn.\n", target.name);
                string input = Console.ReadLine (); //? i forget if this displays twice

                if (input == "1") {
                    playCard(target);
                } else if (input == "2") {
                    attack (target);
                } else if (input == "3") {
                    displayOptions(target);
                } else if (input == "4") {
                    Console.WriteLine ("Ending turn... [{0}]'s turn.\n", target.name);
                    validChoice = true;
                } else {
                    Console.WriteLine ("Invalid input. Please try again.\n");
                }
            }
        }
        public void display (List<Card> cards) {
            foreach (Card card in cards) {
                Console.WriteLine ("--- [{0}] ---\nType: {1} | Color: {2} | Cost: {3}", card.name, card.type, card.color, card.cost);
                Creature maybeCreature = card as Creature;
                if (maybeCreature != null) {
                    Console.WriteLine ("Attack: {0} | Defense: {1}", maybeCreature.attack, maybeCreature.defense);
                } else if (card.type == "spell") {
                    // spell stuff
                    // spells: (draw) # of cards (mod) att/def (damage) damage
                }
            }
        }

        public void display (List<Creature> cards, string condition) {
            if (condition == "available") {
                foreach (Creature card in cards) {
                    if (card.tapped) {
                        Console.WriteLine ("--- [{0}] ---\nType: {1} | Color: {2} | Cost: {3}", card.name, card.type, card.color, card.cost);
                        Console.WriteLine ("Attack: {0} | Defense: {1}", card.attack, card.defense);
                    }
                }
            }
        }

        // public void display (Player target) {
        //     display (target.played_lands);
        //     display (target.played_creatures);
        // }

        public void attack (Player target) {
            this.display (played_creatures, "available");
            System.Console.WriteLine ("Which creature would you like to attack with?");
            string inputLine = Console.ReadLine ();
            int x = 0;
            if (Int32.TryParse (inputLine, out x)) {
                if (x > played_creatures.Count - 1) {
                    System.Console.WriteLine ("Creature index out of range!");
                    this.attack (target);
                } else {
                    target.defend (target, this, played_creatures[x] as Creature, x);
                }
            } else {
                System.Console.WriteLine ("Input was not an integer!");
                this.attack (target);
            }
        }

        public object defend (Player me, Player attacker, Creature attacking_creature, int attackIdx) {
            this.display (played_creatures, "available");
            System.Console.WriteLine ("Which creature would you like to defend with?");
            System.Console.WriteLine ("input index or none");
            string inputLine = Console.ReadLine ();
            if (inputLine == "none") {
                return attacking_creature.battle (this, attacker);
            }
            int x = 0;
            if (Int32.TryParse (inputLine, out x)) {
                if (!attacking_creature[x].tapped) {
                    System.Console.WriteLine ("Creature has already defended!");
                    return this.defend (me, attacker, attacking_creature, attackIdx);
                }
                if (x > played_creatures.Count - 1) {
                    System.Console.WriteLine ("Creature index out of range!");
                    return this.defend (me, attacker, attacking_creature, attackIdx);
                } else {
                    return attacking_creature.battle (this, attacker, attackIdx, x, played_creatures[x]);
                }
            } else {
                System.Console.WriteLine ("Input was not an integer!");
                return this.defend (me, attacker, attacking_creature, attackIdx);
            }
        }
    }
}