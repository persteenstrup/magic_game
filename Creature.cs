using System;
using System.Collections.Generic;

namespace magic_game {
    public abstract class Creature :Card {
        public int attack;
        public int defense;
        public List<string> abilities = new List<string>();
        public bool tapped;

        // public bool hasBlocked;

        // public summoningSick;

        protected Creature() :base() {  //pretty sure we don't need these to have any inputs
            tapped = true;
            // hasBlocked = false;
            // summoningSick = true;
        }

        //THIS IS WHERE YOU PUT THE ATTACK METHOD
        public void battle(Player attacker, Player target) {  // this is used when no defense happens
            target.health -= attack;
        }

        public void battle(Player attackplayer, Player defendplayer, int attackCreatureIdx, int defendCreatureIdx, Creature defendCreature){
            //handle battle logic here
            Console.WriteLine("Round 1....FIGHT! Challengers are {0} and {1}", name, defendCreature.name);
            int[] results = {1, 1 };
            tapped = true;
            defendCreature.tapped = true;
            defense -= defendCreature.attack;
            defendCreature.defense -= attack;
            if (defense <= 0) {
                results[0] = 0;
                attackplayer.played_creatures.RemoveAt(attackCreatureIdx);
            }
            if (defendCreature.defense <= 0) {
                results[1] = 0;
                defendplayer.played_creatures.RemoveAt(defendCreatureIdx);
            }
        }


    }

    public class OldBones : Creature {
        public OldBones() :base() {
            name = "Old Bones";
            cost = 1;
            attack = 1;
            defense = 1;
        }
    }

    public class SkeletonWarrior : Creature {
        public SkeletonWarrior() :base() {
            name = "Skeleton Warrior";
            cost = 3;
            attack = 3;
            defense = 3;
        }
    }

    public class SkeletonKing : Creature {
        public SkeletonKing() :base() {
            name = "SkeletonKing";
            cost = 6;
            attack = 8;
            defense = 5;
        }
    }
    public class UnendingDeath : Creature {
        public UnendingDeath() :base() {
            name = "Unending Death";
            cost = 9;
            attack = 10;
            defense = 10;
            abilities.Add("trample");
        }
    }

    public class BogWitch : Creature {
        public BogWitch() :base() {
            name = "Bog Witch";
            cost = 2;
            attack = 2;
            defense = 3;
        }
    }

        public class UnholyBlade : Creature {
        public UnholyBlade() :base() {
            name = "Unholy Blade";
            cost = 3;
            attack = 3;
            defense = 2;
            tapped = false;
            abilities.Add("haste");
        }
    }

    public class ShamblingDead : Creature {
        public ShamblingDead() :base() {
            name = "Shambling Dead";
            cost = 3;
            attack = 4;
            defense = 2;
        }
    }

    public class FreshCorpse : Creature {
        public FreshCorpse() :base() {
            name = "Fresh Corpse";
            cost = 2;
            attack = 2;
            defense = 2;
        }
    }

    public class BlackKnight : Creature {
        public BlackKnight() :base() {
            name = "BlackKnight";
            cost = 4;
            attack = 5;
            defense = 5;
        }
    }

    public class HoodedThief : Creature {
        public HoodedThief() :base() {
            name = "HoodedThief";
            cost = 2;
            attack = 2;
            defense = 1;
            abilities.Add("first strike");
        }
    }

}
