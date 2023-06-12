using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.JSInterop;
namespace TicTacToeTestTwo.Pages
{
    public partial class Index
    {

        public void test()
        {
            //one dimensionl array
            int[] h = new int[3];
            h[0] = 1;
            h[1] = 2;
            h[2] = 3;

            // two dimensional array
            int[,] collection1 = new int[3, 3];
            collection1[0, 0] = 1; collection1[1, 0] = 1; collection1[2, 0] = 1;
            collection1[0, 1] = 2; collection1[1, 1] = 2; collection1[2, 1] = 2;
            collection1[0, 2] = 3; collection1[1, 2] = 3; collection1[2, 2] = 3;

            foreach (var item in collection1)
            {

            }

            // Jagged array -- it is a combination of 1D array
            int[][] arr = new int[4][];
            arr[0] = new int[] { 11, 12 };
            arr[1] = new int[] { 11, 12 };
            arr[2] = new int[] { 11, 12 };
            arr[3] = new int[] { 11, 12 };




        }


        string[] board = { "", "", "", "", "", "", "", "", "" };
        string player = "X";
        int[][] winningcombo = {
        new int[3]{0,1,2 },
        new int[3]{3,4,5 },
        new int[3]{6,7,8 },

        new int[3]{0,3,6 },
        new int[3]{1,4,7 },
        new int[3]{2,5,8 },

        new int[3]{2,4,6 },
        new int[3]{0,4,8 }


        };

        private async Task BoardClick(int xybox)
        {
            if (board[xybox] != "")
            {
                ShowDilog("box alredy filled!!,Pick a diffrent box!!");
                return;
            }

            board[xybox] = player;
            //if (player == "X")
            //{


            //    player = "O";
            //}

            //else { player = "X"; }

            player = player == "X" ? "O" : "X";

            foreach (int[] item in winningcombo)
            {
                int p1 = item[0];
                int p2 = item[1];
                int p3 = item[2];

                if (board[p1] == "" || board[p2] == "" || board[p3] == "")
                {
                    continue;
                }

                if (board[p1] == board[p2] && board[p2] == board[p3] && board[p3] == board[p1])
                {
                    //string winner = "";

                    //if (player == "X")
                    //{
                    //{
                    //    winner = "player 2 ";
                    //}
                    //else
                    //{
                    //    winner = "player 1 ";
                    //}

                    //string winner1 = player == "X" ? "player2" : player =="Y"?"player1" : "Draw" ;
                    string winner = player == "X" ? "player 2" : "player 1"; // ternary operator
                                                                             // ? true , : false

                    ShowDilog(winner + " is the winner");

                    ResetGame();



                }

                if (board.All(x => x != ""))
                {

                    ShowDilog("Tie!!");
                    ResetGame();

                }



            }
        }

        private void ResetGame()
        {

            for (int i = 0; i < board.Length; i++)
            {
                board[i] = "";
            }

        }

        // this method for code reuseability
        /// <summary>
        /// ShowDilog method show the alert message for my tic tac toe board game
        /// </summary>
        /// <param name="msg"></param>
        private async void ShowDilog(string msg)
        {
            await js.InvokeVoidAsync("alert", msg);
        }

    }
}

