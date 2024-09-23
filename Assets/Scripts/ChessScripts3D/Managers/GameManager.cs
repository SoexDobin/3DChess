using System;
using System.Net.WebSockets;
using ChessScripts3D.Socket;
using ChessScripts3D.Web;
using ChessScripts3D.Web.HTTPSchemas;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using WarpSquareEngine;
using Color = WarpSquareEngine.Color;

namespace ChessScripts3D.Managers
{
    public class GameManager : SingleTon<GameManager>
    {
        public Color myColor;
        
        public GetUserInfo myInfo;
        
        public GetUserInfo opponentInfo;
        
        public bool isReady;
        
        public Game game = new Game();
        
        private ChessGameWebSocket _ws;
        
        [Header("Managers")]
        private CameraManager _cameraManager;
        private BoardManager3D _boardManager;
        private PieceManager3D _pieceManager;
        
        private void Awake()
        {
            _ws = ChessGameWebSocket.Instance;

            _ws.colorDel += SetMyColor;
            _ws.userInitDel += SetMyInfo;
            _ws.opponentInitDel += SetOpponentInfo;
        }

        private void Update()
        {
            /*foreach (var piece in game.GetPiecesWithBoardType(BoardType.White))
            {
                Debug.Log(piece.GetChar() + " " + piece);
            }*/

            /*Debug.Log( game.GetBoards()[0].GetLevel()); // 레벨 < = >보드타입 매칭 
            game.PushBoardMove(new BoardMove(Level.White, Level.Kl3, new Option<PieceType>()));
            Debug.Log( game.GetBoards()[0].GetLevel());*/
            
            // todo : 피스 불러오기 
            
            
        }

        private void LateUpdate()
        {
            if (_ws.currentState != GameSocketState.GameInit) return;
            SceneManager.LoadScene("3DChessGameScene");
            SceneManager.sceneLoaded -= LoadSceneInit;
            SceneManager.sceneLoaded += LoadSceneInit;
        }

        private void SetMyColor(GetColor action) { myColor = action.color; }
        private void SetMyInfo(GetUserInfo info) { myInfo = info; }
        private void SetOpponentInfo(GetUserInfo info) { opponentInfo = info; }

        private void LoadSceneInit(Scene scene, LoadSceneMode mode)
        {
            _cameraManager = CameraManager.Instance;
            _boardManager = BoardManager3D.Instance;
            _pieceManager = PieceManager3D.Instance;

            _cameraManager.setHomePos.Invoke(myColor);

            _ws.currentState = GameSocketState.InGamePlaying;

            _pieceManager.InitPiece(game.GetPieces(), _boardManager.boards);
        }
        
    }
}