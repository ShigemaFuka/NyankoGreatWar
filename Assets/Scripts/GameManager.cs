using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// �V�[���J�ڂ���֐��������Ă���A���̃X�N���v�g���K�v�ɉ����ĎQ��
/// �R�X�g�v�Z�̂��߂́A���Ԍv�Z�����A�Q�Ƃł���悤�ɂ���
/// InGame���ł�TimerFlag�؂�ւ��́A�R�X�g�v�Z�X�N���v�g�ōs��
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField, Tooltip("�t�F�[�h�A�E�g��ɃV�[���J��")] FadeOutIn _fadeOut = default;
    public static GameManager Instance = default;
    [SerializeField] static GameState _state = GameState.InGame;
    public GameState State { get => _state; set => _state = value; }
    //[SerializeField, Tooltip("�R�X�g�v�Z�p�̎��ԉ��Z")] float _timer = 0f;
    //public float Timer { get => _timer; set => _timer = value; }
    //[SerializeField, Tooltip("�R�X�g�v�Z�p�̎��ԉ��Z�t���O")] bool _timerFlag;
    //public bool TimerFlag { get => _timerFlag; set => _timerFlag = value; }

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
           // TimerFlag = true;
        } 
        //else TimerFlag = false;
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
        else if(_state == GameState.InGame)
        {
            // 2���ڂ�Null�ɂȂ���  
            if(!_fadeOut) _fadeOut = FindAnyObjectByType<FadeOutIn>();
            //if(TimerFlag) Timer += Time.deltaTime;
        }
        else if(_state == GameState.Clear)
        {

        }
        else if (_state == GameState.GameOver)
        {
            
        }
    }

    public void ToClear()
    {
        if (!_fadeOut) _fadeOut = FindAnyObjectByType<FadeOutIn>();
        _fadeOut.ToFadeOut("Clear");
        _state = GameState.Clear; 
    }
    public void ToGameOver()
    {
        if (!_fadeOut) _fadeOut = FindAnyObjectByType<FadeOutIn>();
        if (_fadeOut) _fadeOut.ToFadeOut("GameOver");
        else Debug.Log(_fadeOut + " ���Ȃ� state = GameOver");
        _state = GameState.GameOver;
    }
}
