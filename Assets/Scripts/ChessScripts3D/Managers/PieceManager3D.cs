using System;
using System.Collections.Generic;
using ChessScripts3D.PieceScripts;
<<<<<<< Updated upstream
using ChessScripts3D.Socket;
using WarpSquareEngine;
using Action = ChessScripts3D.Socket;
=======
using UnityEngine;
using warp_square_engine;
using Color = warp_square_engine.Color;
>>>>>>> Stashed changes

namespace ChessScripts3D.Managers
{
    public class PieceManager3D : SingleTon<PieceManager3D>
    {
        public PieceInit3D init;
        public PieceDataBase3D dataBase;

        private void Awake()
        {
            init = GetComponent<PieceInit3D>();
            dataBase = GetComponent<PieceDataBase3D>();
        }
    }
}
