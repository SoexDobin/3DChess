using ChessScripts3D.Managers;
using ChessScripts3D.Socket;
using UnityEngine;
using WebSocketSharp;

namespace ChessScripts3D.Web
{
    public enum GameSocketState
    {
        Matching,
        Matched,
        GameInit,
        InGamePlaying,
    }
    
    public class ChessGameWebSocket : SingleTon<ChessGameWebSocket>
    {
        public WebSocket socket;

        public GameSocketState currentState = GameSocketState.Matching;

        private void Start()
        {
            socket.OnOpen += (sender, e) => { };
            
            socket.OnMessage += (sender, e) =>
            {
                Debug.Log(e.Data);
                
                SetUpAction(e);
            };
            
            socket.OnClose += (sender, e) => {
                if (e.Code == 1000)
                {
                    socket.Close();
                }
            };
            
            socket.OnError += (sender, e) => {
                if (e.Exception != null) {
                    Debug.LogError("Exception: " + e.Exception);
                }
            };
        }

        public void OnEnable()
        {
            currentState = GameSocketState.Matching;
            
            var auth = WebRequests.instance.GetAuthorization();

            socket = new WebSocket(WebAPIData.GetSocketURL() + $"/game/start?token={auth}");

            socket.Connect();
        }

        public void OnDisable()
        {
            socket.Close();
        }

        private void SetUpAction(MessageEventArgs e)
        {
            if (e.Data.Contains(SocketAction.ROOM_STATE.ToString()))
            {
                var datum = e.Data.Split(",");
                
                foreach (var data in datum)
                {
                    var checkString = data;
                    
                    if (checkString.Contains("roomId"))
                    {
                        var actionObject = JsonUtility.FromJson<GetColor>(e.Data);
                        GameManager.instance.SetMyColor(actionObject);
                    }
                    else if (checkString.Contains("myInfo"))
                    {
                        var actionObject = JsonUtility.FromJson<GetUserInfo>(e.Data);
                        GameManager.instance.SetMyInfo(actionObject);
                        
                    }
                    else if (checkString.Contains("matchedUserInfo"))
                    {
                        var actionObject = JsonUtility.FromJson<GetUserInfo>(e.Data);
                        GameManager.instance.SetOpponentInfo(actionObject);
                    }
                }
            }
        }
    }
}