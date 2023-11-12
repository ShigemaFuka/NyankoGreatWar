using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 子オブジェクトの数を保有しておく
/// パーティーの数を制限する
/// パーティーの選択エリア（親オブジェクト）にアタッチする
/// </summary>
public class CountChild : MonoBehaviour
{
    [SerializeField, Tooltip("パーティーの上限数")] int _maxPartyNum;
    public int MaxPartyNum { get => _maxPartyNum; set => _maxPartyNum = value; }
    [SerializeField, Tooltip("初期化")] UnityEvent _onStart;
    [SerializeField, Tooltip("MaxPartyNumになったら実行する")] UnityEvent _onThreeChara;


    void Start()
    {
        _onStart.Invoke();
    }

    /// <summary>
    /// パーティーのメンバーの数を制限するために必要な値
    /// 各自（アイコン側）でカウントすると値がおかしくなる
    /// </summary>
    /// <returns>このオブジェクトの子オブジェクトの数を返す</returns>
    public int Count()
    {
        return this.transform.childCount;
    }
    void Update()
    {
        if (Count() == MaxPartyNum)
        {
            _onThreeChara.Invoke();
        }
    }
}
