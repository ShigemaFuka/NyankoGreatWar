using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObject/CharacterDataList")]
// �C���X�y�N�^�[��ɕ\�� 
[Serializable]

/// <summary>
/// �L�����̃f�[�^�̃��X�g 
/// �X�R�A�͓G�L���������g��Ȃ�����
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
    [SerializeField, Tooltip("�Œ��ATK�l")] int attack;
    public int Attack { get { return attack; } }
    [SerializeField] float speed;
    public float Speed { get { return speed; } }
    [SerializeField, Tooltip("���̃L�������L�������Ƃ��̃X�R�A")] int score;
    public int Score { get { return score; } }
    [SerializeField, Tooltip("�G�L�����ڐG���Ɏ��g���ǂꂭ�炢������Ԃ�")] float selfImpactPower;
    public float SelfImpactPower { get { return selfImpactPower; } }
    public float Cost { get { return cost; } }
    [SerializeField, Tooltip("���̃L�����𐶐����邽�߂ɕK�v�ȃR�X�g")] float cost;
    [SerializeField, Tooltip("�{�^���p�̉摜")] Sprite charaImage;
    public Sprite CharaImage { get { return charaImage; } }
    [SerializeField, Tooltip("�v���n�u")] GameObject prefab;
    public GameObject Prefab { get { return prefab; } }
    public float Interval { get { return interval; } }
    [SerializeField, Tooltip("���̃L�����𐶐����邽�߂ɕK�v�ȃR�X�g")] float interval;
    [SerializeField, Tooltip("���쎞�p�̐�����"), TextArea(1, 5)] string info;
    public enum Ids
    {
        Mouse,
        Tiger,
        Cow,
        Dragon,
        None
    }
}
