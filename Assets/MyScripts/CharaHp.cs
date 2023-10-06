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
    [SerializeField, Tooltip("�L�����̃f�[�^")] CharacterData _characterData;
    //[SerializeField] int _maxHp;
    int _hp;
    [Tooltip("EnemyHp�ŎQ�Ƃ����")] public int _attackValue;
    [SerializeField, Tooltip("�ĐڐG�̂��߂�")] public bool _isTouch;
    Move _move;

    void Start()
    {
        _attackValue = _characterData.Attack;
        // HP������
        _hp = _characterData.Maxhp;
        _isTouch = false;

        _move = this.gameObject.GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // �G�̃^�O�t���Ă���ȉ������s
        if(coll.gameObject.tag == "Enemy")
        {            
            // �G�L�������ƂɍU���l���قȂ��Ă��Ă��ǂ��悤��
            EnemyHp _enemyHp = coll.gameObject.GetComponent<EnemyHp>();


            // HP���炵�Ă���
            _hp = _hp - _enemyHp._attackValue;

            // �ĐڐG���邽�߂�
            _isTouch = true;
            _move.Push();

            Debug.Log(_hp + this.gameObject.name);
        }
        // �邾������邩��̃_���[�W�͂Ȃ�
        else if (coll.gameObject.tag == "EnemyCastle")
        {
            // �ĐڐG���邽�߂�
            _isTouch = true;
            _move.Push();
        }
        else
        {
            // ���˂����ƒn�ʂƂ����̂Ƃ��ɐG�ꂽ��ēx���i�s������
            _isTouch = false;
        }
    }
}
