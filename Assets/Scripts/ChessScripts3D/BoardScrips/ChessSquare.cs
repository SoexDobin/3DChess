using WarpSquareEngine;

namespace ChessScripts3D.BoardScrips
{
    public class ChessSquare
    {
        public File file;
        public Rank rank;
        public Level level;

        public ChessSquare(Square square)
        {
            file = square.GetFile();
            rank = square.GetRank();
            level = square.GetLevel();
        }
        
        public ChessSquare(File _file, Rank _rank, Level _level)
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

        public ChessSquare GetSquare()
        {
            return this;
        }

        public bool IsSameSquare(ChessSquare compareSquare)
        {
            return compareSquare.file == file &&
                   compareSquare.rank == rank &&
                   compareSquare.level == level;
        }
    }
}