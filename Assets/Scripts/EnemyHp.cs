using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class EnemyHp : MonoBehaviour
{
    [SerializeField, Tooltip("�L�����̃f�[�^")] CharacterData _characterData;
    [Tooltip("�G�̍U���l�iCharaHp�ŎQ�Ƃ����j")] public int _attackValue;
    //[SerializeField] int _maxHp;
    int _hp;
    [SerializeField, Tooltip("�ĐڐG�̂��߂�")] public bool _isTouch;
    EnemyMove _enemyMove;

    // Start is called before the first frame update
    void Start()
    {
        // HP������
        _hp = _characterData.Maxhp;
        _attackValue = _characterData.Attack;
        _isTouch = false;

        _enemyMove = this.gameObject.GetComponent<EnemyMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    
    void OnCollisionEnter2D(Collision2D coll)
    {
        // �L�������������_���[�W
        if (coll.gameObject.tag == "Chara" )
        {
            // �L�������ƂɍU���l���قȂ��Ă��Ă��ǂ��悤��
            CharaHp _charaHp = coll.gameObject.GetComponent<CharaHp>();
            // HP���炵�Ă���
            _hp = _hp - _charaHp._attackValue;

            // �ĐڐG���邽�߂�
            _isTouch = true;
            _enemyMove.Push();

            Debug.Log("hp : " + _hp + this.gameObject.name);
        }
        // �邾������邩��̃_���[�W�͂Ȃ�
        else if (coll.gameObject.tag == "Castle")
        {
            // �ĐڐG���邽�߂�
            _isTouch = true;
            _enemyMove.Push();
        }
        else
        {
            // ���˂����ƒn�ʂƂ����̂Ƃ��ɐG�ꂽ��ēx ���i�s������
            _isTouch = false;
        }
    }
    
}