using System;
using System.Collections.Generic;
using System.Linq;

namespace magic_game{

    public class Deck{
        public List<Card> cards; //oneToMany
        private Player player;//OneToOne 
        // DO NOT USE A BLANK CONSTRUCTOR WHY DID WE DO THIS CAMERON
        public Deck(Player player){
            this.player = player;
            cards = new List<Card>();
            DamageSpell spinalTap = new DamageSpell(5,4,"Spinal Tap");
            ModSpell empower = new ModSpell(2,2,"empower", 4);
            DrawSpell resupply = new DrawSpell(2,2,"resupply");
            Land blackLand = new Land();
            OldBones OldBones = new OldBones();
            BlackKnight BlackKnight = new BlackKnight();
            cards.Add(spinalTap);//instanciate all the cards here?
            cards.Add(spinalTap);//  create lists of all available types and have a random algo to randomly pick 25 land,20 spells and 20 creatures?
            cards.Add(empower);
            cards.Add(empower);
            cards.Add(resupply);
            cards.Add(resupply);
            cards.Add(blackLand);
            cards.Add(blackLand);
            cards.Add(blackLand);
            cards.Add(blackLand);
            cards.Add(blackLand);
            cards.Add(blackLand);
            cards.Add(blackLand);
            cards.Add(blackLand);
            cards.Add(blackLand);
            cards.Add(blackLand);
            cards.Add(blackLand);
            cards.Add(blackLand);
            cards.Add(blackLand);
            cards.Add(blackLand);
            cards.Add(blackLand);
            cards.Add(BlackKnight);
            cards.Add(OldBones);
            cards.Add(BlackKnight);
            cards.Add(OldBones);
            cards.Add(BlackKnight);
            cards.Add(OldBones);
            this.Shuffle();
        }
        public Card Draw(){
                Card temp = this.cards[0];
                this.cards.RemoveAt(0);
                player.hand.Add(temp);
                return temp;
            }

        public List<Card> Draw5(){
            List<Card> temp = new List<Card>();
            for(int i=0; i<5;i++){
                temp.Add(this.cards[0]);
                this.cards.RemoveAt(0);
            }
            return temp;
        }
        // public Deck Reset(Player player){
        //      deck = new Deck(player);
        //      return deck;
        // }
        public Deck Shuffle(){
            Random rand = new Random();
            this.cards = this.cards.OrderBy(x => rand.Next()).ToList();
            return this;
        }
    }
}