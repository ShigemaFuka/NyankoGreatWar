using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// シーン遷移する関数を書いており、他のスクリプトが必要に応じて参照
/// コスト計算のための、時間計算をし、参照できるようにする
/// InGame内でのTimerFlag切り替えは、コスト計算スクリプトで行う
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField, Tooltip("フェードアウト後にシーン遷移")] FadeOutIn _fadeOut = default;
    static GameState _state = GameState.InGame;
    public GameState State { get => _state; set => _state = value; }
    [SerializeField, Tooltip("選択されたId")] List<string> _ids;
    public List<string> IDs { get => _ids; set => _ids = value; }
    [SerializeField] CharacterDataAchievementList _characterDataList = default;
    //[SerializeField] CharaDataList _charaDataList = default;
    [SerializeField, Tooltip("ジェネレーター")] GameObject[] _generators = new GameObject[3];
    [SerializeField, Tooltip("ジェネレーターを取得したかのフラグ")] bool _isGet;

    [Tooltip("インスタンスを取得するためのパブリック変数")] public static GameManager Instance = default;
    [Tooltip("Generatorsという名前の親オブジェクト")] GameObject go;

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
        // この処理は Start() に書いてもよいが、Awake() に書くことが多い。
        // 参考: イベント関数の実行順序 https://docs.unity3d.com/ja/2019.4/Manual/ExecutionOrder.html
        if (Instance)
        {
            // インスタンスが既にある場合は、破棄する
            Debug.LogWarning($"SingletonSystem のインスタンスは既に存在するので、{gameObject.name} は破棄します。");
            Destroy(this.gameObject);
        }
        else
        {
            // このクラスのインスタンスが無かった場合は、自分を DontDestroyOnload に置く
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        //Debug.LogWarning(SceneManager.GetActiveScene().name);
        _isGet = false;
        //デバッグ時用
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
            // 2周目はNullになった  
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
            IDs.Clear(); //初期化しないとリストの要素が増加
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
        else Debug.Log(_fadeOut + " がない state = GameOver");
        State = GameState.GameOver;
    }

    /// <summary>
    /// 親オブジェクトにタグを付けている
    /// 子オブジェクトにジェネレータースクリプトが付いている
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
    /// ジェネレーターに
    /// 生成するプレハブ・見かけ上のボタンの画像・生成インターバル
    /// を入れる
    /// </summary>
    void SetGeneratorAndCompareId()
    {
        GetGenerators();
        for (var i = 0; i < IDs.Count; i++)
        {
            //Debug.Log("IDs: " + IDs[i]);
            // キャラのデータリストの各IDと一致していたら
            for (var j = 0; j < _characterDataList.achievementList.Count; j++)
            {
                if (_characterDataList.achievementList[j].Id.ToString() == IDs[i].ToString())
                {
                    //リストのプレハブを各ジェネレーターのプレハブを格納した変数に入れる
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
