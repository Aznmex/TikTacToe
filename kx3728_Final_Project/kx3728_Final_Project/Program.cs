using System;

namespace kx3728_Final_Project
{
    class Program
    {
        // creating global objects          // this is the only way to capture variables that are out of the scope, but have to remain within the class Program
        static char[] board = {'0', '1', '2', '3', '4', '5', '6', '7', '8'};        
        static int player = 1;
        static int player_decision;
        static int game_decision = 0;
        
        static void Main(string[] args)
        { 
            Console.WriteLine("Welcome to tic-tac-toe!");

            for(dynamic i = 0; i < 9; i++)          // use of dynamic variable, showing that it automatically knows to change to an integer at run time
            {
                string info = "Player 1 = X";       // use of string concatenation 
                info += "\nPlayer 2 = O";           // the use of combining two strings together into one variable to output a single string 
                Console.WriteLine(info);

                Console.WriteLine("~Displaying current board~");
                DisplayBoard();

                if(player == 1)
                {
                    Console.WriteLine("It is player 1's (X) turn!");
                }
                else if (player == 2)
                {
                    Console.WriteLine("It is player 2's (O) turn!");
                }


                int main_turn = i;      // get the current position as the turn value
                unsafe
                {                       // the unsafe keyword is used for pointers and has to be turned on in the build properties to run 
                    main_turn++;        // increment it to show that it is turn 1 not turn 0 when starting 
                    int* turn = &main_turn;     // pass the address value of main_turn to the pointer of turn
                    Console.WriteLine("Current turn: {0}", *turn);  // output the turn to the user with the value of main_turn but as a pointer called turn
                }

                Console.WriteLine("Enter a move (0-8) on the board!");   
                player_decision = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");

                if (board[player_decision] == 'X' || board[player_decision] == 'O')
                {
                    Console.WriteLine("Please enter another position, that one is currently taken!");
                }
                else
                {
                    if (player == 1)
                    {
                        board[player_decision] = 'X';
                        player++;
                    }
                    else if (player == 2)
                    {
                        board[player_decision] = 'O';
                        player--;
                    }
                }

                game_decision = IsWin();    // return the value from the IsWin function

                if (game_decision == 1)
                {
                    Func<int, int> isPlayer = x => (x % 2) + 1;     // to show the use of lamba functions  // takes in x and mods the value by 2 and then adds by one to get the player number
                    Console.WriteLine("Player {0} wins!", isPlayer(player));    // call the function with the player value to display the player throught the math behind it
                    Console.WriteLine("Displaying winning board!");
                    DisplayBoard();
                    break;      // we use break here to jump out 
                }
                else if (game_decision == 2)
                {
                    Console.WriteLine("It is a draw!");
                    DisplayBoard();
                    break;
                }
            }
        }
       
        // function to display the board to the user    // the functions inherit the board values because it is still in the same class 
       private static void DisplayBoard()
        {
            Console.WriteLine("|-----|");
            Console.WriteLine("|{0}|{1}|{2}|", board[0], board[1], board[2]);
            Console.WriteLine("|-----|");
            Console.WriteLine("|{0}|{1}|{2}|", board[3], board[4], board[5]);
            Console.WriteLine("|-----|");
            Console.WriteLine("|{0}|{1}|{2}|", board[6], board[7], board[8]);
            Console.WriteLine("|-----|"); 
        }

        // function that should return 1 if the board is a win or a 2 if the board is a draw
        private static int IsWin()
        {
            // horizontal matches
            if(board[0] == board[1] && board[1] == board[2])
            {
                return 1;
            }
            if (board[3] == board[4] && board[4] == board[5])
            {
                return 1;
            }
            if (board[6] == board[7] && board[7] == board[8])
            {
                return 1;
            }

            // vertical matches
            if (board[0] == board[3] && board[3] == board[6])
            {
                return 1;
            }
            if (board[1] == board[4] && board[4] == board[7])
            {
                return 1;
            }
            if (board[2] == board[5] && board[5] == board[8])
            {
                return 1;
            }

            // diagonal matches
            if (board[0] == board[4] && board[4] == board[8])
            {
                return 1;
            }
            if (board[2] == board[4] && board[4] == board[6])
            {
                return 1;
            }

            // case for a draw
            if (board[0] != '0' && board[1] != '1'&& board[2] != '2' && board[3] != '3' && board[4] != '4' && board[5] != '5' && board[6] != '6' && board[7] != '7' && board[8] != '8')
            {
                return 2;
            }

            return 0;
        }
    }
}