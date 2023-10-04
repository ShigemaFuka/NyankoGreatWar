using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 一定時間おきに指定したプレハブから GameObject を生成するコンポーネント
/// </summary>
public class Generator : MonoBehaviour
{
    /// <summary>一定時間おきに生成する GameObject の元となるプレハブ</summary>
    [SerializeField] GameObject _prefab = default;
    /// <summary>生成する間隔（秒）</summary>
    [SerializeField] float _interval = 1f;
    /// <summary>true の場合、開始時にまず生成する</summary>
    [SerializeField] bool _generateOnStart = true;
    /// <summary>タイマー計測用変数</summary>
    [SerializeField] float _timer;
    [SerializeField, Tooltip("ボタンがクリックされた")] bool _isClick;
    [SerializeField, Tooltip("スポーン場所")] GameObject _gameObject;
    [SerializeField, Tooltip("クリックできるかUI")] Slider _slider;
    [SerializeField, Tooltip("時間経過まえにフラグ真にするのを防ぐ")] Button _button;

    void Start()
    {

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
        if (_timer > _interval)
        {
            _button.enabled = true;
            if (_isClick)
            {
                _timer = 0;    // タイマーをリセットしている
                Instantiate(_prefab, _gameObject.transform.position, Quaternion.identity);
                _isClick = false;
                _button.enabled = false;
            }
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