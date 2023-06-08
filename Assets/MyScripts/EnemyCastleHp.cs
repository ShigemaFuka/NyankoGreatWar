using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCastleHp : MonoBehaviour
{
    [SerializeField] int _maxHp;
    [SerializeField] int _hp;
    Move _move;

    // Start is called before the first frame update
    void Start()
    {
        // HP������
        _hp = _maxHp;

        _move = this.gameObject.GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_hp <= 0)
        {
            Destroy(gameObject);
            Debug.Log("�����ŏ����̃V�[���֑J�ڂ���");
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // �L�����̃^�O�t���Ă���ȉ������s
        if (coll.gameObject.tag == "Chara")
        {
            // �L�������ƂɍU���l���قȂ��Ă��Ă��ǂ��悤��
            CharaHp _charaHp = coll.gameObject.GetComponent<CharaHp>();
            // HP���炵�Ă���
            _hp = _hp - _charaHp._attackValue;

            Debug.Log(_hp + this.gameObject.name);
        }
    }
}
