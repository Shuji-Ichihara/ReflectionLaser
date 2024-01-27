using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsScript : MonoBehaviour
{
    [SerializeField]
    private Canvas _canvas;
    void ONClickButton()
    {
           _canvas.enabled = true;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _canvas.enabled = false;
        }    
    }
}
