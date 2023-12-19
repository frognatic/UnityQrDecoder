using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    public static T Instance
    {
        get
        {
            if (!instance)
                Create();
            return instance;
        }
    }
    
    private static T instance;
    
    private static void Create()
    {
        var go = new GameObject("." + typeof(T).Name) { };
        instance = go.AddComponent<T>();
        DontDestroyOnLoad(go);
    }
}
