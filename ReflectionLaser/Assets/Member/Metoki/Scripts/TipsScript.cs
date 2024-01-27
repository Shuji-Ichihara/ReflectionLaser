using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsScript : MonoBehaviour
{
    [SerializeField]
    private Canvas _canvas;
    public void OpenTurtrial()
    {
        //‚ ‚»‚Ñ‚©‚½‚ðŠJ‚­
        _canvas.enabled = true;
    }

    public void CloseTurtrial()
    {
        //‚ ‚»‚Ñ‚©‚½‚ð•Â‚¶‚é
        _canvas.enabled = false;
    }
}
