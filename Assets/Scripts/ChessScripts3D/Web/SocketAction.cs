using System;
using System.Collections.Generic;
<<<<<<< Updated upstream
using WarpSquareEngine;
=======
using ChessScripts3D.Web.HTTPSchemas;
using warp_square_engine;
>>>>>>> Stashed changes

namespace ChessScripts3D.Socket
{
    [Serializable]
    public enum SocketAction
    {
        INIT,
        COLOR,
        MATCHED_USER,
    }

    [Serializable]
    public class GetAction
    {
        public SocketAction action;
    }
    
    [Serializable]
    public class GetColorAction : GetAction 
    {
        public Color color;
    }

    [Serializable]
    public class GetInitAction : GetAction
    {
        
    }
}