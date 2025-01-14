﻿using System;
using System.Runtime.InteropServices;

namespace Function
{
    internal class TicTacToe
    {
        /**
             * Tic-Tac-Toe 게임
             * 컴퓨터와 사람이 번갈아 가면서 o,x 를 둔다
             * 보드 크기는 3 X 3
             * 컴퓨터의 룰은 간단하게
             * 1. 중앙이 비었으면 중앙을 선점 하려고 함.
             * 2. 이후에 빈자리 아무곳이나 적당히 찾아서 둔다.
             */
        enum TicTacToePlayerType
        {
            NONE = 0, PLAYER, COMPUTER
        }

        static void Main(string[] args)
        {
            int[,] gameBoard = new int[3, 3];
            int playerX, playerY = 0;
            bool isValidLocation = false;
            bool isPlayerTurn = false;
            bool isGameOver = false;

            string playerIcon = string.Empty;
            string playerType = string.Empty;

            while (!isGameOver)
            {
                // 플레이어 턴 진행
                isPlayerTurn = true;
                playerType = "[플레이어]";

                // { 플레이어에게서 좌표를 입력 받는다.
                playerX = 0;
                playerY = 0;
                isValidLocation = false;

                while (true)
                {
                    // 루프 탈출 조건, 제대로 된 입력을 받은 경우 탈출.
                    if (isValidLocation)
                    {
                        break;
                    }
                    //플레이어 턴 / 좌표 입력 받음
                    Console.Write("[플레이어] (x) 좌표 : ");
                    int.TryParse(Console.ReadLine(), out playerX);
                    Console.Write("[플레이어] (y) 좌표 : ");
                    int.TryParse(Console.ReadLine(), out playerY);

                    if (gameBoard[playerY, playerX].Equals((int)TicTacToePlayerType.NONE))
                    {
                        gameBoard[playerY, playerX] = (int)(TicTacToePlayerType.PLAYER);
                        isValidLocation = true;
                    }   // if : 보드가 빈 곳인 경우
                    else
                    {
                        Console.WriteLine("[System] 해당 좌표는 비어있지 않습니다. / 다른 좌표를 입력하세요.");
                        isValidLocation = false;
                    }   // else : 보드가 빈 곳이 아닌 경우

                }   // loop : 플레이어의 좌표 입력을 받는 루프
                // } 플레이어에게서 좌표를 입력 받는다.

                // { 플레이어의 턴 진행을 보드에 출력한다
                for (int y = 0; y < gameBoard.GetLength(0); y++)
                {
                    Console.WriteLine("---|---|---");
                    for (int x = 0; x < gameBoard.GetLength(1); x++)
                    {
                        switch (gameBoard[x, y])
                        {
                            case (int)TicTacToePlayerType.PLAYER:
                                playerIcon = "O";
                                break;
                            case (int)TicTacToePlayerType.COMPUTER:
                                playerIcon = "X";
                                break;
                            default:
                                playerIcon = " ";
                                break;
                        }   // switch
                        Console.Write($" {playerIcon} ");

                        // print Separator
                        if (x == gameBoard.GetLength(1)) { /* Do Nothing */}
                        else { Console.Write("|"); }

                    }   // loop : 한 줄에서 출력할 내용을 연산한다.
                    Console.WriteLine();
                }   // loop
                Console.WriteLine("---|---|---");
                // } 플레이어의 턴 진행을 보드에 출력한다

                // { 게임이 끝났는지 보드 검사
                Console.WriteLine();

                isGameOver = false;
                for (int y = 0; y < gameBoard.GetLength(0); y++)
                {
                    if (gameBoard[y, 0].Equals((int)TicTacToePlayerType.PLAYER) &&
                        gameBoard[y, 1].Equals((int)TicTacToePlayerType.PLAYER) &&
                        gameBoard[y, 2].Equals((int)TicTacToePlayerType.PLAYER))
                    {
                        isGameOver = true;
                    }
                    else
                    {
                        continue;
                    }
                }   // Loop : 가로 방향으로 검사하는 루프
                for (int x = 0; x < gameBoard.GetLength(1); x++)
                {
                    if (gameBoard[0, x].Equals((int)TicTacToePlayerType.PLAYER) &&
                        gameBoard[1, x].Equals((int)TicTacToePlayerType.PLAYER) &&
                        gameBoard[2, x].Equals((int)TicTacToePlayerType.PLAYER))
                    {
                        isGameOver = true;
                    }
                    else
                    {
                        continue;
                    }
                }   // Loop : 세로 방향으로 검사하는 루프

                // 대각선 방향으로 검사
                if ((gameBoard[0, 0].Equals((int)TicTacToePlayerType.PLAYER) &&
                        gameBoard[1, 1].Equals((int)TicTacToePlayerType.PLAYER) &&
                        gameBoard[2, 2].Equals((int)TicTacToePlayerType.PLAYER)) ||
                        (gameBoard[0, 2].Equals((int)TicTacToePlayerType.PLAYER) &&
                        gameBoard[1, 1].Equals((int)TicTacToePlayerType.PLAYER) &&
                        gameBoard[2, 0].Equals((int)TicTacToePlayerType.PLAYER)))
                {
                    isGameOver = true;
                }

                // } 게임이 끝났는지 보드 검사

                // 게임이 끝난 경우 루프를 탈출한다.
                if (isGameOver)
                {
                    break;
                }

                // 게임이 끝나지 않은 경우 턴을 교체한다.
                isPlayerTurn = false;
                playerType = "[컴퓨터]";
                bool isComputerDoing = false;

                Console.WriteLine($"{playerType}의 턴");
                // 컴퓨터는 간단한 룰
                // { 1. 중앙이 비어있으면 선점
                if (!isComputerDoing)
                {
                    if (gameBoard[1, 1].Equals((int)TicTacToePlayerType.NONE))
                    {
                        gameBoard[1, 1] = (int)TicTacToePlayerType.COMPUTER;
                        isComputerDoing = true;
                    }   // if : 중앙이 비어 있는 경우
                    else
                    {
                        /* Do Nothing */
                    }
                }   // if : 컴퓨터가 아직 아무것도 하지 않은 경우
                else
                {
                    /* Do Nothing */
                }
                // } 1. 중앙이 비어있으면 선점

                // { 2. 적당히 빈 자리 찾아서 착수
                if (!isComputerDoing)
                {
                    for (int y = 0; y < gameBoard.GetLength(0); y++)
                    {
                        for (int x = 0; x < gameBoard.GetLength(1); x++)
                        {
                            if (!isComputerDoing && gameBoard[y, x].Equals((int)TicTacToePlayerType.NONE))
                            {
                                gameBoard[y, x] = (int)TicTacToePlayerType.COMPUTER;
                                isComputerDoing = true;
                                break;
                            }   // if : 서치한 자리가 비어있는 경우
                            else
                            {
                                continue;
                            }
                        }   // loop : search horizontal
                    }   // loop : search vertical
                }   // if : 컴퓨터가 아직 아무것도 하지 않은 경우
                else
                {
                    /* Do Nothing */
                }
                // } 2. 적당히 빈 자리 찾아서 착수

                // { 컴퓨터의 턴 진행을 보드에 출력한다.
                for (int y = 0; y < gameBoard.GetLength(0); y++)
                {
                    Console.WriteLine("---|---|---");
                    for (int x = 0; x < gameBoard.GetLength(1); x++)
                    {
                        switch (gameBoard[x, y])
                        {
                            case (int)TicTacToePlayerType.PLAYER:
                                playerIcon = "O";
                                break;
                            case (int)TicTacToePlayerType.COMPUTER:
                                playerIcon = "X";
                                break;
                            default:
                                playerIcon = " ";
                                break;
                        }   // switch
                        Console.Write($" {playerIcon} ");

                        if (x.Equals(gameBoard.GetLength(1))) {  /* Do Nothing */ }
                        else { Console.Write("|"); }
                    }   // loop : 한 줄에서 출력할 내용을 연산한다.
                    Console.WriteLine();
                }   // loop
                Console.WriteLine("---|---|---");
                // } 컴퓨터의 턴 진행을 보드에 출력한다.

                // { 게임이 끝났는지 보드 검사
                Console.WriteLine();
                isGameOver = false;
                
                for (int y = 0; y < gameBoard.GetLength(0); y++)
                {
                    if (gameBoard[y, 0].Equals((int)TicTacToePlayerType.COMPUTER) &&
                        gameBoard[y, 1].Equals((int)TicTacToePlayerType.COMPUTER) &&
                        gameBoard[y, 2].Equals((int)TicTacToePlayerType.COMPUTER))
                    {
                        isGameOver = true;
                    }
                    else
                    {
                        continue;
                    }
                }   // Loop : 가로 방향으로 검사하는 루프
                for (int x = 0; x < gameBoard.GetLength(1); x++)
                {
                    if (gameBoard[0, x].Equals((int)TicTacToePlayerType.COMPUTER) &&
                        gameBoard[1, x].Equals((int)TicTacToePlayerType.COMPUTER) &&
                        gameBoard[2, x].Equals((int)TicTacToePlayerType.COMPUTER))
                    {
                        isGameOver = true;
                    }
                    else
                    {
                        continue;
                    }
                }   // Loop : 세로 방향으로 검사하는 루프

                // 대각선 방향으로 검사
                if ((gameBoard[0, 0].Equals((int)TicTacToePlayerType.COMPUTER) &&
                        gameBoard[1, 1].Equals((int)TicTacToePlayerType.COMPUTER) &&
                        gameBoard[2, 2].Equals((int)TicTacToePlayerType.COMPUTER)) ||
                        (gameBoard[0, 2].Equals((int)TicTacToePlayerType.COMPUTER) &&
                        gameBoard[1, 1].Equals((int)TicTacToePlayerType.COMPUTER) &&
                        gameBoard[2, 0].Equals((int)TicTacToePlayerType.COMPUTER)))
                {
                    isGameOver = true;
                }
                else
                {
                    continue;
                }

                // } 게임이 끝났는지 보드 검사

                
            }   // loop : 틱택토 게임 루프

            Console.WriteLine($"{playerIcon}의 승리!");


        }
    }
}
