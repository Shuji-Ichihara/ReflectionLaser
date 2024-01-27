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
    /// FadeInTransition ���Ăяo���֐�
    /// </summary>
    /// <param name="fadeTime">�t�F�[�h�����Ɋ|���鎞��</param>
    public void CallFadeInTransition(float fadeTime = 0f)
    {
        // �O�����Z�q��p���āA�O������t�F�[�h�̕b�����w��ł���悤�ɂ���
        fadeTime = fadeTime <= 0f ? _defaultFadeTime : fadeTime;
        StartCoroutine(FadeInTransition(_fadeMaterial, fadeTime));
    }

    /// <summary>
    /// FadeOutTransition ���Ăяo���֐�
    /// </summary>
    /// <param name="fadeTime">�t�F�[�h�����Ɋ|���鎞��</param>
    public void CallFadeOutTransition(float fadeTime = 0f)
    {
        // �O�����Z�q��p���āA�O������t�F�[�h�̕b�����w��ł���悤�ɂ���
        fadeTime = fadeTime <= 0f ? _defaultFadeTime : fadeTime;
        StartCoroutine(FadeOutTransition(_fadeMaterial, fadeTime));
    }

    /// <summary>
    /// �t�F�[�h�C������
    /// </summary>
    /// <param name="material">���[���摜��K�p�����}�e���A��</param>
    /// <param name="fadeTime">�t�F�[�h�����ɂ�����b��</param>
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
    /// �t�F�[�h�A�E�g����
    /// </summary>
    /// <param name="material">���[���摜��K�p�����}�e���A��</param>
    /// <param name="fadeTime">�t�F�[�h�����ɂ�����b��</param>
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
