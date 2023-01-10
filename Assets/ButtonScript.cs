using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Button button;
    public Graphic buttonGraphic;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        Debug.Log("Button clicked!");
    }

    void FixedUpdate(){

    }
}
