using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public AudioClip hitAudio;
    private AudioSource audioSource;
    GameManager gameManager;
    PlayerController playerController;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerController = GameObject.Find("Tank").GetComponent<PlayerController>();
    }

   

    private void OnTriggerEnter(Collider other)
    {
        transform.position = newRandomTargetPosition();
        audioSource.PlayOneShot(hitAudio);
        playerController.ammoAvaliable ++;
    }

    Vector3 newRandomTargetPosition()
    {
        return new Vector3(randomX(), randomY(), randomZ());
    }

    float randomZ()
    {
        return Random.Range(-100f, -10f);

    }
    float randomX()
    {
        return Random.Range(-20, 70);

    }
    float randomY()
    {
        return Random.Range(3, 15);

    }
}
