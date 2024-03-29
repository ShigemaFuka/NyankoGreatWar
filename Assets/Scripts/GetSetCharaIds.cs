using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 子オブジェクトのIdを取得し、GMの変数に入れる
/// </summary>
public class GetSetCharaIds : MonoBehaviour
{
    [SerializeField, Tooltip("選択されたId")] List<string> _ids;

    /// <summary>
    /// GMの変数にIdを入れる
    /// </summary>
    public void OnClick()
    {
        GetSetIds();
    }

    /// <summary>
    /// 空オブジェクトに配置（子オブジェクト化）したものを
    /// パーティーに選択したとみなし、IDだけ設定したスクリプトのID読み取り、
    /// 文字列の配列に入れたあと、GMの文字列のリストに入れる
    /// パーティーの上限だけ繰り返す
    /// </summary>
    void GetSetIds()
    {
        for (var i = 0; i < _ids.Count; i++)
        {
            var go = transform.GetChild(i);
            var charaIds = go.GetComponent<CharaIds>()._characterData;
            this._ids[i] = charaIds.Id.ToString();
            GameManager.Instance.IDs.Add(this._ids[i]); 
        }
    }
}
