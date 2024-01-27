using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    private TextAsset textFile;

    private string[] textData;
    private string[,] dungeonMap;

    private int tateNumber; // 行数に相当
    private int yokoNumber; // 列数に相当

    [SerializeField]
    private GameObject floorPrefab;
    [SerializeField]
    private GameObject wallPrefab;
    [SerializeField]
    private GameObject goalPrefab;

    private void Start()
    {
        string textLines = textFile.text; // テキストの全体データの代入

        // 改行でデータを分割して配列に代入
        textData = textLines.Split('\n');

        // 行数と列数の取得
        yokoNumber = textData[0].Split(',').Length;
        tateNumber = textData.Length;

        // ２次元配列の定義
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
                    }
                }
            }
        }
    }
}
