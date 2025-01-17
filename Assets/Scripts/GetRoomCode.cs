using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Playables;
using UnityEngine.UI;

public class GetRoomCode : MonoBehaviour
{

    public string roomCode;
    // Start is called before the first frame updatevoid Start()

    void Start()
    {
        // A correct website page.
        //StartCoroutine(GetRequest("http://127.0.0.1:5000/unity?command="+"create"));
    }

    public void FetchCode() {
        StartCoroutine(GetRequest(""+Global.api+"/unity?command="+"create"));
    }

    void HandleText(string text) {
        GameObject.Find("Room Code").GetComponent<Text>().text = text;
        roomCode = text;
        Global.roomCode = text;
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
}