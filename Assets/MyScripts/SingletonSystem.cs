using UnityEngine;

/// <summary>
/// GameManager���q�I�u�W�F�N�g�ɂ��Ċe�V�[������Q�Ƃł���悤�ɂ��� 
/// </summary>
public class SingletonSystem : MonoBehaviour
{
    [Tooltip("�C���X�^���X���擾���邽�߂̃p�u���b�N�ϐ�")] public static SingletonSystem Instance = default;

    void Awake()
    {
        // ���̏����� Start() �ɏ����Ă��悢���AAwake() �ɏ������Ƃ������B
        // �Q�l: �C�x���g�֐��̎��s���� https://docs.unity3d.com/ja/2019.4/Manual/ExecutionOrder.html
        if (Instance)
        {
            // �C���X�^���X�����ɂ���ꍇ�́A�j������
            Debug.LogWarning($"SingletonSystem �̃C���X�^���X�͊��ɑ��݂���̂ŁA{gameObject.name} �͔j�����܂��B");
            Destroy(this.gameObject);
        }
        else
        {
            // ���̃N���X�̃C���X�^���X�����������ꍇ�́A������ DontDestroyOnload �ɒu��
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
