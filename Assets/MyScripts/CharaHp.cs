using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaHp : MonoBehaviour
{
    [SerializeField] int _maxHp;
    [SerializeField] int _hp;
    [SerializeField, Tooltip("EnemyHp�ŎQ�Ƃ����")] public int _attackValue;
    [SerializeField, Tooltip("�ĐڐG�̂��߂�")] public bool _isTouch;
    Move _move;

    // Start is called before the first frame update
    void Start()
    {
        // HP������
        _hp = _maxHp;
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
