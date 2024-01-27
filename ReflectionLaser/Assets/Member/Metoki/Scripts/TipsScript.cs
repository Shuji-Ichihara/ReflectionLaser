using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsScript : MonoBehaviour
{
    [SerializeField]
    private Canvas _canvas;
    public void OpenTurtrial()
    {
        //あそびかたを開く
        _canvas.enabled = true;
    }

    public void CloseTurtrial()
    {
        //あそびかたを閉じる
        _canvas.enabled = false;
    }
}
