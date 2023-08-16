using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField, Tooltip("‘JˆÚæ")] string _sceneName;

    public void OnClick()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
