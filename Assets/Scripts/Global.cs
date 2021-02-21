using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    private static Global playerInstance;
    public static string roomCode;

    public static string api = "http://127.0.0.1:5000";
    
    void Awake(){
            DontDestroyOnLoad (this);
            if (playerInstance == null) {
                playerInstance = this;
            } else {
                Destroy(gameObject);
            }
        }
}
