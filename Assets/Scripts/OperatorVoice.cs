using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OperatorVoice : MonoBehaviour
{
    public AudioClip clip;
    public AudioClip clip1;
    public AudioClip clip2;

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
            case "-":
                audioSource.clip = clip1;
                break;
            case "=":
                audioSource.clip = clip2;
                break;
            
            default:
                Debug.LogWarning("No clip found for text content: " + textContent);
                return;
        }
        audioSource.Play();
    }
}

