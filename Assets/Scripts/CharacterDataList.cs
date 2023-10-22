using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObject/CharacterDataList")]
// インスペクター上に表示 
[Serializable]

/// <summary>
/// キャラのデータのリスト 
/// スコアは敵キャラしか使わないかも
/// </summary>


public class CharacterDataList : ScriptableObject
{
    public List<Achievement> achievementList = new List<Achievement>();
}

[Serializable]
public class Achievement
{
    // public class CharacterDataList : ScriptableObject
    //{
    [SerializeField] Ids id;
    public Ids Id { get => id; set => id = value; }
    [SerializeField] int maxHp;
    public int Maxhp { get { return maxHp; } }
    [SerializeField, Tooltip("固定のATK値")] int attack;
    public int Attack { get { return attack; } }
    [SerializeField] float speed;
    public float Speed { get { return speed; } }
    [SerializeField, Tooltip("このキャラをキルしたときのスコア")] int score;
    public int Score { get { return score; } }
    [SerializeField, Tooltip("敵キャラ接触時に自身がどれくらい吹き飛ぶか")] float selfImpactPower;
    public float SelfImpactPower { get { return selfImpactPower; } }
    public float Cost { get { return cost; } }
    [SerializeField, Tooltip("このキャラを生成するために必要なコスト")] float cost;
    [SerializeField, Tooltip("ボタン用の画像")] Sprite charaImage;
    public Sprite CharaImage { get { return charaImage; } }
    [SerializeField, Tooltip("プレハブ")] GameObject prefab;
    public GameObject Prefab { get { return prefab; } }
    public float Interval { get { return interval; } }
    [SerializeField, Tooltip("このキャラを生成するために必要なコスト")] float interval;
    [SerializeField, Tooltip("制作時用の説明文"), TextArea(1, 5)] string info;
    public enum Ids
    {
        Mouse,
        Tiger,
        Cow,
        Dragon,
        None
    }
}
