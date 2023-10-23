using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// �V�[���J�ڂ���֐��������Ă���A���̃X�N���v�g���K�v�ɉ����ĎQ��
/// �R�X�g�v�Z�̂��߂́A���Ԍv�Z�����A�Q�Ƃł���悤�ɂ���
/// InGame���ł�TimerFlag�؂�ւ��́A�R�X�g�v�Z�X�N���v�g�ōs��
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField, Tooltip("�t�F�[�h�A�E�g��ɃV�[���J��")] FadeOutIn _fadeOut = default;
    public static GameManager Instance = default;
    static GameState _state = GameState.InGame;
    public GameState State { get => _state; set => _state = value; }
    [SerializeField, Tooltip("�I�����ꂽId")] List<string> _ids;
    public List<string> IDs { get => _ids; set => _ids = value; }
    [SerializeField] CharacterDataList _characterDataList = default;
    [SerializeField, Tooltip("�W�F�l���[�^�[")] GameObject[] _generators = new GameObject[3];
    [SerializeField, Tooltip("�W�F�l���[�^�[���擾�������̃t���O")] bool _isGet;

    public enum GameState
    {
        Start,
        Prepare,
        InGame,
        Clear,
        GameOver
    }

    void Awake()
    {
        Instance = this;
        Debug.LogWarning(SceneManager.GetActiveScene().name);
        _isGet = false;
        //�f�o�b�O���p
        if (SceneManager.GetActiveScene().name == "Start")
        {
            State = GameState.Start;
        }
        if (SceneManager.GetActiveScene().name == "SelectParty")
        {
            State = GameState.Prepare;
        }
        if (SceneManager.GetActiveScene().name == "Test")
        {
            State = GameState.InGame;
        }
        if (SceneManager.GetActiveScene().name == "Clear")
        {
            State = GameState.Clear;
        }
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            State = GameState.GameOver;
        }
    }

    void Start()
    {
        Debug.LogWarning(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        if(State == GameState.Prepare)
        {
            _isGet = false;
        }
        else if(State == GameState.InGame)
        {
            // 2���ڂ�Null�ɂȂ���  
            if(!_fadeOut) _fadeOut = FindAnyObjectByType<FadeOutIn>();
            if (!_isGet)
            {
                SetGeneratorAndCompareId();
                _isGet = true;
            }
            Debug.Log("IDs.Count: " + IDs.Count);
        }
        else if(State == GameState.Clear)
        {
            IDs.Clear(); //���������Ȃ��ƃ��X�g�̗v�f������
        }
        else if (State == GameState.GameOver)
        {
            IDs.Clear();
        }
    }

    public void ToClear()
    {
        if (!_fadeOut) _fadeOut = FindAnyObjectByType<FadeOutIn>();
        _fadeOut.ToFadeOut("Clear");
        State = GameState.Clear; 
    }

    public void ToGameOver()
    {
        if (!_fadeOut) _fadeOut = FindAnyObjectByType<FadeOutIn>();
        if (_fadeOut) _fadeOut.ToFadeOut("GameOver");
        else Debug.Log(_fadeOut + " ���Ȃ� state = GameOver");
        State = GameState.GameOver;
    }

    /// <summary>
    /// �e�I�u�W�F�N�g�Ƀ^�O��t���Ă���
    /// �q�I�u�W�F�N�g�ɃW�F�l���[�^�[�X�N���v�g���t���Ă���
    /// </summary>
    void GetGenerators()
    {
        //���V�[�����[�h����NULL�ɂ��G���[���o��
        GameObject go = GameObject.FindWithTag("Generators");
        var childCount = go.transform.childCount;
        for (var i = 0; i < childCount; i++)
        {
            _generators[i] = go.transform.GetChild(i).gameObject;
        }
    }

    /// <summary>
    /// �W�F�l���[�^�[��
    /// ��������v���n�u�E��������̃{�^���̉摜�E�����C���^�[�o��
    /// ������
    /// </summary>
    void SetGeneratorAndCompareId()
    {
        GetGenerators();
        for (var i = 0; i < IDs.Count; i++)
        {
            Debug.Log("IDs: " + IDs[i]);
            // �L�����̃f�[�^���X�g�̊eID�ƈ�v���Ă�����
            for (var j = 0; j < _characterDataList.achievementList.Count; j++)
            {
                if (_characterDataList.achievementList[j].Id.ToString() == IDs[i].ToString())
                {
                    //���X�g�̃v���n�u���e�W�F�l���[�^�[�̃v���n�u���i�[�����ϐ��ɓ����
                    var generator = _generators[i].GetComponent<Generator>();
                    generator._prefab = _characterDataList.achievementList[j].Prefab;
                    generator._image.GetComponent<Image>().sprite = _characterDataList.achievementList[j].CharaImage;
                    generator._interval = _characterDataList.achievementList[j].Interval;
                }
            }
        }
    }
}
