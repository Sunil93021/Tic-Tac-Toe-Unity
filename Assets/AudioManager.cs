using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioClip winSound;

    public void PlayClickSound()
    {
        AudioSource.PlayClipAtPoint(clickSound,Camera.main.transform.position);
    }

    public void PlayWinSound()
    {
        AudioSource.PlayClipAtPoint(winSound,Camera.main.transform.position);
    }
}
