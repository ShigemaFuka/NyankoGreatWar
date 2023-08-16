using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
///  ゲームオーバーやリザルトへ遷移する前に、画面を暗くする 
/// </summary>
public class FadeOutIn : MonoBehaviour
{
    [SerializeField, Tooltip("フェード用 Image")] Image _fadeImage = default; 
    [SerializeField, Tooltip("フェードアウト完了までにかかる時間（秒）")] float _fadeTime = 1;
    float _timer = 0; 
    Color c; 

    /// <summary> フェードアウトを開始する </summary>
    public void ToFadeOut(string _sceneName)
    {
        Debug.Log("コルーチンによる Fade 開始");
        StartCoroutine(FadeOutRoutine(_sceneName));
    }

    IEnumerator FadeOutRoutine(string sceneName)
    {
        // 無限ループ  
        while (true)
        {
            _timer += Time.deltaTime;
            c = _fadeImage.color;       // 現在の Image の色を取得する
            c.a = _timer / _fadeTime;   // 色のアルファを 1 に近づけていく
            _fadeImage.color = c;

            // _fadeTime が経過したら処理は終了する
            if (_timer > _fadeTime)
            {
                SceneManager.LoadScene(sceneName); 
                yield break;
            }
            // 画面更新待ち 
            yield return new WaitForEndOfFrame();
        }
    }

    /// <summary> 画面が見えるようになる(パネル非表示) </summary>
    public void ToFadeIn()
    {
        c.a = 0;
        _fadeImage.color = c;
    }
}
