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
        public List<Card> played_creatures;
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
            display (played_creatures as List<Card>);
            display (hand);
            turnOptions (target);

        }
        public void turnOptions (Player target) {
            bool validChoice = false;
            while (!validChoice) {
                Console.WriteLine ("What would you like to do? (Select by number.)\n1. Play a card from your hand.\n2. Attack {0}.\n3. Display cards.\n4. End turn.\n", target.name);
                string input = Console.ReadLine (); //? i forget if this displays twice

                if (input == "1") {
                    playCard (target);
                } else if (input == "2") {
                    attack (target);
                } else if (input == "3") {
                    displayOptions (target);
                } else if (input == "4") {
                    Console.WriteLine ("Ending turn... [{0}]'s turn.\n", target.name);
                    validChoice = true;
                } else {
                    Console.WriteLine ("Invalid input. Please try again.\n");
                }
            }
            endTurn(target);
        }

        public void endTurn(Player target){
            untap();
            target.untap();
        }

        public void untap(){
            foreach(Creature creature in played_creatures){
                creature.tapped = false;
            }
        }

        public void playCard (Player target){
            System.Console.WriteLine("Which card would you like to play?");
            System.Console.WriteLine("Please select a card index or input none");
            System.Console.WriteLine($"You have {black_mana} remaining");
            this.display(hand);
            string input = Console.ReadLine();
            if(input == "none"){
                this.turnOptions(target);
            } else{
                int x = 0;
                if (Int32.TryParse (input, out x)) {
                    if (x > hand.Count - 1) {
                        System.Console.WriteLine("Index out of range!");
                        playCard(target);
                    } else{
                        if(hand[x].cost < black_mana){
                            hand[x].play(this, target);
                            black_mana -= hand[x].cost;
                            hand.RemoveAt(x);
                        } else {
                            System.Console.WriteLine("You don't have enough mana!");
                            this.playCard(target);
                        }
                    }
                }
            }

        }
        public void display (List<Card> cards) {
            foreach (Card card in cards) {
                Console.WriteLine ("--- [{0}] ---\nType: {1} | Color: {2} | Cost: {3}", card.name, card.type, card.color, card.cost);
                if (card.type == "creature") {
                    Creature creature = card as Creature;
                    Console.WriteLine ("Attack: {0} | Defense: {1}", creature.attack, creature.defense);
                } else if (card.type == "spell") {
                    Spell creature = card as Spell;
                    // spell stuff
                    // spells: (draw) # of cards (mod) att/def (damage) damage
                } else if (card.type == "land") {
                    
                }
            }
        }

        public void display (List<Card> cards, string condition) {
            if (condition == "available") {
                foreach (Creature card in cards) {
                    if (card.tapped) {
                        Console.WriteLine ("--- [{0}] ---\nType: {1} | Color: {2} | Cost: {3}", card.name, card.type, card.color, card.cost);
                        Console.WriteLine ("Attack: {0} | Defense: {1}", card.attack, card.defense);
                    }
                }
            }
        }


        public void displayOptions (Player target) {
            Console.WriteLine ("Display:\n1. Your cards\n2. {0}'s cards\n3. Nevermind.\n");
            string input = Console.ReadLine ();
            if (input == "1") {
                display (played_lands);
                display (played_creatures);
                display (hand);
            } else if (input == "2") {
                display (target);
            } else if (input == "3") {
                continue;
            } else {
                Console.WriteLine ("Invalid input. Please try again.\n");
            }
        }

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

        public void defend (Player me, Player attacker, Creature attacking_creature, int attackIdx) {
            this.display (played_creatures, "available");
            System.Console.WriteLine ("Which creature would you like to defend with?");
            System.Console.WriteLine ("input index or none");
            string inputLine = Console.ReadLine ();
            if (inputLine == "none") {
                attacking_creature.battle (this, attacker);
                return;
            }
            int x = 0;
            if (Int32.TryParse (inputLine, out x)) {
                if (!(played_creatures[x] as Creature).tapped) {
                    System.Console.WriteLine ("Creature has already defended!");
                    this.defend (me, attacker, attacking_creature, attackIdx);
                    return;
                }
                if (x > played_creatures.Count - 1) {
                    System.Console.WriteLine ("Creature index out of range!");
                    this.defend (me, attacker, attacking_creature, attackIdx);
                    return;
                } else {
                    attacking_creature.battle (this, attacker, attackIdx, x, (played_creatures[x] as Creature));
                    return;
                }
            } else {
                System.Console.WriteLine ("Input was not an integer!");
                this.defend (me, attacker, attacking_creature, attackIdx);
                return;
            }
        }
    }
}