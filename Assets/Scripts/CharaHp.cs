using UnityEngine;

/// <summary>
/// �o�w����L������HP���Ǘ�����
/// �G�L�����ɐڐG������A���̓G�L�����̍U���l���A���g��HP�����炷
/// ����Ɠ����ɁA�uEnemyHp�v���ŁA�G�L���������̃L�����̍U���l���A�G�L������HP�����炷
/// �G�L�����ƐڐG������A�N�U�����̌���֎��g�𐁂���΂�
/// �G�̏�ɐڐG���Ă����g��HP�͌���Ȃ����U���ɂ͂Ȃ邵�A���g�͐������
/// </summary>
public class CharaHp : MonoBehaviour
{
    //[SerializeField, Tooltip("�L�����̃f�[�^")] CharacterData _characterData;
    int _hp;
    [Tooltip("EnemyHp�ŎQ�Ƃ����")] public int _attackValue;
    [SerializeField, Tooltip("�ĐڐG�̂��߂̃t���O")] public bool _isTouch;
    Move _move;
    [SerializeField, Tooltip("���ʂ܂ł̎���")] float _deathLimit = 1.0f;
    [SerializeField, Tooltip("�^�O���F�_���[�W��^����Ώ�")] string _tagNameOfTarget;
    [SerializeField, Tooltip("�^�O���F��")] string _tagNameOfCastle;

    void Start()
    {
        _move = GetComponent<Move>();
        _attackValue = _move.CharacterData.Attack;
        // HP������
        _hp = _move.CharacterData.Maxhp;
        _isTouch = false;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // �G�̃^�O�t���Ă���ȉ������s
        if(coll.gameObject.CompareTag(_tagNameOfTarget))
        {
            // �G�L�������ƂɍU���l���قȂ��Ă��Ă��ǂ��悤��
            CharaHp charaHp = coll.gameObject.GetComponent<CharaHp>();
            _hp -= charaHp._attackValue;
            _isTouch = true;
            _move.Push();
        }
        // �邾������邩��̃_���[�W�͂Ȃ�
        else if (coll.gameObject.CompareTag(_tagNameOfCastle))
        {
            _isTouch = true;
            _move.Push();
        }
        // ���˂����ƒn�ʂƂ����̂Ƃ��ɐG�ꂽ��ēx�i�s������
        else _isTouch = false;
        DeathAction();
    }

    void DeathAction()
    {
        if (_hp <= 0)
        {
            _move.Push();
            Destroy(gameObject, _deathLimit);
        }
    }
}