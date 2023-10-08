using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 一定時間おきに指定したプレハブから GameObject を生成するコンポーネント
/// </summary>
public class Generator : MonoBehaviour
{
    [SerializeField, Tooltip("一定時間おきに生成するプレハブ")] GameObject _prefab = default;
    [SerializeField, Tooltip("生成する間隔（秒）")] float _interval = 1f;
    [SerializeField, Tooltip("true の場合、開始時にすぐ生成する")] bool _generateOnStart = true;
    [SerializeField, Tooltip("タイマー計測用変数")] float _timer;
    [SerializeField, Tooltip("ボタンがクリックされた")] bool _isClick;
    [SerializeField, Tooltip("スポーン場所")] GameObject _gameObject;
    [SerializeField, Tooltip("クリックできるかUI")] Slider _slider;
    [SerializeField, Tooltip("時間経過まえにフラグ真にするのを防ぐ")] Button _button;
    [SerializeField, Tooltip("生成物を置いておく空の親オブジェクト")] GameObject _emptyParent;
    [SerializeField, Tooltip("コスト管理スクリプト")] CostController _costController;
    [SerializeField, Tooltip("キャラ生成にかかるコスト")] float _cost;
    [SerializeField, Tooltip("ボタンを暗くするUI(クリック判定なし)")] RawImage _darkMask;

    void Start()
    {
        _darkMask.enabled = true;
        Move move = _prefab.GetComponent<Move>();
        _cost = move.CharacterData.Cost;
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

    public void Update()
    {
        // Time.deltaTime は「前フレームからの経過時間」を取得する
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

    public void OnClick()
    {
        // ボタンクリック時
        if(_isClick == false)
        {
            _isClick = true;
        }
    }
}