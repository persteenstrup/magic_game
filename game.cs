using System;
using System.Collections.Generic;

namespace magic_game
{
    public class Game{
        Player player1;
        Player player2;
    
        public Game(){
            startGame();
        }
        
        public void startGame() {
            Console.WriteLine("What is Player 1's name?\n");
            string input = Console.ReadLine();
            player1 = new Player(input);
            Console.WriteLine("What is Player 2's name?\n");
            input = Console.ReadLine();
            player2 = new Player(input);
            turnLoop();
        }

        public void turnLoop() {
            while(player1.health > 0) {
                player1.startTurn(player2);
                player2.startTurn(player1);
            }
        }
    }
}
