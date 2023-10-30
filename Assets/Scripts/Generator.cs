using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 一定時間おきに指定したプレハブから GameObject を生成するコンポーネント
/// この中にボタンクリック時に、フラグを真にする関数を入れている
/// </summary>
public class Generator : MonoBehaviour
{
    [SerializeField, Tooltip("スポーン場所")] GameObject _gameObject;
    [SerializeField, Tooltip("ゲージUI_インターバルに依存")] Slider _slider;
    [SerializeField, Tooltip("ボタンがクリックされた")] bool _isClick;
    [SerializeField, Tooltip("タイマー計測用変数")] float _timer;
    [SerializeField, Tooltip("true の場合、開始時にすぐ生成する")] bool _generateOnStart = true;
    [SerializeField, Tooltip("生成物を置いておく空の親オブジェクト")] GameObject _emptyParent;
    [SerializeField, Tooltip("コスト管理スクリプト")] CostController _costController;
    [Tooltip("ボタンを暗くするUI(クリック判定なし)")] RawImage _darkMask;
    [SerializeField, Tooltip("準備したか")] bool _isPrepare;
    [SerializeField, Tooltip("コストを表示するテキスト")] Text _costText;
    [SerializeField, Tooltip("ボタンなどの機能が付いているゲームオブジェクト")] GameObject _gameObjectOfButton;
    [Tooltip("時間経過前にフラグ真にするのを防ぐ")] Button _button;
    [Header("GMがセットするor参照する")]
    [SerializeField, Tooltip("一定時間おきに生成するプレハブ")] public GameObject _prefab = default;
    [SerializeField, Tooltip("見かけ上のボタンのUI")] public Image _image = null;
    [SerializeField, Tooltip("生成する間隔（秒）")] public float _interval = 1f;
    [Space]
    [Header("プレハブに依存")]
    [SerializeField, Tooltip("キャラ生成にかかるコスト(プレハブのコストに依存)")] float _cost;

    void Start()
    {
        _isPrepare = false;
        _button = _gameObjectOfButton.GetComponent<Button>();
        _darkMask = _gameObjectOfButton.transform.Find("DarkMask").GetComponent<RawImage>();
        _costText = _gameObjectOfButton.transform.Find("Cost_Text").GetComponent<Text>();
        _slider = _gameObjectOfButton.transform.Find("Gage_Slider").GetComponent<Slider>();
        var markImage = _gameObjectOfButton.transform.Find("Mark").GetComponent<Image>();
        markImage.sprite = _image.sprite;
    }

    void Update()
    {
        if (!_isPrepare)
        {
            Prepare();
            _isPrepare = true;
        }
        Generate();
    }

    public void OnClick()
    {
        // ボタンクリック時
        if(_isClick == false)
        {
            _isClick = true;
        }
    }

    void Generate()
    {
        // Time.deltaTimeは「前フレームからの経過時間」を取得する
        _timer += Time.deltaTime;

        // 「経過時間」が「生成する間隔」を超えたら
        if (_costController.JudgeCostValue(_cost) && _timer > _interval)
        {
            _button.enabled = true;
            _darkMask.enabled = false;
            if (_isClick)
            {
                _timer = 0;    // タイマーをリセットしている
                Instantiate(_prefab, _gameObject.transform.position, Quaternion.identity, _emptyParent.transform);
                _costController.UseNowHadCost(_cost);
                _isClick = false;
                _button.enabled = false;
                _darkMask.enabled = true;
            }
        }
        else if (!_costController.JudgeCostValue(_cost))
        {
            _button.enabled = false;
            _darkMask.enabled = true;
        }
        _slider.value = _timer;
    }

    /// <summary>
    /// start関数で行うと、GMのupdate関数の処理の前に呼ばれてしまうため、
    /// その処理が終わってから、こちらの準備をする
    /// プレハブに応じてコストを変更・インターバルはＧＭ側が変更する
    /// </summary>
    void Prepare()
    {
        _darkMask.enabled = true;
        Move move = _prefab.GetComponent<Move>();
        _cost = move.CharacterData.Cost;
        _costText.text = _cost.ToString();
        if (_slider)
        {
            _slider.maxValue = _interval;
            _slider.value = 0;
        }
        _button.enabled = false;
        if (_generateOnStart)
        {
            _timer = _interval;
            _button.enabled = true;
        }
    }
}