using UnityEngine;

namespace _Code.Utils
{
    public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected static T instance;
        public static T Instance 
        { 
            get 
            {
                if(instance == null)
                {
                    instance = FindObjectOfType<T>(true);
                }
                return instance;
            } 
        }
    }
}