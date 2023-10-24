using UnityEngine;
/// <summary>
/// 子オブジェクトの数を保有しておく
/// パーティーの数を制限する
/// パーティーの選択エリア（親オブジェクト）にアタッチする
/// </summary>
public class CountChild : MonoBehaviour
{
    [SerializeField, Tooltip("パーティーの上限数")] int _maxPartyNum;
    public int MaxPartyNum { get => _maxPartyNum; set => _maxPartyNum = value; }

    /// <summary>
    /// パーティーのメンバーの数を制限するために必要な値
    /// 各自（アイコン側）でカウントすると値がおかしくなる
    /// </summary>
    /// <returns>このオブジェクトの子オブジェクトの数を返す</returns>
    public int Count()
    {
        return this.transform.childCount;
    }
}
