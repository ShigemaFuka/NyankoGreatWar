using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Tooltip("フェードアウト後にシーン遷移")] FadeOutIn _fadeOut = default; 
    public static GameManager Instance = default;
    [SerializeField] GameState _state = GameState.Start; 
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
    void Start()
    {
        //_fadeOut = FindAnyObjectByType<FadeOutIn>();
        //if (_state == GameState.Start)
        //{
        //    _fadeOut.ToFadeIn();
        //}
    }
    private void OnEnable()
    {
        _fadeOut = FindAnyObjectByType<FadeOutIn>();
        if (_state == GameState.Start)
        {
            _fadeOut.ToFadeIn();

        }
    }
    public void Action(GameState state)
    {
        
        if(state == GameState.Prepare)
        {

        }
        if(state == GameState.InGame)
        {
            
        }
        if(state == GameState.Clear)
        {
            if (_fadeOut) _fadeOut.ToFadeOut("Clear");
            else Debug.Log("state = Clear");
        }
        if(state == GameState.GameOver)
        {
            if (_fadeOut) _fadeOut.ToFadeOut("GameOver");
            else Debug.Log("state = GameOver");
        }
    }
    void StartAction()
    {

    }
}
