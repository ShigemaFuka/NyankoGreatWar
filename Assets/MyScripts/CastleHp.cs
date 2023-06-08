using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleHp : MonoBehaviour
{
    [SerializeField] int _maxHp;
    [SerializeField] int _hp;
    Move _move;

    // Start is called before the first frame update
    void Start()
    {
        // HP������
        _hp = _maxHp;
        //_isTouch = false;

        _move = this.gameObject.GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_hp <= 0)
        {
            Destroy(gameObject);
            Debug.Log("�����ŃQ�[���I�[�o�[�̃V�[���֑J�ڂ���");
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // �G�̃^�O�t���Ă���ȉ������s
        if (coll.gameObject.tag == "Enemy")
        {
            // �G�L�������ƂɍU���l���قȂ��Ă��Ă��ǂ��悤��
            EnemyHp _enemyHp = coll.gameObject.GetComponent<EnemyHp>();
            // HP���炵�Ă���
            _hp = _hp - _enemyHp._attackValue;

            Debug.Log(_hp + this.gameObject.name);
        }
    }
}
