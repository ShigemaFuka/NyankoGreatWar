using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 自陣の城のHPが0になったら、ゲームマネジャーのゲームオーバー関数を呼び出す
/// 敵の城のが0になったら、クリア画面へ
/// 各城、敵キャラが接触してきたら、HP減少 
/// </summary>
public class CastleHp : MonoBehaviour
{
    [SerializeField] int _maxHp;
    [SerializeField] int _hp;
    [SerializeField, Tooltip("スライダー")] Slider _hpSlider;
    [SerializeField, Tooltip("タグ名：ダメージを与えてくるもの")] string _tagName;
    [SerializeField, Tooltip("敵の城か。真：Clear、偽：GameOver")] 
    bool _isEnemyCastle;
    
    void Start()
    {
        // HP初期化
        _hp = _maxHp;
        _hpSlider.maxValue = _maxHp;
        _hpSlider.value = _hp;
    }
    void Update()
    {
        if (_hp <= 0)
        {
            Destroy(gameObject);
            if(_isEnemyCastle) GameManager.Instance.ToClear();
            else GameManager.Instance.ToGameOver();
            Debug.Log("ここでゲームオーバーのシーンへ遷移する");
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // 敵のタグ付いてたら以下を実行
        if (coll.gameObject.CompareTag(_tagName))
        {
            // 敵キャラごとに攻撃値が異なっていても良いように
            CharaHp _charaHp = coll.gameObject.GetComponent<CharaHp>();
            // HP減らしていく
            _hp = _hp - _charaHp._attackValue;
            _hpSlider.value = _hp;

            Debug.Log(_hp + this.gameObject.name);
        }
    }
}
