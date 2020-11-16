using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static bool isShuttingDown = false;
    private static object lockObject = new object();
    private static T innerInstance;

    public static T instance
    {
        get
        {
            if (isShuttingDown)
            {
                Debug.LogWarning($"[Singleton] Instance '{nameof(T)}' already destroyed. Returning null.");
                return null;
            }

            lock (lockObject)
            {
                if (innerInstance)
                {
                    return innerInstance;
                }

                innerInstance = FindObjectOfType(typeof(T)) as T;
                if (innerInstance)
                {
                    return innerInstance;
                }
                
                innerInstance = new GameObject().AddComponent<T>();
                innerInstance.gameObject.name = $"{nameof(T)} + (Singleton)";
                
                DontDestroyOnLoad(innerInstance);

                return innerInstance;
            }
        }
    }

    private void OnApplicationQuit() => isShuttingDown = true;

    private void OnDestroy() => isShuttingDown = true;
}
