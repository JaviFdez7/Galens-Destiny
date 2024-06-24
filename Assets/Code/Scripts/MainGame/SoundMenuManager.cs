using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMenuManager : MonoBehaviour
{
    public static SoundMenuManager instance;

    public List<AudioClip> firstBinaryMusicSound;
    private AudioSource currentMusicSource;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        currentMusicSource = gameObject.AddComponent<AudioSource>();
        PlayLoopingSongs();
    }

    private void PlayLoopingSongs()
    {
        StartCoroutine(LoopSongs());
    }

    private IEnumerator LoopSongs()
    {
        while (true)
        {
            AudioClip randomClip = firstBinaryMusicSound[Random.Range(0, firstBinaryMusicSound.Count)];
            currentMusicSource.clip = randomClip;
            currentMusicSource.volume = 0.7f;
            currentMusicSource.Play();
            yield return new WaitForSeconds(randomClip.length);
        }
    }
}
