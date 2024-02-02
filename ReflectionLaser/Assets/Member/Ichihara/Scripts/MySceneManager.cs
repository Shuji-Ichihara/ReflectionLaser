using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーンの種類
/// </summary>
public enum SceneType
{
    // TODO: 表示するシーンの数によって増減する
    Title,
    StageSelect,
    GameScene1,
    //GameScene2,
    //GameScene3,
    Result,
}

/// <summary>
/// シーン遷移を管理するクラス
/// </summary>
public class MySceneManager : SingletonMonoBehaviour<MySceneManager>
{
    // 読み込むシーンアセットの名称を格納する
    // 配列の index が若い順に読み込まれる
    [Header("読み込むシーンの名称を格納する\n配列の index が若い順に読み込まれる")]
    [SerializeField]
    private string[] _sceneNameList = { };
    // シーンの種類とシーンの名前を紐づけた連想配列
    private Dictionary<SceneType, string> _loadScenes = new Dictionary<SceneType, string>();

    protected override void Awake()
    {
        base.Awake();
        // シーンの種類と名前を紐づける
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            // _sceneNameList に格納されてあるシーン名の要素数が
            // BuildSettings の Scene In Build に設定しているシーンの数より少ない場合、プレイを中止する
            try
            {
                _loadScenes.Add((SceneType)i, _sceneNameList[i]);
            }
            catch (IndexOutOfRangeException)
            {
#if UNITY_EDITOR
                Debug.LogError($"設定されているシーン名の数が不足しています。\n" +
                               $"このスクリプトに設定されているシーンの数は{_sceneNameList.Length}、" +
                               $"Build Settings に設定されているシーンの数は{SceneManager.sceneCountInBuildSettings}です。");
                UnityEditor.EditorApplication.isPlaying = false;
#endif
                throw;
            }
        }
        DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += FadeController.Instance.InstantiateCanvas;
    }

    private void Update()
    {
        // テストスクリプト
        // ビルド時には要コメントアウト
        //if (Input.GetKeyDown(KeyCode.X))
        //    ChangeSceneAsync(SceneType.Title);
        //if (Input.GetKeyDown(KeyCode.C))
        //    ChangeSceneAsync(SceneType.StageSelect);
        //if (Input.GetKeyDown(KeyCode.V))
        //    ChangeSceneAsync(SceneType.GameScene1);
        //if (Input.GetKeyDown(KeyCode.B))
        //    ChangeSceneAsync(SceneType.Result);

        // ゲーム終了
        if (Input.GetKeyDown(KeyCode.Escape))
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();            
#endif
    }

    /// <summary>
    /// シーン遷移を行う関数
    /// 基本的にこの関数を呼び出す
    /// </summary>
    /// <param name="type">呼び出したいシーンに応じた SceneType 変数</param>
    public async void ChangeSceneAsync(SceneType type)
    {
        var cts = new CancellationTokenSource();
        await FadeController.Instance.CallFadeInTransition(cts: cts);
        LoadSceneAsyncWrap(type);
    }

    /// <summary>
    /// SceneManager.LoadScene に引数を与え、ラップした関数
    /// </summary>
    /// <param name="type">読み込むシーンの種類</param>
    private void LoadSceneAsyncWrap(SceneType type)
    {
        var sceneName = _loadScenes[type];
        SceneManager.LoadSceneAsync(sceneName);
    }
}
