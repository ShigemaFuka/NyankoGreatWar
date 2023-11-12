using UnityEngine;
using UnityEngine.SceneManagement;

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
