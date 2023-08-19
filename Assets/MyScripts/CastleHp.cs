using UnityEngine;

/// <summary>
/// ���HP��0�ɂȂ�����Q�[���}�l�W���[�̃Q�[���I�[�o�[�֐����Ăяo��
/// �G�L�������ڐG���Ă�����AHP���� 
/// </summary>
public class CastleHp : MonoBehaviour
{
    [SerializeField] int _maxHp;
    [SerializeField] int _hp;

    void Start()
    {
        // HP������
        _hp = _maxHp;
    }
    void Update()
    {
        if (_hp <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.ToGameOver();
            Debug.Log("�����ŃQ�[���I�[�o�[�̃V�[���֑J�ڂ���");
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // �G�̃^�O�t���Ă���ȉ������s
        if (coll.gameObject.tag == "Enemy")
        {
            // �G�L�������ƂɍU���l���قȂ��Ă��Ă��ǂ��悤��
            EnemyHp _enemyHp = coll.gameObject.GetComponent<EnemyHp>();
            // HP���炵�Ă���
            _hp = _hp - _enemyHp._attackValue;

            Debug.Log(_hp + this.gameObject.name);
        }
    }
}
