using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ��莞�Ԃ����Ɏw�肵���v���n�u���� GameObject �𐶐�����R���|�[�l���g
/// </summary>
public class Generator : MonoBehaviour
{
    /// <summary>��莞�Ԃ����ɐ������� GameObject �̌��ƂȂ�v���n�u</summary>
    [SerializeField] GameObject _prefab = default;
    /// <summary>��������Ԋu�i�b�j</summary>
    [SerializeField] float _interval = 1f;
    /// <summary>true �̏ꍇ�A�J�n���ɂ܂���������</summary>
    [SerializeField] bool _generateOnStart = true;
    /// <summary>�^�C�}�[�v���p�ϐ�</summary>
    [SerializeField] float _timer;
    [SerializeField, Tooltip("�{�^�����N���b�N���ꂽ")] bool _isClick;
    [SerializeField, Tooltip("�X�|�[���ꏊ")] GameObject _gameObject;
    [SerializeField, Tooltip("�N���b�N�ł��邩UI")] Slider _slider;
    [SerializeField, Tooltip("���Ԍo�߂܂��Ƀt���O�^�ɂ���̂�h��")] Button _button;

    void Start()
    {

        if (_slider)
        {
            _slider.maxValue = _interval;
            _slider.value = 0;
        }
        _button.enabled = false;
        if (_generateOnStart)
        {
            _timer = _interval;
            _button.enabled = true;
        }
    }

    public void Update()
    {
        // Time.deltaTime �́u�O�t���[������̌o�ߎ��ԁv���擾����
        _timer += Time.deltaTime;

        // �u�o�ߎ��ԁv���u��������Ԋu�v�𒴂�����
        if (_timer > _interval)
        {
            _button.enabled = true;
            if (_isClick)
            {
                _timer = 0;    // �^�C�}�[�����Z�b�g���Ă���
                Instantiate(_prefab, _gameObject.transform.position, Quaternion.identity);
                _isClick = false;
                _button.enabled = false;
            }
        }
        _slider.value = _timer;

    }

    public void OnClick()
    {
        // �{�^���N���b�N��
        if(_isClick == false)
        {
            _isClick = true;
        }
    }
}