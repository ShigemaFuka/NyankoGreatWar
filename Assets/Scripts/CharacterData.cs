using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CharacterData")]
// インスペクター上に表示 
[Serializable]

/// <summary>
/// キャラのデータ 
/// スコアは敵キャラしか使わないかも
/// </summary>
public class CharacterData : ScriptableObject
{
    [SerializeField, Tooltip("int型")] Ids id;
    public Ids Id { get { return id; } }
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
    [SerializeField, Tooltip("このキャラを生成するために必要なコスト")] int cost;
    [SerializeField, Tooltip("制作時用の説明文"), TextArea(1, 5)] string info;
    public enum Ids
    {
        Mouse,
        Tiger,
        Cow,
        Dragon,
        Rabbit,
        None
    }
}
