using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class EnemyMove : MonoBehaviour
{
    [SerializeField, Tooltip("キャラのデータ")] CharacterData _characterData;
    public CharacterData CharacterData { get => _characterData; set => _characterData = value; }
    Rigidbody2D _rigidbody2D;
    //[SerializeField] float _speed = 2f;
    [SerializeField] Vector2 _powerDirection = Vector2.up + Vector2.left;
    //[SerializeField] float _powerScale = 5.0f;
    EnemyHp _enemyHp;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _enemyHp = this.gameObject.GetComponent<EnemyHp>();
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // Push()が不要な時
        if (_enemyHp._isTouch != true)
        {
            _rigidbody2D.velocity = new Vector2(_characterData.Speed, 0);
        }
    }

    public void Push()
    {
        _rigidbody2D.AddForce(_powerDirection * _characterData.SelfImpactPower, ForceMode2D.Impulse);
    }
}
