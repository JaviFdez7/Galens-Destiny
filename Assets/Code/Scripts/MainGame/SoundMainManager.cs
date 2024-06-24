using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMainManager : MonoBehaviour
{
    public static SoundMainManager instance;

    public List<AudioClip> firstBinaryMusicSound;
    private AudioSource currentMusicSource;

    public AudioClip shootPlayerSound;
    private AudioSource shootPlayerSource;

    public AudioClip shootEnemySound;
    private AudioSource shootEnemySource;

    public AudioClip pickSound;
    private AudioSource pickSource;

    public AudioClip doorSound;
    private AudioSource doorSource;

    public AudioClip closeDoorSound;
    private AudioSource closeDoorSource;

    public AudioClip shieldSound;
    private AudioSource shieldSource;

    public AudioClip bombSound;
    private AudioSource bombSource;

    public AudioClip explosionSound;
    private AudioSource explosionSource;

    public AudioClip hitSound;
    private AudioSource hitSource;

    public AudioClip metalicHitSound;
    private AudioSource metalicHitSource;

    public AudioClip playerHitSound;
    private AudioSource playerHitSource;

    public AudioClip dieSound;
    private AudioSource dieSource;

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
        shootPlayerSource = gameObject.AddComponent<AudioSource>();
        shootEnemySource = gameObject.AddComponent<AudioSource>();
        pickSource = gameObject.AddComponent<AudioSource>();
        doorSource = gameObject.AddComponent<AudioSource>();
        closeDoorSource = gameObject.AddComponent<AudioSource>();
        shieldSource = gameObject.AddComponent<AudioSource>();
        bombSource = gameObject.AddComponent<AudioSource>();
        explosionSource = gameObject.AddComponent<AudioSource>();
        hitSource = gameObject.AddComponent<AudioSource>();
        metalicHitSource = gameObject.AddComponent<AudioSource>();
        playerHitSource = gameObject.AddComponent<AudioSource>();
        dieSource = gameObject.AddComponent<AudioSource>();

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
            currentMusicSource.volume = 0.3f;
            currentMusicSource.Play();
            yield return new WaitForSeconds(randomClip.length);
        }
    }

    public void PlayShootPlayer()
    {
        shootPlayerSource.clip = shootPlayerSound;
        shootPlayerSource.volume = 0.15f;
        shootPlayerSource.playOnAwake = false;
        shootPlayerSource.Play();
    }

    public void PlayShootEnemy()
    {
        shootEnemySource.clip = shootEnemySound;
        shootEnemySource.volume = 0.3f;
        shootEnemySource.playOnAwake = false;
        shootEnemySource.Play();
    }

    public void PlayPick()
    {
        pickSource.clip = pickSound;
        pickSource.volume = 1f;
        pickSource.playOnAwake = false;
        pickSource.Play();
    }

    public void PlayDoor()
    {
        doorSource.clip = doorSound;
        doorSource.volume = 1f;
        doorSource.playOnAwake = false;
        doorSource.Play();
    }    

    public void PlayCloseDoor()
    {
        closeDoorSource.clip = closeDoorSound;
        closeDoorSource.volume = 0.5f;
        closeDoorSource.playOnAwake = false;
        closeDoorSource.Play();
    }  

    public void PlayShield()
    {
        shieldSource.clip = shieldSound;
        shieldSource.volume = 0.7f;
        shieldSource.playOnAwake = false;
        shieldSource.Play();
    } 

    public void PlayBomb()
    {
        bombSource.clip = bombSound;
        bombSource.volume = 0.7f;
        bombSource.playOnAwake = false;
        bombSource.Play();
    }   

    public void PlayExplosion()
    {
        explosionSource.clip = explosionSound;
        explosionSource.volume = 0.7f;
        explosionSource.playOnAwake = false;
        explosionSource.Play();
    }   

    public void PlayHit()
    {
        hitSource.clip = hitSound;
        hitSource.volume = 0.5f;
        hitSource.playOnAwake = false;
        hitSource.Play();
    }

    public void PlayMetalicHit()
    {
        metalicHitSource.clip = metalicHitSound;
        metalicHitSource.volume = 0.1f;
        metalicHitSource.playOnAwake = false;
        metalicHitSource.Play();
    }

    public void PlayPlayerHit()
    {
        playerHitSource.clip = playerHitSound;
        playerHitSource.volume = 0.35f;
        playerHitSource.playOnAwake = false;
        playerHitSource.Play();
    }

    public void PlayDie()
    {
        dieSource.clip = dieSound;
        dieSource.volume = 0.8f;
        dieSource.playOnAwake = false;
        dieSource.Play();
    }
}
