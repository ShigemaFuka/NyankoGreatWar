using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class EnemyHp : MonoBehaviour
{
    [SerializeField, Tooltip("�G�̍U���l�iCharaHp�ŎQ�Ƃ����j")] public int _attackValue;
    [SerializeField] int _maxHp;
    [SerializeField] int _hp;
    [SerializeField, Tooltip("�ĐڐG�̂��߂�")] public bool _isTouch;
    EnemyMove _enemyMove;

    // Start is called before the first frame update
    void Start()
    {
        // HP������
        _hp = _maxHp;
        _isTouch = false;

        _enemyMove = this.gameObject.GetComponent<EnemyMove>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Chara")
        {
            // �L�������ƂɍU���l���قȂ��Ă��Ă��ǂ��悤��
            CharaHp _charaHp = coll.gameObject.GetComponent<CharaHp>();
            // HP���炵�Ă���
            _hp = _hp - _charaHp._attackValue;

            // �ĐڐG���邽�߂�
            _isTouch = true;
            _enemyMove.Push();

            Debug.Log(_hp + this.gameObject.name);
        }
        else
        {
            // ���˂����ƒn�ʂƂ����̂Ƃ��ɐG�ꂽ��ēx ���i�s������
            _isTouch = false;
        }
    }
    
}
