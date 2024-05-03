using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using WarpSquareEngine;

namespace ChessScripts3D.BoardScrips
{
    public class AttackBoard3D : MonoBehaviour, IBoard3D
    {
        public BoardType boardType;
        public Level level;
        public List<Square3D> squares = new List<Square3D>(); 
        
        [SerializeField] private Square3D _square;
        
        public void InitBoard(Level lev)
        {
            level = lev;

            boardType = level switch
            {
                Level.Ql1 => BoardType.WhiteQueen,
                Level.Ql6 => BoardType.BlackQueen,
                Level.Kl1 => BoardType.WhiteKing,
                Level.Kl6 => BoardType.BlackKing,
                _ => boardType
            };

            transform.position = GetWorldSpaceTransform();
            
            SetSquareByBoardType();
        }

        public void MoveBoard(Level lev)
        {
            level = lev;
            
        }

        public Vector3 GetWorldSpaceTransform()
        {
            Vector3 boardPosition;

            if (level < (Level)9)
            {
                switch (level)
                {
                    case Level.Ql1:
                        boardPosition = new Vector3(-6, -2.5f, 3);        
                        return boardPosition;
                    case Level.Ql2:
                        boardPosition = new Vector3(0, -2.5f, 3);
                        return boardPosition;
                    case Level.Ql3:
                        boardPosition = new Vector3(-3, 2.5f, 3);
                        return boardPosition;
                    case Level.Ql4:
                        boardPosition = new Vector3(3, 2.5f, 3);
                        return boardPosition;
                    case Level.Ql5:
                        boardPosition = new Vector3(0, 7.5f, 3);
                        return boardPosition;
                    case Level.Ql6:
                        boardPosition = new Vector3(6, 7.5f, 3);
                        return boardPosition;
                }
                
            }
            else if (level >= (Level)9)
            {
                switch (level)
                {
                    case Level.Kl1:
                        boardPosition = new Vector3(-6, -2.5f, -3);
                        return boardPosition;
                    case Level.Kl2:
                        boardPosition = new Vector3(0, -2.5f, -3);
                        return boardPosition;
                    case Level.Kl3:
                        boardPosition = new Vector3(-3, 2.5f, -3);
                        return boardPosition;
                    case Level.Kl4:
                        boardPosition = new Vector3(3, 2.5f, -3);
                        return boardPosition;
                    case Level.Kl5:
                        boardPosition = new Vector3(0, 7.5f, -3);
                        return boardPosition;
                    case Level.Kl6:
                        boardPosition = new Vector3(6, 7.5f, -3);
                        return boardPosition;
                }
            }

            return Vector3.zero;
        }

        private void SetSquareByBoardType()
        {
            var index = 0;
            var padding = 1.5f;
            var goto_Rank_StartLine = new Vector3(padding, 0, padding * 2);
            
            var worldPos = transform.position + new Vector3(-0.75f, 0, 0.75f);
            
            if (boardType == BoardType.WhiteQueen)
            {
                var fileCount = 0;
                var rankCount = 0;
                while (index < 4)
                {
                    var square = Instantiate(_square, worldPos, Quaternion.identity, transform);
                    square.SetSquare((File)fileCount, (Rank)rankCount, level);
                    squares.Add(square);

                    index++;
                    fileCount++;
                    
                    worldPos -= new Vector3(0, 0, padding);
                    if (index % 2 == 0)
                    {
                        worldPos += goto_Rank_StartLine;
                        fileCount = 0;
                        rankCount++;
                    }
                }
            }
            else if (boardType == BoardType.WhiteKing)
            {
                var fileCount = 4;
                var rankCount = 0;
                while (index < 4)
                {
                    var square = Instantiate(_square, worldPos, Quaternion.identity, transform);
                    square.SetSquare((File)fileCount, (Rank)rankCount, level);
                    squares.Add(square);

                    index++;
                    fileCount++;
                    
                    worldPos -= new Vector3(0, 0, padding);
                    if (index % 2 == 0)
                    {
                        worldPos += goto_Rank_StartLine;
                        fileCount = 4;
                        rankCount++;
                    }
                }
            }
            else if (boardType == BoardType.BlackQueen)
            {
                var fileCount = 0;
                var rankCount = 8;
                while (index < 4)
                {
                    var square = Instantiate(_square, worldPos, Quaternion.identity, transform);
                    square.SetSquare((File)fileCount, (Rank)rankCount, level);
                    squares.Add(square);

                    index++;
                    fileCount++;
                    
                    worldPos -= new Vector3(0, 0, padding);
                    if (index % 2 == 0)
                    {
                        worldPos += goto_Rank_StartLine;
                        fileCount = 0;
                        rankCount++;
                    }
                }
            }
            else if (boardType == BoardType.BlackKing)
            {
                var fileCount = 4;
                var rankCount = 8;
                while (index < 4)
                {
                    var square = Instantiate(_square, worldPos, Quaternion.identity, transform);
                    square.SetSquare((File)fileCount, (Rank)rankCount, level);
                    squares.Add(square);

                    index++;
                    fileCount++;
                    
                    worldPos -= new Vector3(0, 0, padding);
                    if (index % 2 == 0)
                    {
                        worldPos += goto_Rank_StartLine;
                        fileCount = 4;
                        rankCount++;
                    }
                }
            }
        }
    }
}