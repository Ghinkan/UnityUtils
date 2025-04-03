namespace UnityEngine
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        public static T Instance;
        public bool AutoUnparentOnAwake = true;

        protected virtual void Awake()
        {
            InitializeSingleton();
        }

        private void InitializeSingleton()
        {
            if (!Application.isPlaying) return;

            if (AutoUnparentOnAwake)
                transform.SetParent(null);

            if (!Instance)
            {
                Instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                if (Instance != this)
                    Destroy(gameObject);
            }
        }
    }
}