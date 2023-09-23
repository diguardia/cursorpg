using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton <T> : MonoBehaviour where T : Component 
{
    
    public static T _instance;

    public static T Instance {
        get {
            if (_instance == null) {
                _instance = FindAnyObjectByType<T>();
                if (_instance == null) {
                    GameObject o = new GameObject();
                    _instance = o.AddComponent<T>();
                }
            }

            return _instance;
        }
    }

    protected virtual void Awake() {
        _instance = this as T;
    }

}
