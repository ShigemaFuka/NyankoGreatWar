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
        //GM��State��InGame�ɂȂ�Ȃ�����
        if (_sceneName == "Test")
        {
            GameManager.Instance.State = GameState.InGame;
        }
        SceneManager.LoadScene(_sceneName);
    }
}
