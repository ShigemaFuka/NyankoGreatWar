using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance = default;
    public enum GameState
    {
        Start,
        /// <summary> �X�^�[�g����3�b�J�E���g���AInGame�ɑJ�� </summary>
        Prepare,
        InGame,
        /// <summary> �Q�[���I�[�o�[�E�Q�[���N���A </summary>
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
