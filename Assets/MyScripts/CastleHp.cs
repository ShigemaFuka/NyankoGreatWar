using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CastleHp : MonoBehaviour
{
    [SerializeField] int _maxHp;
    [SerializeField] int _hp;
    Move _move;
    [SerializeField, Tooltip("遷移先")] string _sceneName;


    void Start()
    {
        // HP初期化
        _hp = _maxHp;

        _move = this.gameObject.GetComponent<Move>();
    }
    void Update()
    {
        if (_hp <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.Action(GameManager.GameState.GameOver);
            //SceneManager.LoadScene(_sceneName);
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
