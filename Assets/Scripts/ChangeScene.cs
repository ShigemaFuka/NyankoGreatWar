using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;

/// <summary>
/// �Q�[���̃X�e�[�g��ς��A�V�[���J�ڂ���
/// Start�V�[����InGame�V�[���AClear�V�[����Start�V�[���AGameOver�V�[����Start�V�[��
/// </summary>
public class ChangeScene : MonoBehaviour
{
    [SerializeField, Tooltip("�J�ڐ�")] string _sceneName;

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
