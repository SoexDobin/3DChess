using UnityEngine;

namespace ChessScripts3D.Managers
{
    public class SingleTon<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        public static T instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = FindFirstObjectByType<T>();
                }
                return _instance;
            }
        }

        private void Awake()
        {
            
            
            
            DontDestroyOnLoad(this);
        }
    }
    
}
