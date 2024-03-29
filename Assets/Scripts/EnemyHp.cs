using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class EnemyHp : MonoBehaviour
{
    [SerializeField, Tooltip("キャラのデータ")] CharacterData _characterData;
    [Tooltip("敵の攻撃値（CharaHpで参照される）")] public int _attackValue;
    //[SerializeField] int _maxHp;
    int _hp;
    [SerializeField, Tooltip("再接触のための")] public bool _isTouch;
    EnemyMove _enemyMove;

    // Start is called before the first frame update
    void Start()
    {
        // HP初期化
        _hp = _characterData.Maxhp;
        _attackValue = _characterData.Attack;
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
        // キャラだったら被ダメージ
        if (coll.gameObject.tag == "Chara" )
        {
            // キャラごとに攻撃値が異なっていても良いように
            CharaHp _charaHp = coll.gameObject.GetComponent<CharaHp>();
            // HP減らしていく
            _hp = _hp - _charaHp._attackValue;

            // 再接触するために
            _isTouch = true;
            _enemyMove.Push();

            Debug.Log("hp : " + _hp + this.gameObject.name);
        }
        // 城だったら城からのダメージはない
        else if (coll.gameObject.tag == "Castle")
        {
            // 再接触するために
            _isTouch = true;
            _enemyMove.Push();
        }
        else
        {
            // 跳ねたあと地面とか他のとこに触れたら再度 左進行させる
            _isTouch = false;
        }
    }
    
}
