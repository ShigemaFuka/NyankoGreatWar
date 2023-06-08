using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaHp : MonoBehaviour
{
    [SerializeField] int _maxHp;
    [SerializeField] int _hp;
    [SerializeField, Tooltip("EnemyHpで参照される")] public int _attackValue;
    [SerializeField, Tooltip("再接触のための")] public bool _isTouch;
    Move _move;

    // Start is called before the first frame update
    void Start()
    {
        // HP初期化
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
        // 敵のタグ付いてたら以下を実行
        if(coll.gameObject.tag == "Enemy")
        {            
            // 敵キャラごとに攻撃値が異なっていても良いように
            EnemyHp _enemyHp = coll.gameObject.GetComponent<EnemyHp>();

            // HP減らしていく
            _hp = _hp - _enemyHp._attackValue;

            // 再接触するために
            _isTouch = true;
            _move.Push();

            Debug.Log(_hp + this.gameObject.name);
        }
        // 城だったら城からのダメージはない
        else if (coll.gameObject.tag == "EnemyCastle")
        {
            // 再接触するために
            _isTouch = true;
            _move.Push();
        }
        else
        {
            // 跳ねたあと地面とか他のとこに触れたら再度左進行させる
            _isTouch = false;
        }
    }
}
