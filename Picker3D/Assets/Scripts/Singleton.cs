using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<S> : MonoBehaviour where S : MonoBehaviour
{
    private static object _lock = new object();
    private static S _instance;

    public static S Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null) _instance = (S) FindObjectOfType(typeof(S));

                return _instance;
            }
        }
    }
}
