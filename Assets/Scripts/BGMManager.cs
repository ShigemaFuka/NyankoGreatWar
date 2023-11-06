using UnityEngine;

/// <summary>
/// GMのGameState次第で流すBGMを変える
/// </summary>
public class BGMManager : MonoBehaviour
{
    [SerializeField, Tooltip("タイトル画面のBGM")] AudioClip _onTittle;
    [SerializeField, Tooltip("戦闘画面のBGM")] AudioClip _onBattle;
    [SerializeField, Tooltip("クリア画面のBGM")] AudioClip _onClear;
    [SerializeField, Tooltip("ゲームオーバー画面のBGM")] AudioClip _onGameOver;
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
