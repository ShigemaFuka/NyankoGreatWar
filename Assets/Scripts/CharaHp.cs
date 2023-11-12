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
    [Tooltip("TriggerAttackで参照される")] public int _hp;
    [Tooltip("EnemyHpで参照される")] public int _attackValue;
    [SerializeField, Tooltip("再接触のためのフラグ")] public bool _isTouch;
    Move _move;
    [SerializeField, Tooltip("死ぬまでの時間")] float _deathLimit = 1.0f;
    [SerializeField, Tooltip("タグ名：ダメージを与える対象")] string _tagNameOfTarget;
    [SerializeField, Tooltip("タグ名：城")] string _tagNameOfCastle;
    [SerializeField, Tooltip("UpdateでPushし続けないように管理")] bool _isPushed;

    void Start()
    {
        _move = GetComponent<Move>();
        _attackValue = _move.CharacterData.Attack;
        // HP初期化
        _hp = _move.CharacterData.Maxhp;
        _isTouch = false;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // 敵のタグ付いてたら以下を実行
        if (coll.gameObject.CompareTag(_tagNameOfTarget))
        {
            // 敵キャラごとに攻撃値が異なっていても良いように
            CharaHp charaHp = coll.gameObject.GetComponent<CharaHp>();
            // 自身のHPを減らす
            _hp -= charaHp._attackValue;
            _isTouch = true;
            _move.Push();
        }
        // 城だったら城からのダメージはない
        else if (coll.gameObject.CompareTag(_tagNameOfCastle))
        {
            _isTouch = true;
            _move.Push();
        }
        // 跳ねたあと地面とか他のとこに触れたら再度進行させる
        else _isTouch = false;
    }

    void Update()
    {
        if(!_isPushed)
            DeathAction();
    }

    /// <summary>
    /// Triggerでの攻撃に対応するための、Updateでチェックされ次第、実行される関数
    /// </summary>
    void DeathAction()
    {
        if (_hp <= 0)
        {
            _move.Push();
            _isPushed = true;
            Destroy(gameObject, _deathLimit);
        }
    }
}
