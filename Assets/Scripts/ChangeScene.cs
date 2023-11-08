using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;

/// <summary>
/// ゲームのステートを変えつつ、シーン遷移する
/// Startシーン→InGameシーン、Clearシーン→Startシーン、GameOverシーン→Startシーン
/// </summary>
public class ChangeScene : MonoBehaviour
{
    [SerializeField, Tooltip("遷移先")] string _sceneName;

    public void OnClick()
    {
        //GMでStateがInGameにならなかった
        if (_sceneName == "Test")
        {
            GameManager.Instance.State = GameState.InGame;
        }
        SceneManager.LoadScene(_sceneName);
    }
}
