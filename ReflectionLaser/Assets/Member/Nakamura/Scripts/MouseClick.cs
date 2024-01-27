using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseClick : MonoBehaviour
{

    // 壁を持っているか
    private bool bHaswall;

    //持ち上げる壁
    private GameObject liftObject;

    private Vector3 screenPoint;
    private Vector3 offset;

    // UnityEventっていうデリゲートっぽいやつらしい
    public UnityEvent onRightPushEvent = new UnityEvent();

    void Update()
    {
        MouseEvent();

        // 持ち上げているなら動かす
        if(bHaswall)
        {
            MoveWall();
        }

    }

    /// <summary>
    /// マウス操作を行う関数
    /// </summary>
    private void MouseEvent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (bHaswall)
            {
                // 持ち上げてる場合おろす
                bHaswall = false;
                Debug.Log(bHaswall);
            }
            else
            {
                //持ち上げてない場合持ち上げる
                ClickLiftObject();
                Debug.Log(bHaswall);
            }

            Debug.Log("左クリック");
        }
        else if (Input.GetMouseButtonDown(1))
        {
            // デリゲートの呼び出しでビーム出す
            onRightPushEvent.Invoke();
            Debug.Log("右クリック");
        }
    }

    /// <summary>
    ///  壁を持ち上げる関数
    /// </summary>
    private void ClickLiftObject()
    {

        // クリック先の壁を取得
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit2D = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

        //hit2DがなかったらReturn
        if (!hit2D)
        {
            Debug.Log("not hit2D");
            return;
        }

        //  hit2Dのタグが"Wall"ならliftObjectに割り当てる
        if (hit2D.transform.gameObject.CompareTag("Wall"))
        {
            liftObject = hit2D.transform.gameObject;
            bHaswall = true;
        }

    }

    /// <summary>
    /// 壁を動かす関数
    /// </summary>
    private void MoveWall()
    {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint);
        liftObject.transform.position = new Vector3(currentPosition.x,currentPosition.y, 0);
        Debug.Log("ooooo");
    }
}
