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
        if (Instance.State == GameState.Start)
        {
            Instance.State = GameState.InGame;
        }
        if (Instance.State == GameState.Clear || Instance.State == GameState.GameOver)
        {
            Instance.State = GameState.Start;
        }
        SceneManager.LoadScene(_sceneName);
    }
}
