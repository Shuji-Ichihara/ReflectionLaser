using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsScript : MonoBehaviour
{
    [SerializeField]
    private Canvas _canvas;
    public void OpenTurtrial()
    {
        //�����т������J��
        _canvas.enabled = true;
    }

    public void CloseTurtrial()
    {
        //�����т��������
        _canvas.enabled = false;
    }
}
