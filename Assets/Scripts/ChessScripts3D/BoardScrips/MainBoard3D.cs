using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using WarpSquareEngine;

namespace ChessScripts3D.BoardScrips
{
    public class MainBoard3D : MonoBehaviour, IBoard3D
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
                Level.White => BoardType.White,
                Level.Neutral => BoardType.Neutral,
                Level.Black => BoardType.Black,
                _ => boardType
            };
            
            transform.position = GetWorldSpaceTransform();
            SetSquareByBoardType();
        }

        public Vector3 GetWorldSpaceTransform()
        {
            Vector3 boardPosition;
            
            switch (level)
            {
                case Level.White:
                    boardPosition = new Vector3(-3, -5);
                    return boardPosition;
                case Level.Black:
                    boardPosition = new Vector3(3, 5);
                    return boardPosition;
                case Level.Neutral:
                    boardPosition = Vector3.zero;
                    return boardPosition;
            }
            
            return Vector3.zero;
        }

        private void SetSquareByBoardType()
        {
            var index = 0;
            var padding = 1.5f;
            var goto_Rank_StartLine = new Vector3(padding, 0, padding * 4);
            
            var worldPos = transform.position + new Vector3(-2.25f, 0, 2.25f);
            
            if (boardType is BoardType.White)
            {
                var fileCount = 1;
                var rankCount = 1;
                while (index < 16)
                {
                    fileCount %= 5;
                    if (fileCount is 0)
                    {
                        fileCount = 1;
                        rankCount++;
                    }

                    rankCount %= 5;
                    if (rankCount is 0) rankCount = 1; 
                    
                    var square = Instantiate(_square, worldPos, Quaternion.identity, transform);
                    square.SetSquare((File)fileCount, (Rank)rankCount, level);
                    squares.Add(square);
                    
                    index++;
                    fileCount++;
                    
                    worldPos -= new Vector3(0, 0, padding);
                    if (index % 4 == 0) worldPos += goto_Rank_StartLine;
                }
            }
            else if (boardType is BoardType.Neutral)
            {
                var fileCount = 1;
                var rankCount = 3;
                while (index < 16)
                {
                    fileCount %= 5;
                    if (fileCount is 0)
                    {
                        fileCount = 1;
                        rankCount++;
                    }
                    
                    rankCount %= 7;
                    if (rankCount is 0) rankCount = 3; 
                    
                    var square = Instantiate(_square, worldPos, Quaternion.identity, transform);
                    square.SetSquare((File)fileCount, (Rank)rankCount, level);
                    squares.Add(square);
                    
                    index++;
                    fileCount++;
                    
                    worldPos -= new Vector3(0, 0, padding);
                    if (index % 4 == 0) worldPos += goto_Rank_StartLine;
                }
            }
            else if (boardType is BoardType.Black)
            {
                var fileCount = 1;
                var rankCount = 5;
                while (index < 16)
                {
                    fileCount %= 5;
                    if (fileCount is 0)
                    {
                        fileCount = 1;
                        rankCount++;
                    }
                    
                    rankCount %= 10;
                    if (rankCount is 0) rankCount = 5; 
                    
                    var square = Instantiate(_square, worldPos, Quaternion.identity, transform);
                    square.SetSquare((File)fileCount, (Rank)rankCount, level);
                    squares.Add(square);
                    
                    index++;
                    fileCount++;
                    
                    worldPos -= new Vector3(0, 0, padding);
                    if (index % 4 == 0) worldPos += goto_Rank_StartLine;
                }
            }
        }
    }
}