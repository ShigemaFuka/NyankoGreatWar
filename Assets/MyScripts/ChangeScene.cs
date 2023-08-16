using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField, Tooltip("�J�ڐ�")] string _sceneName;

    public void OnClick()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
