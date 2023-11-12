using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// GM��GameState����ŗ���BGM��ς���
/// </summary>
public class BGMManager : MonoBehaviour
{
    [SerializeField, Tooltip("�^�C�g����ʂ�BGM")] AudioClip _onTittle;
    [SerializeField, Tooltip("�퓬��ʂ�BGM")] AudioClip _onBattle;
    [SerializeField, Tooltip("�N���A��ʂ�BGM")] AudioClip _onClear;
    [SerializeField, Tooltip("�Q�[���I�[�o�[��ʂ�BGM")] AudioClip _onGameOver;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _clip;

    void Start()
    {

    }
    public void PlayedBGM(Scene nextScene, Scene mode)
    {
        PlayBGM();
    }
    public void PlayBGM()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Start":
                _clip = _onTittle;
                break;
            case "Test":
                _clip = _onBattle;
                break;
            case "Clear":
                _clip = _onClear;
                break;
            case "GameOver":
                _clip = _onGameOver;
                break;
        }
        if (_audioSource)
        {
            //_audioSource.Stop();
            _audioSource.clip = _clip;
            _audioSource.Play();
        }
    }
}
