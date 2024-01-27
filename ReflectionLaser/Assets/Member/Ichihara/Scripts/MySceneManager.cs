using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �V�[���̎��
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
    // �ǂݍ��ރV�[���̖��̂��i�[����
    // �z��� index ���Ⴂ���ɓǂݍ��܂��
    [Header("�ǂݍ��ރV�[���̖��̂��i�[����\n�z��� index ���Ⴂ���ɓǂݍ��܂��")]
    [SerializeField]
    private string[] _sceneNameList = { };
    // �V�[���̎�ނƃV�[���̖��O��R�Â����A�z�z��
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
        // �V�[���̎�ނƖ��O��R�Â���
        for (int i = 0; i < _sceneNameList.Length; i++)
        {
            _loadScenes[(SceneType)i] = _sceneNameList[i];
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        // �e�X�g�p�X�N���v�g
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
    /// SceneManager.LoadScene �Ɉ�����^���A���b�v�����֐�
    /// �V�[����ǂݍ��ރ^�C�~���O�ł��̊֐����Ăяo��
    /// </summary>
    /// <param name="type">�ǂݍ��ރV�[���̎��</param>
    public void LoadSceneRap(SceneType type)
    {
        var sceneName = _loadScenes[type];
        SceneManager.LoadScene(sceneName);
    }
}
