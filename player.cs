using System;
using System.Collections.Generic;

namespace magic_game
{
    public class Player
    {
        public string name;
        public int health;
        public int black_mana;
        public Deck deck;
        public List<Card> played_lands;
        public List<Card> hand;
        public List<Card> played_creatures;
        // public Player target;

        public Player(string Humanname)
        {
            Random rand = new Random();
            name = Humanname;
            health = 20;
            deck = new Deck();
            hand = deck.Draw5();
            black_mana = 0;
        }

        public void startTurn(Player target)
        {
            // this.target = target;
            hand.Add(deck.Draw());
            black_mana = played_lands.Count;
            display(played_lands);
            display(played_creatures);
            display(hand);
            turnOptions(target);

        }
        public void turnOptions(Player target)
        {
            bool validChoice = false;
            while (!validChoice)
            {
                Console.WriteLine("What would you like to do? (Select by number.)\n1. Play a card from your hand.\n2. Attack {0}.\n3. Display cards.\n4. End turn.\n", target.name);
                string input = Console.ReadLine();

                if (input == "1")
                {
                    playCard(target);
                }
                else if (input == "2")
                {
                    attack(target);
                }
                else if (input == "3")
                {
                    displayOptions(target);
                }
                else if (input == "4")
                {
                    Console.WriteLine("Ending turn... [{0}]'s turn.\n", target.name);
                    validChoice = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.\n");
                }
            }
            endTurn(target);
        }

        public void endTurn(Player target)
        {
            untap();
            target.untap();
        }

        public void untap()
        {
            foreach (Creature creature in played_creatures)
            {
                creature.tapped = false;
            }
        }

        public void playCard(Player target)
        {
            Console.WriteLine($"You have {black_mana} remaining.\nWhich card would you like to play? (Select by number.)");
            this.display(hand);
            Console.WriteLine("0. Return to previous menu.");
            string input = Console.ReadLine();
            if (input == "0")
            {
                return;
            }
            else
            {
                int x = 0;
                if (Int32.TryParse(input, out x))
                {
                    if (x > hand.Count - 1)
                    {
                        System.Console.WriteLine("Index out of range!");
                        playCard(target);
                    }
                    else
                    {
                        if (hand[x].cost < black_mana)
                        {
                            hand[x].play(this, target);
                            black_mana -= hand[x].cost;
                            hand.RemoveAt(x);
                        }
                        else
                        {
                            System.Console.WriteLine("You don't have enough mana!");
                            this.playCard(target);
                        }
                    }
                }
            }

        }
        public void display(List<Card> cards)
        {
            for (int i = 1; i < cards.Count; i++)
            {
                Console.WriteLine("{0}. --- [{1}] ---\nType: {2} | Color: {3} | Cost: {4}", cards[i-1].name, cards[i-1].type, cards[i-1].color, cards[i-1].cost);
                if (cards[i-1].type == "creature")
                {
                    Creature creature = cards[i-1] as Creature;
                    Console.WriteLine("Attack: {0} | Defense: {1}", creature.attack, creature.defense);
                }
                else if (cards[i-1].type == "spell")
                {
                    Spell creature = cards[i-1] as Spell;
                    // spell stuff
                    // spells: (draw) # of cards (mod) att/def (damage) damage
                }
                else if (cards[i-1].type == "land")
                {

                }
            }
        }

        public void display(List<Card> cards, string condition)
        {
            if (condition == "available")
            {
                for (int i = 1; i < cards.Count; i++)
                {
                    if ((cards[i-1] as Creature).tapped)
                    {
                        Console.WriteLine("{0} --- [{1}] ---\nType: {2} | Color: {3} | Cost: {4}", cards[i - 1].name, cards[i - 1].type, cards[i - 1].color, cards[i - 1].cost);
                        Console.WriteLine("Attack: {0} | Defense: {1}", (cards[i - 1] as Creature).attack, (cards[i - 1] as Creature).defense);
                    }
                }
            }
        }


        public void displayOptions(Player target)
        {
            Console.WriteLine("Display:\n1. Your cards\n2. {0}'s cards\n3. Nevermind.\n", target.name);
            string input = Console.ReadLine();
            if (input == "1")
            {
                display(played_lands);
                display(played_creatures);
                display(hand);
            }
            else if (input == "2")
            {
                display(target.played_creatures);
            }
            else if (input == "3")
            {

            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.\n");
            }
        }

        public void attack(Player target)
        {
            System.Console.WriteLine("Which creature would you like to attack with?");
            this.display(played_creatures, "available");
            Console.WriteLine("0. Return to previous menu.");
            string input = Console.ReadLine();
            int x = 0;
            if (input == "0")
            {
                return;
            }
            if (Int32.TryParse(input, out x))
            {
                if (x > played_creatures.Count - 1)
                {
                    System.Console.WriteLine("That is not a card. Please select a card.");
                    this.attack(target);
                }
                else
                {
                    target.defend(target, this, played_creatures[x] as Creature, x);
                }
            }
            else
            {
                System.Console.WriteLine("Please pick an available card.");
                this.attack(target);
            }
        }

        public void defend(Player me, Player attacker, Creature attacking_creature, int attackIdx)
        {
            System.Console.WriteLine("Which creature would you like to attack with?");
            this.display(played_creatures, "available");
            Console.WriteLine("0. Return to previous menu.");
            string input = Console.ReadLine();
            int x = 0;
            if (input == "0")
            {
                attacking_creature.battle(this, attacker);
                return;
            }
            if (Int32.TryParse(inputLine, out x))
            {
                if (!(played_creatures[x] as Creature).tapped)
                {
                    System.Console.WriteLine("Creature has already defended!");
                    this.defend(me, attacker, attacking_creature, attackIdx);
                    return;
                }
                if (x > played_creatures.Count - 1)
                {
                    System.Console.WriteLine("Creature index out of range!");
                    this.defend(me, attacker, attacking_creature, attackIdx);
                    return;
                }
                else
                {
                    attacking_creature.battle(this, attacker, attackIdx, x, (played_creatures[x] as Creature));
                    return;
                }
            }
            else
            {
                System.Console.WriteLine("Input was not an integer!");
                this.defend(me, attacker, attacking_creature, attackIdx);
                return;
            }
        }
    }
}