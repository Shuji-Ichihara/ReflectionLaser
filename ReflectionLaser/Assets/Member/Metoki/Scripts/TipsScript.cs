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
        //あそびかたを開く
        _turtrialCanvas.enabled = true;
    }

    public void CloseTurtrial()
    {
        //あそびかたを閉じる
        _turtrialCanvas.enabled = false;
    }

    public void OpenSousaCanvas()
    {
        //あそびかたを開く
        _turtrialCanvas.enabled = false;
        _sousaCanvas.enabled = true;
    }
    public void CloseSousaCanvas()
    {
        //あそびかたを開く
        _turtrialCanvas.enabled = true;
        _sousaCanvas.enabled = false;
    }
}
