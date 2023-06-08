using UnityEngine;

/// <summary>
/// ��莞�Ԃ����Ɏw�肵���v���n�u���� GameObject �𐶐�����R���|�[�l���g
/// </summary>
public class EnemyGenerator : MonoBehaviour
{
    /// <summary>��莞�Ԃ����ɐ������� GameObject �̌��ƂȂ�v���n�u</summary>
    [SerializeField] GameObject m_prefab = default;
    /// <summary>��������Ԋu�i�b�j</summary>
    [SerializeField] float m_interval = 1f;
    /// <summary>true �̏ꍇ�A�J�n���ɂ܂���������</summary>
    [SerializeField] bool m_generateOnStart = true;
    /// <summary>�^�C�}�[�v���p�ϐ�</summary>
    float m_timer;

    [SerializeField, Tooltip("�X�|�[���ꏊ")] GameObject _gameObject;

    void Start()
    {
        if (m_generateOnStart)
        {
            m_timer = m_interval;
        }
    }

    public void Update()
    {
        // Time.deltaTime �́u�O�t���[������̌o�ߎ��ԁv���擾����
        m_timer += Time.deltaTime;

        // �u�o�ߎ��ԁv���u��������Ԋu�v�𒴂�����
        if (m_timer > m_interval)
        {
            m_timer = 0;    // �^�C�}�[�����Z�b�g���Ă���
            Instantiate(m_prefab, _gameObject.transform.position, Quaternion.identity);
        }
    }
}