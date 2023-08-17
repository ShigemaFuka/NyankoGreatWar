using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField, Tooltip("�t�F�[�h�A�E�g��ɃV�[���J��")] FadeOutIn _fadeOut = default; 
    public static GameManager Instance = default;
    [SerializeField] static GameState _state = GameState.InGame;
    public GameState State { get => _state; set => _state = value; }

    public enum GameState
    {
        Start,
        /// <summary> �X�^�[�g����3�b�J�E���g���AInGame�ɑJ�� </summary>
        Prepare,
        InGame,
        Clear,
        GameOver
    }

    void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// �f�o�b�O���A�ǂ����珉�߂Ă������悤�ɁA�K�X�X�e�[�g��ύX���� 
    /// </summary>
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Start")
        {
            _state = GameState.Start;
        }
        if (SceneManager.GetActiveScene().name == "Test")
        {
            _state = GameState.InGame; 
        }
        if (SceneManager.GetActiveScene().name == "Clear")
        {
            _state = GameState.Clear;
        }
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            _state = GameState.GameOver;
        }
    }
    void Update()
    {
        if(_state == GameState.Prepare)
        {

        }
        if(_state == GameState.InGame)
        {
            if(!_fadeOut) _fadeOut = FindAnyObjectByType<FadeOutIn>();
        }
        if(_state == GameState.Clear)
        {

        }
        if (_state == GameState.GameOver)
        {
            
        }
    }

    public void ToClear()
    {
        if (_fadeOut) _fadeOut.ToFadeOut("Clear");
        else Debug.Log(_fadeOut + " ���Ȃ� state = Clear");
        _state = GameState.Clear; 
    }
    public void ToGameOver()
    {
        if (_fadeOut) _fadeOut.ToFadeOut("GameOver");
        else Debug.Log(_fadeOut + " ���Ȃ� state = GameOver");
        _state = GameState.GameOver;
    }
}
