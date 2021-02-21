using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer;
    public float timer_init;
    public bool timer_go;
    public PlayableDirector playableDirector;
    void Start()
    {
        timer = timer_init;
    }

    public void StartTimer() {
        timer_go=true;
    }

    public void StopTimer() {
        timer_go=false;
    }

    public void PauseTimeline() {
        playableDirector.Pause();
    }

    public void EndWagers() {
        StartCoroutine(GetRequest(""+Global.api+"/unity?command="+"closewager"+"&room_code="+Global.roomCode));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                HandleText(webRequest.downloadHandler.text);
            }
        }
    }

    void HandleText(string text) {
        if (text == "wagers closed") {
            playableDirector.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer_go) {
            timer -= Time.deltaTime;
        }
        if (timer_go && timer <= 0.0f) {
            EndWagers();
            timer_go = false;
            timer = 0.0f;
        }
        GameObject.Find("Timer").GetComponent<Text>().text = timer.ToString ("0.00");

    }
}
