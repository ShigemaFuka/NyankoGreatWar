using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// キャラのパラメータを、マウスカーソルをかざしたときに、表示する
/// かざされたら、関数を呼び出す
/// 関数の処理内容：値を取り出して、各パラメータ表示テキストに、Stringで値を渡す
/// パラメータの親オブジェクトに、このスクリプトを持たせ、各キャラのアイコンのUnityEventから呼び出す
/// </summary>
public class TakeAndShowParamator : MonoBehaviour
{
    [SerializeField, Tooltip("攻撃値")] Text _attack;
    [SerializeField, Tooltip("体力値")] Text _hp;
    [SerializeField, Tooltip("生成コスト")] Text _cost;
    [SerializeField, Tooltip("移動速度")] Text _speed;
    [SerializeField, Tooltip("吹き飛び度")] Text _selfImpactPower;
    [SerializeField, Tooltip("生成インターバル")] Text _interval;
    [SerializeField, Tooltip("キャラデータ一覧（インターバル参照のため）")] CharacterDataAchievementList _characterDataAchievementList = null;

    /// <summary>
    /// テキストを初期化（値の非表示）
    /// </summary>
    void Start()
    {
        _attack.text = "";
        _hp.text = "";
        _cost.text = "";
        _speed.text = "";
        _selfImpactPower.text = "";
        _interval.text = "";
    }

    /// <summary>
    /// 各キャラのアイコンにマウスカーソルが、
    /// かざされたときに呼ばれる関数
    /// </summary>
    /// <param name="cData">CharaIdsにアタッチした各キャラのデータ</param>
    public void SetParamator(CharacterData cData)
    {
        _attack.text = cData.Attack.ToString();
        _hp.text = cData.Maxhp.ToString();
        _cost.text = cData.Cost.ToString();
        _speed.text = cData.Speed.ToString();
        _selfImpactPower.text = cData.SelfImpactPower.ToString();
    }

    /// <summary>
    /// idで_characterDataAchievementListから検索して、インターバルを取得させる
    /// </summary>
    /// <param name="charaIds">アイコンキャラにアタッチしたCharaIdsスクリプト</param>
    public void SetInterval(CharaIds charaIds)
    {
        for (var i = 0; i < _characterDataAchievementList.achievementList.Count; i++)
        {
            if (_characterDataAchievementList.achievementList[i].Id.ToString() == charaIds._characterData.Id.ToString())
                _interval.text = _characterDataAchievementList.achievementList[i].Interval.ToString();        
        }
    }

    public void Reset()
    {
        Start();
    }
}
