using System;
using System.Collections.Generic;
using ChessScripts3D.PieceScripts;
using ChessScripts3D.Socket;
using WarpSquareEngine;
using Action = ChessScripts3D.Socket;

namespace ChessScripts3D.Managers
{
    public class PieceManager3D : SingleTon<PieceManager3D>
    {
        public PieceInit3D init;

        public List<Piece3D> pieces = new List<Piece3D>();

        private void Awake()
        {
            init = GetComponent<PieceInit3D>();
        }

        public void InitPiece(List<Piece> initPieces)
        {
            foreach (var piece in initPieces)
            {
                // 피스 Awake or Start 선 생성 이후 GameManager에서 월드 포지션으로 이동 
            }
        }
    }
}
