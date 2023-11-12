using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// トリガー判定で攻撃するキャラ（遠距離攻撃にするキャラ）
/// 対象のHpを減らす
/// </summary>
public class TriggerAttack : MonoBehaviour
{
    [SerializeField, Tooltip("攻撃のインターバル")] float _interval;
    [SerializeField, Tooltip("経過時間")] float _time;
    [SerializeField, Tooltip("攻撃し続ける時間")] float _attackTime = 2;
    [Tooltip("継続ダメージのため、値を下げる")] int _attackValue;
    Move _move;
    [SerializeField, Tooltip("タグ名：ダメージを与える対象")] string _tagNameOfTarget;
    [SerializeField, Tooltip("タグ名：城")] string _tagNameOfCastle;
    [SerializeField, Tooltip("スタート関数で呼ばれる")] UnityEvent _onStart;
    [SerializeField, Tooltip("トリガー接触中＆インターバルを満たした時点で呼ばれる")] UnityEvent _onAttack;
    CharaHp charaHp;
    CastleHp castleHp;

    void Start()
    {
        _move = GetComponent<Move>();
        _attackValue = _move.CharacterData.Attack / 5;
        _time = 0;
        _onStart.Invoke();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag(_tagNameOfTarget))
        {
            charaHp = coll.gameObject.GetComponent<CharaHp>();
        }
        if (coll.gameObject.CompareTag(_tagNameOfCastle))
        {
            castleHp = coll.gameObject.GetComponent<CastleHp>();
        }
    }

    //これを対象に書く
    void OnTriggerStay2D(Collider2D coll)
    {
        _time += Time.deltaTime;
        if (_time >= _interval)
        {
            // 敵のタグ付いてたら以下を実行
            if (coll.gameObject.CompareTag(_tagNameOfTarget))
            {
                _onAttack.Invoke();
                //対象のHpを減らす
                charaHp._hp -= _attackValue;
            }
            // 城のタグが付いていたら
            if (coll.gameObject.CompareTag(_tagNameOfCastle))
            {
                _onAttack.Invoke();
                //対象のHpを減らす
                castleHp._hp -= _attackValue;
                //Debug.LogWarning("castleHp : " + castleHp._hp);
            }
            if (_time >= _interval + _attackTime || coll == null)
            {
                _time = 0;
                _onStart.Invoke();
            }
        }
    }
}