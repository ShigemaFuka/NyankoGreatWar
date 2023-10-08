using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// シーン遷移する関数を書いており、他のスクリプトが必要に応じて参照
/// コスト計算のための、時間計算をし、参照できるようにする
/// InGame内でのTimerFlag切り替えは、コスト計算スクリプトで行う
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField, Tooltip("フェードアウト後にシーン遷移")] FadeOutIn _fadeOut = default;
    public static GameManager Instance = default;
    [SerializeField] static GameState _state = GameState.InGame;
    public GameState State { get => _state; set => _state = value; }
    //[SerializeField, Tooltip("コスト計算用の時間加算")] float _timer = 0f;
    //public float Timer { get => _timer; set => _timer = value; }
    //[SerializeField, Tooltip("コスト計算用の時間加算フラグ")] bool _timerFlag;
    //public bool TimerFlag { get => _timerFlag; set => _timerFlag = value; }

    public enum GameState
    {
        Start,
        /// <summary> スタートから3秒カウントし、InGameに遷移 </summary>
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
    /// デバッグ時、どこから初めてもいいように、適宜ステートを変更する 
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
            // 2周目はNullになった  
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
        else Debug.Log(_fadeOut + " がない state = GameOver");
        _state = GameState.GameOver;
    }
}
