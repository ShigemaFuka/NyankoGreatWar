using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Move : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    [SerializeField] float _speed;
    //[Tooltip("CharaHpのフラグ")] bool _isTouch;
    CharaHp _charaHp;
    [SerializeField] Vector2 _powerDirection = Vector2.up;
    [SerializeField] float _powerScale = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _charaHp = this.gameObject.GetComponent<CharaHp>();
    }

    void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Push()が不要な時
        if (_charaHp._isTouch != true)
        {
            // 左方向に移動
            _rigidbody2D.velocity = new Vector2(-_speed, 0);
        }
    }

    public void Push()
    {
        // 少し後方に弾くようにする
        _rigidbody2D.AddForce(_powerDirection * _powerScale, ForceMode2D.Impulse);
    }
}
