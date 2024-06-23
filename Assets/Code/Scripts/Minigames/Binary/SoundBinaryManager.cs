using System.Collections;
using UnityEngine;

public class SoundBinaryManager : MonoBehaviour
{
    public static SoundBinaryManager instance;

    public AudioClip firstBinaryMusicSound;
    public AudioClip secondBinaryMusicSound;
    private AudioSource currentMusicSource;

    public AudioClip digitButtonSound;
    private AudioSource buttonClickSource;

    public AudioClip victorySound;
    private AudioSource victorySource;

    public AudioClip wrongSound;
    private AudioSource wrongSource;
    
    public AudioClip chatDragSound;
    private AudioSource chatDragSource;

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
        wrongSource = gameObject.AddComponent<AudioSource>();
        currentMusicSource = gameObject.AddComponent<AudioSource>();
        chatDragSource = gameObject.AddComponent<AudioSource>();
        PlayLoopingSongs();
    }

    public void PlayDigitButtonSound()
    {
        buttonClickSource.clip = digitButtonSound;
        buttonClickSource.playOnAwake = false;
        buttonClickSource.Play();
    }

    public void PlayVictorySound()
    {
        victorySource.clip = victorySound;
        victorySource.playOnAwake = false;
        victorySource.Play();
    }

    private void PlayLoopingSongs()
    {
        StartCoroutine(LoopSongs());
    }

    private IEnumerator LoopSongs()
    {
        while (true)
        {
            currentMusicSource.clip = firstBinaryMusicSound;
            currentMusicSource.volume = 0.4f;
            currentMusicSource.Play();
            yield return new WaitForSeconds(firstBinaryMusicSound.length);

            currentMusicSource.clip = secondBinaryMusicSound;
            currentMusicSource.volume = 0.5f;
            currentMusicSource.Play();
            yield return new WaitForSeconds(secondBinaryMusicSound.length);
        }
    }

    public void PlayWrongSound()
    {
        wrongSource.clip = wrongSound;
        wrongSource.volume = 0.3f;
        wrongSource.playOnAwake = false;
        wrongSource.Play();
    }

    public void PlayChatDragSound()
    {
        chatDragSource.clip = chatDragSound;
        chatDragSource.volume = 0.8f;
        chatDragSource.playOnAwake = false;
        chatDragSource.Play();
    }
}