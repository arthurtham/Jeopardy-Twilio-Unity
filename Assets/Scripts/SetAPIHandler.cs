using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetAPIHandler : MonoBehaviour
{
    private InputField input;
    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<InputField>();
        input.text = Global.api;
        input.onValueChanged.AddListener( value => Global.ChangeAPI( value ));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
