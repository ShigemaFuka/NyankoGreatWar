using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance = default;
    public enum GameState
    {
        Start,
        /// <summary> スタートから3秒カウントし、InGameに遷移 </summary>
        Prepare,
        InGame,
        /// <summary> ゲームオーバー・ゲームクリア </summary>
        End
    }

    void Awake()
    {
        Instance = this;
    }
    void Action(GameState state)
    {
        if(state == GameState.Start)
        {
            StartAction(); 
        }
        if(state == GameState.Prepare)
        {

        }
        if(state == GameState.InGame)
        {
            
        }
        if(state == GameState.End)
        {
            EndAction();
        }
    }
    void StartAction()
    {

    }
    void EndAction()
    {

    }
}
