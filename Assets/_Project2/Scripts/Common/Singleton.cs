using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static T instance;

    public static T Instance;

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = instance ??= FindObjectOfType<T>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnDestroy()
    {
        if (instance == this) instance = null;
    }
}
