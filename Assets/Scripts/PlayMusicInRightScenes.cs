using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMusicInRightScenes : MonoBehaviour
{

    public static PlayMusicInRightScenes playerInstance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "JeopardyScene") {
            playerInstance = null;
            Destroy(gameObject);
        }
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
