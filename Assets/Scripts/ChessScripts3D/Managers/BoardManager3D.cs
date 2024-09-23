using System.Collections.Generic;
using ChessScripts3D.BoardScrips;
using UnityEngine;
using WarpSquareEngine;

namespace ChessScripts3D.Managers
{
    public class BoardManager3D : SingleTon<BoardManager3D>
    {
        [Header("Main Boards")]
        public MainBoard3D whiteBoard;
        public MainBoard3D blackBoard;
        public MainBoard3D neutralBoard;

        [Header("Attack Boards")]
        public AttackBoard3D whiteKingBoard;
        public AttackBoard3D whiteQueenBoard;
        public AttackBoard3D blackKingBoard;
        public AttackBoard3D blackQueenBoard;

        public List<IBoard3D> boards = new List<IBoard3D>();

        void Awake()
        {
            whiteBoard.InitBoard(Level.White); 
            neutralBoard.InitBoard(Level.Neutral); 
            blackBoard.InitBoard(Level.Black);
            
            whiteKingBoard.InitBoard(Level.Kl1); 
            whiteQueenBoard.InitBoard(Level.Ql1);
            blackKingBoard.InitBoard(Level.Kl6);
            blackQueenBoard.InitBoard(Level.Ql6);
            
            boards.Add(whiteBoard);
            boards.Add(neutralBoard);
            boards.Add(blackBoard);

            boards.Add(whiteKingBoard);
            boards.Add(whiteQueenBoard);
            boards.Add(blackKingBoard);
            boards.Add(blackQueenBoard);
        }

        public void BoardsInit(Game game)
        {
            
        }
    }
}
