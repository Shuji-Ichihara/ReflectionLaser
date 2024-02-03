using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseClick : MonoBehaviour
{

    // �ǂ������Ă��邩
    private bool bHaswall;

    //�����グ���
    private GameObject liftObject;

    private Vector3 screenPoint;
    private Vector3 offset;

    // UnityEvent���Ă����f���Q�[�g���ۂ���炵��
    public UnityEvent onRightPushEvent = new UnityEvent();

    void Update()
    {
        MouseEvent();

        // �����グ�Ă���Ȃ瓮����
        if(bHaswall)
        {
            MoveWall();
        }

    }

    /// <summary>
    /// �}�E�X������s���֐�
    /// </summary>
    private void MouseEvent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (bHaswall)
            {
                // �����グ�Ă�ꍇ���낷
                bHaswall = false;
                Debug.Log(bHaswall);
            }
            else
            {
                //�����グ�ĂȂ��ꍇ�����グ��
                ClickLiftObject();
                Debug.Log(bHaswall);
            }

            Debug.Log("���N���b�N");
        }
        else if (Input.GetMouseButtonDown(1))
        {
            // �f���Q�[�g�̌Ăяo���Ńr�[���o��
            onRightPushEvent.Invoke();
            Debug.Log("�E�N���b�N");
        }
    }

    /// <summary>
    ///  �ǂ������グ��֐�
    /// </summary>
    private void ClickLiftObject()
    {

        // �N���b�N��̕ǂ��擾
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit2D = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

        //hit2D���Ȃ�������Return
        if (!hit2D)
        {
            Debug.Log("not hit2D");
            return;
        }

        //  hit2D�̃^�O��"Wall"�Ȃ�liftObject�Ɋ��蓖�Ă�
        if (hit2D.transform.gameObject.CompareTag("Wall"))
        {
            liftObject = hit2D.transform.gameObject;
            bHaswall = true;
        }

    }

    /// <summary>
    /// �ǂ𓮂����֐�
    /// </summary>
    private void MoveWall()
    {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint);
        liftObject.transform.position = new Vector3(currentPosition.x,currentPosition.y, 0);
        Debug.Log("ooooo");
    }
}
