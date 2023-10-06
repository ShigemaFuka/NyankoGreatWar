using UnityEngine;

/// <summary>
/// 出陣するキャラのHPを管理する
/// 敵キャラに接触したら、その敵キャラの攻撃値分、自身のHPを減らす
/// それと同時に、「EnemyHp」内で、敵キャラもこのキャラの攻撃値分、敵キャラのHPを減らす
/// 敵キャラと接触したら、侵攻方向の後方へ自身を吹っ飛ばす
/// 敵の城に接触しても自身のHPは減らないが攻撃にはなるし、自身は吹っ飛ぶ
/// </summary>
public class CharaHp : MonoBehaviour
{
    [SerializeField, Tooltip("キャラのデータ")] CharacterData _characterData;
    //[SerializeField] int _maxHp;
    int _hp;
    [Tooltip("EnemyHpで参照される")] public int _attackValue;
    [SerializeField, Tooltip("再接触のための")] public bool _isTouch;
    Move _move;

    void Start()
    {
        _attackValue = _characterData.Attack;
        // HP初期化
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
