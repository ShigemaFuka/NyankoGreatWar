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
            Instance.State = GameState.Prepare;
            Debug.Log("Start->Prepare");
        }
        else if (Instance.State == GameState.Prepare)
        {
            Instance.State = GameState.InGame;
            Debug.Log("Prepare->InGame");
        }
        else if (Instance.State == GameState.Clear || Instance.State == GameState.GameOver)
        {
            Instance.State = GameState.Start;
            Debug.Log("Clear||GameOver->Start");
        }
        SceneManager.LoadScene(_sceneName);
    }
}
