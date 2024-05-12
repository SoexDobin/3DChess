using System;
using System.Collections.Generic;
using ChessScripts3D.BoardScrips;
using ChessScripts3D.PieceScripts;
using ChessScripts3D.Socket;
using UnityEngine;
using WarpSquareEngine;
using Action = ChessScripts3D.Socket;
using Color = WarpSquareEngine.Color;

namespace ChessScripts3D.Managers
{
    public class PieceManager3D : SingleTon<PieceManager3D>
    {
        public List<Piece3D> pieces = new List<Piece3D>();
        
        [SerializeField] private PieceData init;

        private void Awake()
        {
            init ??= GetComponent<PieceData>();
            
            Debug.Log(init.blackBishop);
        }

        public void InitPiece(List<Piece> initPieces, List<IBoard3D> boards)
        {
            foreach (var piece in initPieces)
            {
                if (piece.GetColor() == Color.White)
                {
                    var whitePiece = init.InstantiateWhitePiece(piece);
                    
                    whitePiece.SetSquare(piece.GetSquare());
                    
                    foreach (var board in boards)
                    {
                        foreach (var square3D in board.GetSquares())
                        {
                            if (square3D.chessSquare.IsSameSquare(whitePiece.chessSquare))
                            {
                                square3D.locatedPiece = whitePiece;
                                
                                whitePiece.transform.position = square3D.transform.position;
                            } 
                        }
                    }

                    pieces.Add(whitePiece);
                }
                else if (piece.GetColor() == Color.Black)
                {
                    var blackPiece = init.InstantiateBlackPiece(piece);
                    
                    blackPiece.SetSquare(piece.GetSquare());

                    foreach (var board in boards)
                    {
                        foreach (var square3D in board.GetSquares())
                        {
                            if (square3D.chessSquare.IsSameSquare(blackPiece.chessSquare))
                            {
                                square3D.locatedPiece = blackPiece;
                                
                                blackPiece.transform.position = square3D.transform.position;
                            } 
                        }
                    }

                    pieces.Add(blackPiece);
                }
                // 피스 Awake or Start 선 생성 이후 GameManager에서 월드 포지션으로 이동 
            }
            
            
        }
    }
}
