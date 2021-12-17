using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    [SerializeField] float forwardMoveForce;
    [SerializeField] float turnTankForce;
    [SerializeField] GameObject head;
    [SerializeField] GameObject cannon;
    [SerializeField] GameObject ammo;
    GameObject mouth;
    float shootForce = 30;

    public AudioClip shootAudio;
    public AudioClip motorAudio;
    public AudioClip moveAudio;
    private AudioSource audioSource;

    public GameManager gameManager;

    public Text ammoText;
    GameObject newAmmo;
    public int ammoAvaliable = 5;


    // Start is called before the first frame update
    void Start()
    {
        ammoAvaliable = 5;
        playerRb = GetComponent<Rigidbody>();
        mouth = GameObject.Find("Mouth");
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManager.isGameActive)
        {
            
            MoveForward();
            TurnAround();
            MoveHead();

            //Shoot

            if (Input.GetButtonDown("Jump"))
            {
                ShootAmmo();

            }
        }

        if(ammoAvaliable == 0 && newAmmo == null)
        {
            gameManager.GameOver();
        }
        
    }
    private void Update()
    {
        ShowAmmoAvaliable();
    }

    void ShootAmmo()
    {
        ammoAvaliable --;
        audioSource.PlayOneShot(shootAudio,1f);
        newAmmo = Instantiate(ammo, mouth.transform.position, ammo.transform.rotation);

        Rigidbody newAmmoRb = newAmmo.GetComponent<Rigidbody>();
        Vector3 aim = (mouth.transform.position - cannon.transform.position).normalized;

        newAmmoRb.AddRelativeForce(aim * shootForce, ForceMode.Impulse);
    }
    void MoveForward()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddRelativeForce(Vector3.forward * forwardMoveForce * forwardInput);
        
        if (forwardInput != 0 && !audioSource.isPlaying)
        {
            audioSource.clip = moveAudio;
            audioSource.Play();
        }else if(forwardInput == 0 && !audioSource.isPlaying)
        {
            audioSource.clip = motorAudio;
            audioSource.Play();
        }else if (forwardInput != 0 && audioSource.clip == motorAudio)
        {
            audioSource.Stop();

        }else if(forwardInput == 0 && audioSource.clip == moveAudio)
        {
            audioSource.Stop();
        }
        
    }
    void TurnAround()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(horizontalInput * Vector3.up * turnTankForce);
    }

    void MoveHead()
    {
        //Head Turn Move
        float mouseX = Input.GetAxis("Mouse X");

        head.transform.Rotate(Vector3.up * mouseX * turnTankForce);

        //cannon vertical move


        float mouseY = Input.GetAxis("Mouse Y");
        cannon.transform.Rotate(-Vector3.forward * mouseY * turnTankForce);


        Vector3 currentRotation = cannon.transform.localRotation.eulerAngles;
        currentRotation.z = Mathf.Clamp(currentRotation.z, 37, 99); // clamp y rotation
        cannon.transform.localRotation = Quaternion.Euler(currentRotation);
    }

    void ShowAmmoAvaliable()
    {
        ammoText.text = "Ammo: " + ammoAvaliable;
    }
}
