using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsScript : MonoBehaviour
{
    [SerializeField]
    private Canvas _turtrialCanvas;
    [SerializeField]
    private Canvas _sousaCanvas;
    public void OpenTurtrial()
    {
        //‚ ‚»‚Ñ‚©‚½‚ðŠJ‚­
        _turtrialCanvas.enabled = true;
    }

    public void CloseTurtrial()
    {
        //‚ ‚»‚Ñ‚©‚½‚ð•Â‚¶‚é
        _turtrialCanvas.enabled = false;
        _sousaCanvas.enabled = false;
    }

    public void OpenSousaCanvas()
    {
        //‚ ‚»‚Ñ‚©‚½‚ðŠJ‚­
        _turtrialCanvas.enabled = false;
        _sousaCanvas.enabled = true;
    }
    public void CloseSousaCanvas()
    {
        //‚ ‚»‚Ñ‚©‚½‚ðŠJ‚­
        _turtrialCanvas.enabled = true;
        _sousaCanvas.enabled = false;
    }
}
