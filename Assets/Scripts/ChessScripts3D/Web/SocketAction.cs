using System;
using System.Collections.Generic;
using ChessScripts3D.Web.HTTPSchemas;
using WarpSquareEngine;

namespace ChessScripts3D.Socket
{
    [Serializable]
    public enum SocketAction
    {
        ROOM_STATE,
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
    public class GetColor : GetAction 
    {
        public Color color;
    }

    [Serializable]
    public class GetUserInfo : GetAction
    {
        public UserInfoDto info;
    }
        

    [Serializable]
    public class GetInitAction : GetAction
    {
        
    }
}