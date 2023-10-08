using UnityEngine;

/// <summary>
/// ��莞�Ԃ����ɓG�L�����𐶐�����
/// �C���^�[�o���͈̔͂��߁A���͈͓̔��Ń����_���Ȏ��Ԃ����ɐ�������
/// ���ڂ̃C���^�[�o���̓C���X�y�N�^�[��Őݒ肵��_interval���Y������
/// </summary>
public class EnemyGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("��莞�Ԃ����ɐ�������v���n�u")] GameObject _prefab = default;
    [SerializeField, Tooltip("��������Ԋu�i�b�j")] float _interval = 1f;
    [SerializeField, Tooltip("true �̏ꍇ�A�J�n���ɂ�����������")] bool _generateOnStart = true;
    [Tooltip("�^�C�}�[�v���p�ϐ�")] float _timer;
    [SerializeField, Tooltip("�X�|�[���ꏊ")] GameObject _gameObject;
    [SerializeField, Tooltip("�͈͂̍ŏ��l")] float _minRange = 0f;
    [SerializeField, Tooltip("�͈͂̍ő�l")] float _maxRange = 5f;

    void Start()
    {
        if (_generateOnStart)
        {
            _timer = _interval;
        }
    }

    public void Update()
    {
        // Time.deltaTime �́u�O�t���[������̌o�ߎ��ԁv���擾����
        _timer += Time.deltaTime;
        // �u�o�ߎ��ԁv���u��������Ԋu�v�𒴂�����
        if (_timer > _interval)
        {
            _timer = 0;    // �^�C�}�[�����Z�b�g���Ă���
            Instantiate(_prefab, _gameObject.transform.position, Quaternion.identity);
            _interval = Random.Range(_minRange, _maxRange);
        }
    }
}