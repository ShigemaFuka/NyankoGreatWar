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
    static GameState _state = GameState.InGame;
    public GameState State { get => _state; set => _state = value; }
    [SerializeField, Tooltip("�I�����ꂽId")] List<string> _ids;
    public List<string> IDs { get => _ids; set => _ids = value; }
    [SerializeField] CharacterDataAchievementList _characterDataList = default;
    //[SerializeField] CharaDataList _charaDataList = default;
    [SerializeField, Tooltip("�W�F�l���[�^�[")] GameObject[] _generators = new GameObject[3];
    [SerializeField, Tooltip("�W�F�l���[�^�[���擾�������̃t���O")] bool _isGet;

    [Tooltip("�C���X�^���X���擾���邽�߂̃p�u���b�N�ϐ�")] public static GameManager Instance = default;
    [Tooltip("Generators�Ƃ������O�̐e�I�u�W�F�N�g")] GameObject go;

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
        // ���̏����� Start() �ɏ����Ă��悢���AAwake() �ɏ������Ƃ������B
        // �Q�l: �C�x���g�֐��̎��s���� https://docs.unity3d.com/ja/2019.4/Manual/ExecutionOrder.html
        if (Instance)
        {
            // �C���X�^���X�����ɂ���ꍇ�́A�j������
            Debug.LogWarning($"SingletonSystem �̃C���X�^���X�͊��ɑ��݂���̂ŁA{gameObject.name} �͔j�����܂��B");
            Destroy(this.gameObject);
        }
        else
        {
            // ���̃N���X�̃C���X�^���X�����������ꍇ�́A������ DontDestroyOnload �ɒu��
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        //Debug.LogWarning(SceneManager.GetActiveScene().name);
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
                go = GameObject.FindWithTag("Generators");
                if(go) SetGeneratorAndCompareId();
                _isGet = true;
            }
            //Debug.Log("IDs.Count: " + IDs.Count);
        }
        else if(State == GameState.Clear)
        {
            IDs.Clear(); //���������Ȃ��ƃ��X�g�̗v�f������
        }
        else if (State == GameState.GameOver)
        {
            IDs.Clear();
        }
        //Debug.Log("State: " + State);
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
        var childCount = go.transform.childCount;
        //Debug.Log("childCount : " + childCount);
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
            //Debug.Log("IDs: " + IDs[i]);
            // �L�����̃f�[�^���X�g�̊eID�ƈ�v���Ă�����
            for (var j = 0; j < _characterDataList.achievementList.Count; j++)
            {
                if (_characterDataList.achievementList[j].Id.ToString() == IDs[i].ToString())
                {
                    //���X�g�̃v���n�u���e�W�F�l���[�^�[�̃v���n�u���i�[�����ϐ��ɓ����
                    var generator = _generators[i].GetComponent<Generator>();
                    generator._prefab = _characterDataList.achievementList[j].Prefab;
                    generator._image.sprite = _characterDataList.achievementList[j].CharaImage;
                    var sp = generator._image.GetComponent<Image>();
                    if (!sp.sprite) sp.sprite = _characterDataList.achievementList[j].CharaImage;
                    //Debug.Log("sp.sprite : " + sp.sprite);
                    generator._interval = _characterDataList.achievementList[j].Interval;
                }
            }
        }
    }
}
