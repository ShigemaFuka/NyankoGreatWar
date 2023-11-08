using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Move : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    CharaHp _charaHp;
    [SerializeField] Vector2 _powerDirection = Vector2.up;
    [SerializeField, Tooltip("キャラのデータ")] CharacterData _characterData;
    public CharacterData CharacterData { get => _characterData; set => _characterData = value; }
    [SerializeField] AudioSource _audioSourse;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _charaHp = this.gameObject.GetComponent<CharaHp>();
        _audioSourse = GameObject.Find("SE_Impact").GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        // Push()が不要な時
        if (_charaHp._isTouch != true)
        {
            // 左方向に移動
            _rigidbody2D.velocity = new Vector2(-CharacterData.Speed, 0);
        }
    }
    /// <summary>
    /// 各キャラは触れた瞬間のみ攻撃判定になるため、再度接触する必要がある
    /// その再接触を行うために距離を取らせている
    /// キャラのデータで右後方か、左後方に飛ばすかをプラマイで決める必要がある
    /// </summary>
    public void Push()
    {
        // 少し後方に弾くようにする
        _rigidbody2D.AddForce(_powerDirection * CharacterData.SelfImpactPower, ForceMode2D.Impulse);
        _audioSourse.PlayOneShot(_audioSourse.clip);
    }
}
