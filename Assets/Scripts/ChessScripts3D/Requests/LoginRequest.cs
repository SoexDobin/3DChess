using System.Collections;
using System.Text;
using ChessScripts3D.HTTPSchemas;
using UnityEngine;
using UnityEngine.Networking;

namespace ChessScripts3D.Requests
{
    public class LoginRequest : MonoBehaviour
    {
        public UnityWebRequest.Result loginResult; 
    
        private string _url;

        public string URL
        {
            get => _url;
            set => _url = value;
        }

        private void Start()
        {
            URL = "https://3dchess.shop/auth";
        }

        public IEnumerator LoginReq(LoginRequestDto loginData)
        {
            var jsonData = JsonUtility.ToJson(loginData);
        
            using UnityWebRequest request = UnityWebRequest.Get($"{URL}/login");

            byte[] jsonDataBytes = new UTF8Encoding().GetBytes(jsonData);

            request.uploadHandler = new UploadHandlerRaw(jsonDataBytes);
            request.downloadHandler = new DownloadHandlerBuffer();
        
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();
        
            loginResult = request.result;
        
            if (request.result == UnityWebRequest.Result.Success)
            {
                print($"Success! : {request.downloadHandler.text}");
            }
            else
            {
                print($"Error! : {request.error}");
            }
        }
    }
}
