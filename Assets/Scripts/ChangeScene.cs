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
            Instance.State = GameState.InGame;
        }
        if (Instance.State == GameState.Clear || Instance.State == GameState.GameOver)
        {
            Instance.State = GameState.Start;
        }
        SceneManager.LoadScene(_sceneName);
    }
}
