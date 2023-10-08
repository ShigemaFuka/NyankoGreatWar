using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 城のHPをスライダに反映
/// HPが0で終了のためシーン遷移
/// 接触してきたキャラクターの攻撃値に応じてダメージを受ける
/// </summary>
public class EnemyCastleHp : MonoBehaviour
{
    [SerializeField] int _maxHp;
    [SerializeField] int _hp;
    [SerializeField, Tooltip("スライダー")] Slider _hpSlider;
    //Move _move;

    // Start is called before the first frame update
    void Start()
    {
        // HP初期化
        _hp = _maxHp;
        _hpSlider.maxValue = _maxHp;
        _hpSlider.value = _hp;
        //_move = this.gameObject.GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_hp <= 0)
        {
            gameObject.SetActive(false);
            GameManager.Instance.ToClear();
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
            _hpSlider.value = _hp; 

            Debug.Log(_hp + this.gameObject.name);
        }
    }
}
