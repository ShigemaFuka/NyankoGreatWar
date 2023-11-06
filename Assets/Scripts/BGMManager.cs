using UnityEngine;

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
    AudioClip _clip;

    void Start()
    {
        
    }

    public void PlayBGM()
    {
        if (GameManager.Instance.State == GameManager.GameState.Start)
        {
            _clip = _onTittle;
        }
        else if (GameManager.Instance.State == GameManager.GameState.InGame)
        {
            //_audioSource.PlayOneShot(_onBattle);
            _clip = _onBattle;
        }
        else if (GameManager.Instance.State == GameManager.GameState.Clear)
        {
            _clip = _onClear;
        }
        else if (GameManager.Instance.State == GameManager.GameState.GameOver)
        {
            _clip = _onGameOver;
        }
        _audioSource.clip = _clip;
        _audioSource.Play();
    }
}
