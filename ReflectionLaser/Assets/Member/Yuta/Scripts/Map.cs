using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    private TextAsset textFile;

    private string[] textData;
    private string[,] dungeonMap;

    private int tateNumber; // �s���ɑ���
    private int yokoNumber; // �񐔂ɑ���

    [SerializeField]
    private GameObject floorPrefab;
    [SerializeField]
    private GameObject wallPrefab;
    [SerializeField]
    private GameObject goalPrefab;
    [SerializeField]
    private GameObject startPrefab;

    private void Start()
    {
        string textLines = textFile.text; // �e�L�X�g�̑S�̃f�[�^�̑��

        // ���s�Ńf�[�^�𕪊����Ĕz��ɑ��
        textData = textLines.Split('\n');

        // �s���Ɨ񐔂̎擾
        yokoNumber = textData[0].Split(',').Length;
        tateNumber = textData.Length;

        // �Q�����z��̒�`
        dungeonMap = new string[tateNumber, yokoNumber];

        for (int i = 0; i < tateNumber; i++)
        {
            string[] tempWords = textData[i].Split(',');

            for (int j = 0; j < yokoNumber; j++)
            {
                dungeonMap[i, j] = tempWords[j];

                if (dungeonMap[i, j] != null)
                {
                    switch (dungeonMap[i, j])
                    {
                        case "1":
                            Instantiate(floorPrefab, new Vector2(-4.5f + j, -1.5f + i), Quaternion.identity);
                            break;

                        case "2":
                            Instantiate(wallPrefab, new Vector2(-4.5f + j, -1.5f + i), Quaternion.identity);
                            break;

                        case "3":
                            Instantiate(goalPrefab, new Vector2(-4.5f + j, -1.5f + i), Quaternion.identity);
                            break;

                        case "4":
                            Instantiate(startPrefab, new Vector2(-4.5f + j, -1.5f + i), Quaternion.identity);
                            break;
                    }
                }
            }
        }
    }
}
