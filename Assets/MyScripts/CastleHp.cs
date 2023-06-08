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
        // HP初期化
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
            Debug.Log("ここでゲームオーバーのシーンへ遷移する");
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // 敵のタグ付いてたら以下を実行
        if (coll.gameObject.tag == "Enemy")
        {
            // 敵キャラごとに攻撃値が異なっていても良いように
            EnemyHp _enemyHp = coll.gameObject.GetComponent<EnemyHp>();
            // HP減らしていく
            _hp = _hp - _enemyHp._attackValue;

            Debug.Log(_hp + this.gameObject.name);
        }
    }
}
