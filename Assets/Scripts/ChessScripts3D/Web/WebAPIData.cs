using System;

namespace ChessScripts3D.Web
{
    [Serializable]
    public static class WebAPIData
    {
        private const string URL = "https://3dchess.store";
        private const string SocketUrl = "ws://3dchess.store";
        public static string GetURL() => URL;
        public static string GetSocketURL() => SocketUrl;
        
        private const string AuthKey = "Authorization";
        private const string RefreshKey = "refreshToken";

        public static string GetAuthKey() { return AuthKey; }
        public static string GetRefreshKey() { return RefreshKey; }
    }
}