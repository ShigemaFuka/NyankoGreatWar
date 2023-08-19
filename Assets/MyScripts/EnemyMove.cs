using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    [SerializeField] float _speed = 2f;
    [SerializeField] Vector2 _powerDirection = Vector2.up + Vector2.left;
    [SerializeField] float _powerScale = 5.0f;
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
        // Push()‚ª•s—v‚ÈŽž
        if (_enemyHp._isTouch != true)
        {
            _rigidbody2D.velocity = new Vector2(_speed, 0);
        }
    }

    public void Push()
    {
        _rigidbody2D.AddForce(_powerDirection * _powerScale, ForceMode2D.Impulse);
    }
}
