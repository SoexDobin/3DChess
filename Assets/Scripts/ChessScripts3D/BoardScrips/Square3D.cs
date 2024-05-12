using ChessScripts3D.PieceScripts;
using JetBrains.Annotations;
using UnityEngine;
using WarpSquareEngine;

namespace ChessScripts3D.BoardScrips
{
    public class Square3D : MonoBehaviour
    {
        [CanBeNull] public Piece3D locatedPiece;

        public ChessSquare chessSquare;

        public void SetSquare(File _file, Rank _rank, Level _level)
        {
            if (chessSquare is null)
            {
                chessSquare = new ChessSquare(_file, _rank, _level);
            }
            
            chessSquare.file = _file;
            chessSquare.rank = _rank;
            chessSquare.level = _level;
        }

        public void SetSquare(Square initSquare)
        {
            chessSquare.SetSquare(initSquare);
        } 
    }
}
