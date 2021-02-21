using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Playables;
using UnityEngine.UI;

public class ConfirmResults : MonoBehaviour
{

    public string roomCode;
    // Start is called before the first frame updatevoid Start()

    void Start()
    {
        roomCode = Global.roomCode;
        // A correct website page.
        StartCoroutine(GetRequest(""+Global.api+"/unity?command="+"resolve"+"&room_code="+roomCode));
    }

    // public void FetchCode() {
    //     StartCoroutine(GetRequest("http://127.0.0.1:5000/unity?command="+"resolve"));
    // }

    void HandleText(string text) {
        char[] delimiterChars = { ',' };

       // GameObject.Find("Result Text").GetComponent<Text>().text = text;
        //roomCode = text;
        
        string[] words = text.Split(delimiterChars);
        GameObject.Find("Correct Text").GetComponent<Text>().text = words[0] + " people got it right!";
        GameObject.Find("Wrong Text").GetComponent<Text>().text = words[1] + " people got it wrong.";
        GameObject.Find("Answer Text").GetComponent<Text>().text = words[5];
        //Global.roomCode = text;
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