using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    private static Global playerInstance;
    public static string roomCode;

    public static string api = "http://sandbox.arttham.com:5170";

    public static void ChangeAPI(string newApi) {
        api = newApi;
    }
    
    void Awake(){
            DontDestroyOnLoad (this);
            if (playerInstance == null) {
                playerInstance = this;
            } else {
                Destroy(gameObject);
            }
        }
}
