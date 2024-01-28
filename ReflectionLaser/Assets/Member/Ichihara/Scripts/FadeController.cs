using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System.Threading;

public class FadeController : SingletonMonoBehaviour<FadeController>
{
    // フェード処理に使用するキャンバス
    [SerializeField]
    private Canvas _fadeCanvas = null;
    // フェード処理に使用するマテリアル
    [SerializeField]
    private Material _fadeMaterial = null;
    // フェード処理に掛ける時間
    [SerializeField]
    private float _defaultFadeTime = 2f;
    // フェード処理用キャンバスのタグ名
    private readonly string _canvasTagName = "Fade";

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    /// <summary>
    /// FadeInTransition を呼び出す関数
    /// </summary>
    /// <param name="fadeTime">フェード処理に掛ける時間</param>
    public async UniTask CallFadeInTransition(float fadeTime = 0f, CancellationTokenSource cts = default)
    {
        // 三項演算子を用いて、外部からフェードの秒数を指定できるようにした
        fadeTime = fadeTime <= 0f ? _defaultFadeTime : fadeTime;
        await FadeInTransition(_fadeMaterial, fadeTime, cts);
    }

    /// <summary>
    /// FadeOutTransition を呼び出す関数
    /// </summary>
    /// <param name="fadeTime">フェード処理に掛ける時間</param>
    private async UniTask CallFadeOutTransition(float fadeTime = 0f, CancellationTokenSource cts = default)
    {
        // 三項演算子を用いて、外部からフェードの秒数を指定できるようにした
        fadeTime = fadeTime <= 0f ? _defaultFadeTime : fadeTime;
        await FadeOutTransition(_fadeMaterial, fadeTime, cts);
    }

    /// <summary>
    /// フェードイン処理
    /// </summary>
    /// <param name="material">ルール画像を適用したマテリアル</param>
    /// <param name="fadeTime">フェード処理にかける秒数</param>
    /// <returns></returns>
    private async UniTask FadeInTransition(Material material, float fadeTime, CancellationTokenSource cts = default)
    {
        var image = _fadeCanvas.GetComponentInChildren<Image>();
        image.material = material;
        float currentTime = 0f;
        while (currentTime < fadeTime)
        {
            // キャンセルされたら、強制的にフェードインを実行する
            if (cts.IsCancellationRequested == true) break;
            material.SetFloat("_Alpha", currentTime / fadeTime);
            await UniTask.Yield();
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
    private async UniTask FadeOutTransition(Material material, float fadeTime, CancellationTokenSource cts = default)
    {
        var image = _fadeCanvas.GetComponentInChildren<Image>();
        image.material = material;
        float currentTime = 0f;
        while (currentTime < fadeTime)
        {
            // キャンセルされたら、強制的にフェードアウトを実行する
            if (cts.IsCancellationRequested == true) break;
            material.SetFloat("_Alpha", 1 - currentTime / fadeTime);
            await UniTask.Yield();
            currentTime += Time.deltaTime;
        }
        material.SetFloat("_Alpha", 0f);
    }

    /// <summary>
    /// シーンの読み込み時に、フェード処理用のキャンバスを生成する
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    public void InstantiateCanvas(UnityEngine.SceneManagement.Scene scene,
                                  UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        var canvas = GameObject.FindGameObjectWithTag(_canvasTagName);
        if (canvas != null)
            Destroy(canvas);
        var cts = new CancellationTokenSource();
        Instantiate(_fadeCanvas.gameObject);
        CallFadeOutTransition(cts: cts).Forget();
    }
}
