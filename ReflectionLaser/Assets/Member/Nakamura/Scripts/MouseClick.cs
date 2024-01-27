using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseClick : MonoBehaviour
{

    [SerializeField,Header("�X�^�[�g�n�_")]
    GameObject startPointObject;

    [SerializeField,Header("�e")]
    GameObject bulletObject;

    // �ǂ������Ă��邩
    private bool bHaswall=false;

    // �E�N���b�N����������
    private bool bPushRight=false;


    //�����グ���
    private GameObject liftObject;

    //�e�̈ʒu
    private Vector3 bulletPoint;

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
           // this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
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
            //���ł��E�N���������牟���Ȃ��i�j
            if(bPushRight)
            {
                return;
            }
            RightMouseEvent();
            Debug.Log("�E�N���b�N");
            bPushRight = true;
        }
    }

    /// <summary>
    ///  ���N���b�N�ŕǂ������グ��֐�
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
    /// �E�N���b�N�Œe�𔭎˂���
    /// </summary>
    private void RightMouseEvent()
    {
        //  startPointObject�̈ʒu���擾
        bulletPoint = startPointObject.transform.localPosition;
        // �e�̐���
        Instantiate(bulletObject, bulletPoint, Quaternion.identity);
    }

    /// <summary>
    /// �ǂ𓮂����֐�
    /// </summary>
    private void MoveWall()
    {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint);
        liftObject.transform.position = new Vector3(currentPosition.x,currentPosition.y, 0)+this.offset;
        Debug.Log("ooooo");
    }
}
