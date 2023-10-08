using UnityEngine;

/// <summary>
/// 一定時間おきに敵キャラを生成する
/// インターバルの範囲を定め、その範囲内でランダムな時間おきに生成する
/// 一回目のインターバルはインスペクター上で設定した_intervalが該当する
/// </summary>
public class EnemyGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("一定時間おきに生成するプレハブ")] GameObject _prefab = default;
    [SerializeField, Tooltip("生成する間隔（秒）")] float _interval = 1f;
    [SerializeField, Tooltip("true の場合、開始時にすぐ生成する")] bool _generateOnStart = true;
    [Tooltip("タイマー計測用変数")] float _timer;
    [SerializeField, Tooltip("スポーン場所")] GameObject _gameObject;
    [SerializeField, Tooltip("範囲の最小値")] float _minRange = 0f;
    [SerializeField, Tooltip("範囲の最大値")] float _maxRange = 5f;

    void Start()
    {
        if (_generateOnStart)
        {
            _timer = _interval;
        }
    }

    public void Update()
    {
        // Time.deltaTime は「前フレームからの経過時間」を取得する
        _timer += Time.deltaTime;
        // 「経過時間」が「生成する間隔」を超えたら
        if (_timer > _interval)
        {
            _timer = 0;    // タイマーをリセットしている
            Instantiate(_prefab, _gameObject.transform.position, Quaternion.identity);
            _interval = Random.Range(_minRange, _maxRange);
        }
    }
}