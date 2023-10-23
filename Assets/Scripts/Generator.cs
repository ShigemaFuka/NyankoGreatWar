using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ��莞�Ԃ����Ɏw�肵���v���n�u���� GameObject �𐶐�����R���|�[�l���g
/// ���̒��Ƀ{�^���N���b�N���ɁA�t���O��^�ɂ���֐������Ă���
/// </summary>
public class Generator : MonoBehaviour
{
    [SerializeField, Tooltip("�X�|�[���ꏊ")] GameObject _gameObject;
    [SerializeField, Tooltip("�Q�[�WUI_�C���^�[�o���Ɉˑ�")] Slider _slider;
    [SerializeField, Tooltip("�{�^�����N���b�N���ꂽ")] bool _isClick;
    [SerializeField, Tooltip("�^�C�}�[�v���p�ϐ�")] float _timer;
    [SerializeField, Tooltip("true �̏ꍇ�A�J�n���ɂ�����������")] bool _generateOnStart = true;
    [SerializeField, Tooltip("��������u���Ă�����̐e�I�u�W�F�N�g")] GameObject _emptyParent;
    [SerializeField, Tooltip("�R�X�g�Ǘ��X�N���v�g")] CostController _costController;
    [SerializeField, Tooltip("�{�^�����Â�����UI(�N���b�N����Ȃ�)")] RawImage _darkMask;
    [SerializeField, Tooltip("����������")] bool _isPrepare;
    [Header("GM���Z�b�g����or�Q�Ƃ���")]
    [SerializeField, Tooltip("��莞�Ԃ����ɐ�������v���n�u")] public GameObject _prefab = default;
    [SerializeField, Tooltip("���Ԍo�ߑO�Ƀt���O�^�ɂ���̂�h��")] Button _button;
    [SerializeField, Tooltip("��������̃{�^����UI")] public GameObject _image;
    [SerializeField, Tooltip("��������Ԋu�i�b�j")] public float _interval = 1f;
    [Space]
    [Header("�v���n�u�Ɉˑ�")]
    [SerializeField, Tooltip("�L���������ɂ�����R�X�g(�v���n�u�̃R�X�g�Ɉˑ�)")] float _cost;

    void Start()
    {
        _isPrepare = false;
    }

    void Update()
    {
        if (!_isPrepare)
        {
            Prepare();
            _isPrepare = true;
        }
        Generate();
    }

    public void OnClick()
    {
        // �{�^���N���b�N��
        if(_isClick == false)
        {
            _isClick = true;
        }
    }

    void Generate()
    {
        // Time.deltaTime�́u�O�t���[������̌o�ߎ��ԁv���擾����
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

    /// <summary>
    /// start�֐��ōs���ƁAGM��update�֐��̏����̑O�ɌĂ΂�Ă��܂����߁A
    /// ���̏������I����Ă���A������̏���������
    /// �v���n�u�ɉ����ăR�X�g��ύX�E�C���^�[�o���͂f�l�����ύX����
    /// </summary>
    void Prepare()
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
}