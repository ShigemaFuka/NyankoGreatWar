using UnityEngine;
/// <summary>
/// �}�E�X���N���b�N���ɃN���b�N���Đ�
/// </summary>
public class ClickSE : MonoBehaviour
{
    AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _audioSource.PlayOneShot(_audioSource.clip);
        }
    }
}
