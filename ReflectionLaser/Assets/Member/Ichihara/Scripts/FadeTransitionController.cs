using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeTransitionController : SingletonMonoBehaviour<FadeTransitionController>
{
    [SerializeField]
    private Canvas _fadeCanvas = null;

    [SerializeField]
    private Material _fadeMaterial = null;
    [SerializeField]
    private float _defaultFadeTime = 2f;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    /// <summary>
    /// FadeInTransition を呼び出す関数
    /// </summary>
    /// <param name="fadeTime">フェード処理に掛ける時間</param>
    public void CallFadeInTransition(float fadeTime = 0f)
    {
        // 三項演算子を用いて、外部からフェードの秒数を指定できるようにした
        fadeTime = fadeTime <= 0f ? _defaultFadeTime : fadeTime;
        StartCoroutine(FadeInTransition(_fadeMaterial, fadeTime));
    }

    /// <summary>
    /// FadeOutTransition を呼び出す関数
    /// </summary>
    /// <param name="fadeTime">フェード処理に掛ける時間</param>
    public void CallFadeOutTransition(float fadeTime = 0f)
    {
        // 三項演算子を用いて、外部からフェードの秒数を指定できるようにした
        fadeTime = fadeTime <= 0f ? _defaultFadeTime : fadeTime;
        StartCoroutine(FadeOutTransition(_fadeMaterial, fadeTime));
    }

    /// <summary>
    /// フェードイン処理
    /// </summary>
    /// <param name="material">ルール画像を適用したマテリアル</param>
    /// <param name="fadeTime">フェード処理にかける秒数</param>
    /// <returns></returns>
    private IEnumerator FadeInTransition(Material material, float fadeTime)
    {
        var image = _fadeCanvas.GetComponentInChildren<Image>();
        image.material = material;
        float currentTime = 0f;
        while (currentTime < fadeTime)
        {
            material.SetFloat("_Alpha", currentTime / fadeTime);
            yield return null;
            currentTime += Time.deltaTime;
        }
        material.SetFloat("_Alpha", 1f);
    }

    /// <summary>
    /// フェードアウト処理
    /// </summary>
    /// <param name="material">ルール画像を適用したマテリアル</param>
    /// <param name="fadeTime">フェード処理にかける秒数</param>
    /// <returns></returns>
    private IEnumerator FadeOutTransition(Material material, float fadeTime)
    {
        var image = _fadeCanvas.GetComponentInChildren<Image>();
        image.material = material;
        float currentTime = 0f;
        while (currentTime < fadeTime)
        {
            material.SetFloat("_Alpha", 1 - currentTime / fadeTime);
            yield return null;
            currentTime += Time.deltaTime;
        }
        material.SetFloat("_Alpha", 0f);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Instantiate(_fadeCanvas.gameObject);
    }
}
