using UnityEngine;

public class SoundBinaryManager : MonoBehaviour
{
    public static SoundBinaryManager instance;

    public AudioClip binaryMusicSound;
    private AudioSource binaryMusicSource;

    public AudioClip digitButtonSound;
    private AudioSource buttonClickSource;

    public AudioClip victorySound;
    private AudioSource victorySource;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        buttonClickSource = gameObject.AddComponent<AudioSource>();
        victorySource = gameObject.AddComponent<AudioSource>();
        binaryMusicSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlayDigitButtonSound()
    {
        buttonClickSource.clip = digitButtonSound;
        victorySource.playOnAwake = false;
        buttonClickSource.Play();
    }

    public void PlayVictorySound()
    {
        victorySource.clip = victorySound;
        victorySource.playOnAwake = false;
        victorySource.Play();
    }

    public void PlayBinaryMusicSound()
    {
        binaryMusicSource.clip = binaryMusicSound;
        binaryMusicSource.loop = true;
        victorySource.playOnAwake = true;
        binaryMusicSource.Play();
    }
}