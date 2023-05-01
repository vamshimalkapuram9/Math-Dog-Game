using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TextVoice : MonoBehaviour
{
    public AudioClip clip;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;
    public AudioClip clip5;
    public AudioClip clip6;
    public AudioClip clip7;
    public AudioClip clip8;
    public AudioClip clip9;
    public AudioClip clip10;
    public AudioClip clip11;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayClipForText(Text text)
    {
        string textContent = text.text;
        switch (textContent)
        {
            case "0":
                audioSource.clip = clip1;
                break;
            case "1":
                audioSource.clip = clip2;
                break;
            case "2":
                audioSource.clip = clip3;
                break;
            case "3":
                audioSource.clip = clip4;
                break;
            case "4":
                audioSource.clip = clip5;
                break;
            case "5":
                audioSource.clip = clip6;
                break;
            case "6":
                audioSource.clip = clip7;
                break;
            case "7":
                audioSource.clip = clip8;
                break;
            case "8":
                audioSource.clip = clip9;
                break;
            case "9":
                audioSource.clip = clip10;
                break;
            case "10":
                audioSource.clip = clip11;
                break;
            default:
                Debug.LogWarning("No clip found for text content: " + textContent);
                return;
        }
        audioSource.Play();
    }
}
