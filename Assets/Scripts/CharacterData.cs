using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CharacterData")]
// �C���X�y�N�^�[��ɕ\�� 
[Serializable]

/// <summary>
/// �L�����̃f�[�^ 
/// �X�R�A�͓G�L���������g��Ȃ�����
/// </summary>
public class CharacterData : ScriptableObject
{
    [SerializeField, Tooltip("int�^")] Ids id;
    public Ids Id { get { return id; } }
    [SerializeField] int maxHp;
    public int Maxhp { get { return maxHp; } }
    [SerializeField, Tooltip("�Œ��ATK�l")] int attack;
    public int Attack { get { return attack; } }
    [SerializeField] float speed;
    public float Speed { get { return speed; } }
    [SerializeField, Tooltip("���̃L�������L�������Ƃ��̃X�R�A")] int score;
    public int Score { get { return score; } }
    [SerializeField, Tooltip("�G�L�����ڐG���Ɏ��g���ǂꂭ�炢������Ԃ�")] float selfImpactPower;
    public float SelfImpactPower { get { return selfImpactPower; } }
    public float Cost { get { return cost; } }
    [SerializeField, Tooltip("���̃L�����𐶐����邽�߂ɕK�v�ȃR�X�g")] int cost;
    [SerializeField, Tooltip("���쎞�p�̐�����"), TextArea(1, 5)] string info;
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
