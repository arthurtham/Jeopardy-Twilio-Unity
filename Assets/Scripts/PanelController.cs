using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool fadeVisible;
    public float fadeValue;

    public GameObject panel;
    
    void Start()
    {
        
        
    }

    public void FadeOut() {
        fadeVisible = false;
    }

    public void FadeIn() {
        fadeVisible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeVisible && (fadeValue < 1.0f)) {
            fadeValue += 0.05f;
        } else if (!fadeVisible && (fadeValue > 0.0f)) {
            fadeValue -= 0.05f;
        }

        Color tmp = panel.GetComponent<Image>().color;
        tmp.a = fadeValue;
        panel.GetComponent<Image>().color = tmp;
        Text[] children = panel.GetComponentsInChildren<Text>();
        foreach (Text child in children) {
            tmp = child.color;
            tmp.a = fadeValue;
            child.color = tmp;
        }
    }
}
