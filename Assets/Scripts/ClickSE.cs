using UnityEngine;
/// <summary>
/// マウス左クリック時にクリック音再生
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
        if (Input.GetMouseButtonUp(0))
        {
            _audioSource.PlayOneShot(_audioSource.clip);
        }
    }
}
