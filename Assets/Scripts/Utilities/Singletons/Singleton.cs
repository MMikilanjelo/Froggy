using UnityEngine;

namespace Game.Utilities.Singletons
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        protected static T instance;
        public static bool HasInstance => instance != null;
        public static T TryGetInstance => HasInstance ? instance : null;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindAnyObjectByType<T>();
                    if (instance == null)
                    {
                        var gameObject = new GameObject(typeof(T).Name + "Auto-Generated");
                        instance = gameObject.AddComponent<T>();
                    }
                }
                return instance;
            }
        }
        /// <summary>
        /// You need to call base Awake in override if you need and Awake
        /// </summary>
        protected virtual void Awake(){
            InitializeSingleton();
        }
        protected virtual void InitializeSingleton(){
            if(!Application.isPlaying){
                return;
            }
            instance = this as T;
        }
    }
}

