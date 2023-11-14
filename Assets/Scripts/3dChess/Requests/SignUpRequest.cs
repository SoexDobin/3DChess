﻿using System.Collections;
using System.Text;
using _3dChess.Schemas;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace _3dChess.Requests
{
    public class SignUpRequest : MonoBehaviour
    {
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
        
        public IEnumerator SignUpReq(SignUpRequestDto signUpData)
        {
            var jsonData = JsonConvert.SerializeObject(signUpData);
            
            using UnityWebRequest request = UnityWebRequest.Post($"{URL}/sign-up", string.Empty);

            byte[] jsonDataBytes = new UTF8Encoding().GetBytes(jsonData);

            request.uploadHandler = new UploadHandlerRaw(jsonDataBytes);
            request.downloadHandler = new DownloadHandlerBuffer();
            
            request.SetRequestHeader("Content-Type", "application/json");
            
            yield return request.SendWebRequest();
            
            if (request.result == UnityWebRequest.Result.Success)
            {
                print($"Error! : {request.downloadHandler.text}");
            }
            else
            {
                print($"Error! : {request.error}");
            }

        }
    }
}