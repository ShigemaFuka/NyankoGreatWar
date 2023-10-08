using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ��莞�Ԃ����Ɏw�肵���v���n�u���� GameObject �𐶐�����R���|�[�l���g
/// </summary>
public class Generator : MonoBehaviour
{
    [SerializeField, Tooltip("��莞�Ԃ����ɐ�������v���n�u")] GameObject _prefab = default;
    [SerializeField, Tooltip("��������Ԋu�i�b�j")] float _interval = 1f;
    [SerializeField, Tooltip("true �̏ꍇ�A�J�n���ɂ�����������")] bool _generateOnStart = true;
    [SerializeField, Tooltip("�^�C�}�[�v���p�ϐ�")] float _timer;
    [SerializeField, Tooltip("�{�^�����N���b�N���ꂽ")] bool _isClick;
    [SerializeField, Tooltip("�X�|�[���ꏊ")] GameObject _gameObject;
    [SerializeField, Tooltip("�N���b�N�ł��邩UI")] Slider _slider;
    [SerializeField, Tooltip("���Ԍo�߂܂��Ƀt���O�^�ɂ���̂�h��")] Button _button;
    [SerializeField, Tooltip("��������u���Ă�����̐e�I�u�W�F�N�g")] GameObject _emptyParent;
    [SerializeField, Tooltip("�R�X�g�Ǘ��X�N���v�g")] CostController _costController;
    [SerializeField, Tooltip("�L���������ɂ�����R�X�g")] float _cost;
    [SerializeField, Tooltip("�{�^�����Â�����UI(�N���b�N����Ȃ�)")] RawImage _darkMask;

    void Start()
    {
        _darkMask.enabled = true;
        Move move = _prefab.GetComponent<Move>();
        _cost = move.CharacterData.Cost;
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
        if (_costController.JudgeCostValue(_cost) && _timer > _interval)
        {
            _button.enabled = true;
            _darkMask.enabled = false;
            if (_isClick)
            {
                _timer = 0;    // �^�C�}�[�����Z�b�g���Ă���
                Instantiate(_prefab, _gameObject.transform.position, Quaternion.identity, _emptyParent.transform);
                _costController.UseNowHadCost(_cost);
                _isClick = false;
                _button.enabled = false;
                _darkMask.enabled = true;
            }
        }
        else if (!_costController.JudgeCostValue(_cost))
        {
            _button.enabled = false;
            _darkMask.enabled = true;
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