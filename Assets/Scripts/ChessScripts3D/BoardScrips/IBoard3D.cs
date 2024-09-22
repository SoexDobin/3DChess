using System;
using System.Collections.Generic;
using UnityEngine;
using warp_square_engine;

namespace ChessScripts3D.BoardScrips
{
    public interface IBoard3D
    {
        public void InitBoard(Level lev);
        public Vector3 GetWorldSpaceTransform();
    }
}
