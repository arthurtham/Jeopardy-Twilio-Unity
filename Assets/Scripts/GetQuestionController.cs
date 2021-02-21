using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Playables;
using UnityEngine.UI;

public class GetQuestionController : MonoBehaviour
{

    public string roomCode;
    // Start is called before the first frame updatevoid Start()

    public PlayableDirector playableDirectorPre;
    public PlayableDirector playableDirectorCur;
    void Start()
    {
        // A correct website page.
        roomCode = Global.roomCode;
        StartCoroutine(GetRequest("http://127.0.0.1:5000/unity?command="+"start"+"&room_code="+roomCode+""));
    }

    public void startJeopardySequence() {
        playableDirectorCur.Play();
    }

    void HandleText(string text) {
        char[] delimiterChars = { ';' };

        System.Console.WriteLine($"Original text: '{text}'");

        string[] words = text.Split(delimiterChars);
        GameObject.Find("Question Text").GetComponent<Text>().text = words[0];
        GameObject.Find("Question Text Big").GetComponent<Text>().text = words[0];

        GameObject.Find("Answer A").GetComponent<Text>().text = words[1];
        GameObject.Find("Answer B").GetComponent<Text>().text = words[2];
        GameObject.Find("Answer C").GetComponent<Text>().text = words[3];
        //GameObject.Find("Question Text").GetComponent<Text>().text = words[2];
        GameObject.Find("Category Text").GetComponent<Text>().text = words[5];
        GameObject.Find("Category Text Big").GetComponent<Text>().text = words[5];

        // TODO: activate timeline
        playableDirectorPre.Play();
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