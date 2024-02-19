using UnityEngine;

public class PersistentObjectManager : MonoBehaviour
{
    private static PersistentObjectManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}