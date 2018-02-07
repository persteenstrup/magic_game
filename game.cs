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
            player1 = new Player(Console.ReadLine());
            Console.WriteLine("What is Player 2's name?\n");
            player2 = new Player(Console.ReadLine());
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
