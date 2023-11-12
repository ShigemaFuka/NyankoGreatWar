using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// �g���K�[����ōU������L�����i�������U���ɂ���L�����j
/// �Ώۂ�Hp�����炷
/// </summary>
public class TriggerAttack : MonoBehaviour
{
    [SerializeField, Tooltip("�U���̃C���^�[�o��")] float _interval;
    [SerializeField, Tooltip("�o�ߎ���")] float _time;
    [SerializeField, Tooltip("�U���������鎞��")] float _attackTime = 2;
    [Tooltip("�p���_���[�W�̂��߁A�l��������")] int _attackValue;
    Move _move;
    [SerializeField, Tooltip("�^�O���F�_���[�W��^����Ώ�")] string _tagNameOfTarget;
    [SerializeField, Tooltip("�^�O���F��")] string _tagNameOfCastle;
    [SerializeField, Tooltip("�X�^�[�g�֐��ŌĂ΂��")] UnityEvent _onStart;
    [SerializeField, Tooltip("�g���K�[�ڐG�����C���^�[�o���𖞂��������_�ŌĂ΂��")] UnityEvent _onAttack;
    CharaHp charaHp;
    CastleHp castleHp;

    void Start()
    {
        _move = GetComponent<Move>();
        _attackValue = _move.CharacterData.Attack / 5;
        _time = 0;
        _onStart.Invoke();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag(_tagNameOfTarget))
        {
            charaHp = coll.gameObject.GetComponent<CharaHp>();
        }
        if (coll.gameObject.CompareTag(_tagNameOfCastle))
        {
            castleHp = coll.gameObject.GetComponent<CastleHp>();
        }
    }

    //�����Ώۂɏ���
    void OnTriggerStay2D(Collider2D coll)
    {
        _time += Time.deltaTime;
        if (_time >= _interval)
        {
            // �G�̃^�O�t���Ă���ȉ������s
            if (coll.gameObject.CompareTag(_tagNameOfTarget))
            {
                _onAttack.Invoke();
                //�Ώۂ�Hp�����炷
                charaHp._hp -= _attackValue;
            }
            // ��̃^�O���t���Ă�����
            if (coll.gameObject.CompareTag(_tagNameOfCastle))
            {
                _onAttack.Invoke();
                //�Ώۂ�Hp�����炷
                castleHp._hp -= _attackValue;
                //Debug.LogWarning("castleHp : " + castleHp._hp);
            }
            if (_time >= _interval + _attackTime || coll == null)
            {
                _time = 0;
                _onStart.Invoke();
            }
        }
    }
}