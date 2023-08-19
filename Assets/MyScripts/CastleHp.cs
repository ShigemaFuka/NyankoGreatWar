using UnityEngine;

/// <summary>
/// 城のHPが0になったらゲームマネジャーのゲームオーバー関数を呼び出す
/// 敵キャラが接触してきたら、HP減少 
/// </summary>
public class CastleHp : MonoBehaviour
{
    [SerializeField] int _maxHp;
    [SerializeField] int _hp;

    void Start()
    {
        // HP初期化
        _hp = _maxHp;
    }
    void Update()
    {
        if (_hp <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.ToGameOver();
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
