using System;
using System.Collections;
using System.Text;
using ChessScripts3D.Web.HTTPSchemas;
using UnityEngine;
using UnityEngine.Networking;
using static UnityEngine.Networking.UnityWebRequest;

namespace ChessScripts3D.Web
{
    public class LoginRequest : MonoBehaviour
    {
        public IEnumerator LoginReq(LoginRequestDto loginData, Action<UnityWebRequest> req)
        {
            var jsonData = JsonUtility.ToJson(loginData, true);

            using UnityWebRequest request = new UnityWebRequest($"{WebAPIData.GetURL()}/auth/login", "GET");
            byte[] jsonDataBytes = new UTF8Encoding().GetBytes(jsonData);

            request.uploadHandler = new UploadHandlerRaw(jsonDataBytes);
            request.downloadHandler = new DownloadHandlerBuffer();
        
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();
            
            if (request.result == Result.ConnectionError || request.result == Result.ProtocolError)
            {
                Debug.LogError($"Request Error: {request.error}");
            }
            else
            {
                Debug.Log("Request Succeeded!");
                Debug.Log($"Response Code: {request.responseCode}");
                Debug.Log($"Response: {request.downloadHandler.text}");
            }
            
            req(request);
        }
    }
}
