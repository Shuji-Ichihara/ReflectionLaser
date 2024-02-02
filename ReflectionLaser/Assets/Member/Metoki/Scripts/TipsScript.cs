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
        //�����т������J��
        _turtrialCanvas.enabled = true;
    }

    public void CloseTurtrial()
    {
        //�����т��������
        _turtrialCanvas.enabled = false;
        _sousaCanvas.enabled = false;
    }

    public void OpenSousaCanvas()
    {
        //�����т������J��
        _turtrialCanvas.enabled = false;
        _sousaCanvas.enabled = true;
    }
    public void CloseSousaCanvas()
    {
        //�����т������J��
        _turtrialCanvas.enabled = true;
        _sousaCanvas.enabled = false;
    }
}
