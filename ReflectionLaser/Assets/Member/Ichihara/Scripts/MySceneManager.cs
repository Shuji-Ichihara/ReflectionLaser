using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーンの種類
/// </summary>
public enum SceneType
{
    Title,
    StageSelect,
    Game,
    Result,
}

public class MySceneManager : SingletonMonoBehaviour<MySceneManager>
{
    // 読み込むシーンの名称を格納する
    // 配列の index が若い順に読み込まれる
    [Header("読み込むシーンの名称を格納する\n配列の index が若い順に読み込まれる")]
    [SerializeField]
    private string[] _sceneNameList = { };
    // シーンの種類とシーンの名前を紐づけた連想配列
    private Dictionary<SceneType, string> _loadScenes = new Dictionary<SceneType, string>()
            {
                { SceneType.Title,       string.Empty},
                { SceneType.StageSelect, string.Empty},
                { SceneType.Game,        string.Empty},
                { SceneType.Result,      string.Empty},
            };

    protected override void Awake()
    {
        base.Awake();
        // シーンの種類と名前を紐づける
        for (int i = 0; i < _sceneNameList.Length; i++)
        {
            _loadScenes[(SceneType)i] = _sceneNameList[i];
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        // テスト用スクリプト
        if (Input.GetKeyDown(KeyCode.Q))
            LoadSceneRap(SceneType.Title);
        if (Input.GetKeyDown(KeyCode.W))
            LoadSceneRap(SceneType.StageSelect);
        if (Input.GetKeyDown(KeyCode.D))
            LoadSceneRap(SceneType.Game);
        if (Input.GetKeyDown(KeyCode.R))
            LoadSceneRap(SceneType.Result);
    }

    /// <summary>
    /// SceneManager.LoadScene に引数を与え、ラップした関数
    /// シーンを読み込むタイミングでこの関数を呼び出す
    /// </summary>
    /// <param name="type">読み込むシーンの種類</param>
    public void LoadSceneRap(SceneType type)
    {
        var sceneName = _loadScenes[type];
        SceneManager.LoadScene(sceneName);
    }
}
