using ChessScripts3D.PieceScripts;
using UnityEngine;
using WarpSquareEngine;

namespace ChessScripts3D.BoardScrips
{
    public class Square3D : MonoBehaviour
    {
        public Piece3D piece;
        
        public File file;
        public Rank rank;
        public Level level;

        public void SetSquare(File _file, Rank _rank, Level _level)
        {
            file = _file;
            rank = _rank;
            level = _level;
        }

        public void SetSquare(Square square)
        {
            file = square.GetFile();
            rank = square.GetRank();
            level = square.GetLevel();
        } 
    }
}
