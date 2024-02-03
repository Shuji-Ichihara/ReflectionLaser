using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public enum DIRECTION
{
    UP, DOWN, LEFT, RIGHT
}

[CustomEditor(typeof(Bullet))]
public class PokemonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var bullet = target as Bullet;

       bullet.E_DIRECTION = (DIRECTION)EditorGUILayout.EnumPopup("����", bullet.E_DIRECTION);

    }
}

public class Bullet : MonoBehaviour
{
    [SerializeField]
    public DIRECTION E_DIRECTION;

    [SerializeField]
    private float speed=100.0f;

    private bool bOnceLog;


    //��������Enum���Z���N�g�ł���悤�ɉ���
    public void Initialize(DIRECTION vECTOR)
    {
        E_DIRECTION = vECTOR;
    }

    // Update is called once per frame
    void Update()
    {
        // �e�̈ړ�
        switch(E_DIRECTION)
        {
            case DIRECTION.UP:
                transform.Translate(Vector3.up * Time.deltaTime*speed);
                OnceLog("UP");
                break;
            case DIRECTION.DOWN:
                transform.Translate(Vector3.down * Time.deltaTime*speed);
                OnceLog("Down");
                break;
            case DIRECTION.LEFT:
                transform.Translate(Vector3.left * Time.deltaTime * speed);
                OnceLog("Left");
                break; 
            case DIRECTION.RIGHT:
                transform.Translate(Vector3.right * Time.deltaTime * speed);
                OnceLog("Right");
                break;
        }
    }

    /// <summary>
    /// ���O����񂾂��o���悤�̊֐�
    /// </summary>
    /// <param name="Log">���O�ŏo������������</param>
    private void OnceLog(string Log)
    {
        if (!bOnceLog)
        {
            Debug.Log(Log);
            bOnceLog = true; 
        }
    }
}
