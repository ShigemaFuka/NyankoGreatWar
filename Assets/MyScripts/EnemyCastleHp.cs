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
        // HP初期化
        _hp = _maxHp;

        _move = this.gameObject.GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_hp <= 0)
        {
            Destroy(gameObject);
            Debug.Log("ここで勝利のシーンへ遷移する");
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // キャラのタグ付いてたら以下を実行
        if (coll.gameObject.tag == "Chara")
        {
            // キャラごとに攻撃値が異なっていても良いように
            CharaHp _charaHp = coll.gameObject.GetComponent<CharaHp>();
            // HP減らしていく
            _hp = _hp - _charaHp._attackValue;

            Debug.Log(_hp + this.gameObject.name);
        }
    }
}
