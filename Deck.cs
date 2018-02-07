using System;
using System.Collections.Generic;
using System.Linq;

namespace magic_game{

    public class Deck{
        private List<Card> cards; //oneToMany
        private Player player;//OneToOne 
        public Deck(){
            
        }
    public Deck(Player player){
        this.player = player;
        List<Card> cards = new List<Card>();
        DamageSpell spinalTap = new DamageSpell(5,4,"Spinal Tap");
        ModSpell empower = new ModSpell(2,2,"empower", 4);
        DrawSpell resupply = new DrawSpell(2,2,"resupply");
        cards.Add(spinalTap);//instanciate all the cards here?
        cards.Add(spinalTap);//  create lists of all available types and have a random algo to randomly pick 25 land,20 spells and 20 creatures?
        cards.Add(spinalTap);
        cards.Add(spinalTap);
        cards.Add(spinalTap);
        cards.Add(empower);
        cards.Add(empower);
        cards.Add(empower);
        cards.Add(empower);
        cards.Add(empower);
        cards.Add(resupply);
        cards.Add(resupply);
        cards.Add(resupply);
        cards.Add(resupply);
        cards.Add(resupply);
    }
    public Card Draw(){
            Card temp = this.cards[0];
            this.cards.RemoveAt(0);
            return temp;
        }
        public Deck Reset(Deck deck){
             deck = new Deck();
             return deck;
        }
        public Deck Shuffle(){
            Random rand = new Random();
            this.cards = this.cards.OrderBy(x => rand.Next()).ToList();
            return this;
        }
    }
}