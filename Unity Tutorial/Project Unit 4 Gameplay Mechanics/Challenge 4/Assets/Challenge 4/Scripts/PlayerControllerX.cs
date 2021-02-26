using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControllerX : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 500;
    private GameObject focalPoint;

    public bool hasPowerup;
    public GameObject powerupIndicator;
    public int powerUpDuration = 5;

    private bool hasSpeedBoost = false;
    private int speedBoost = 50;
    private float speedBoostDuration = 10.0f;

    private float normalStrength = 10; // how hard to hit enemy without powerup
    private float powerupStrength = 25; // how hard to hit enemy with powerup

    private string score;
    public TextMeshProUGUI scoreText;

    public ParticleSystem smoke_particle;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");

        scoreText.text = "Press space for speed boost";
    }

    void Update()
    {
        // Add force to player in direction of the focal point (and camera)
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime); 

        if (Input.GetKeyDown(KeyCode.Space) && !hasSpeedBoost)
        {
            hasSpeedBoost = true;
            smoke_particle.Play();
            playerRb.AddForce(focalPoint.transform.forward * speedBoost, ForceMode.Impulse);
            StartCoroutine(SpeedBoostCooldown());
        }

        // Set powerup indicator position to beneath player
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);

    }

    // If Player collides with powerup, activate powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCooldown());
        }
    }

    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    // Coroutine to count down speedboost duration
    IEnumerator SpeedBoostCooldown()
    {
        // Change text based on hasSpeedBoost
        if (hasSpeedBoost)
        {  
            for (speedBoostDuration = 10; speedBoostDuration > 0; speedBoostDuration -= Time.deltaTime)
            {
                scoreText.text = "Speed boost cooldown: " + Mathf.FloorToInt(speedBoostDuration);
                yield return null;
            } 
            
        }

        scoreText.text = "Press space for speed boost";
        hasSpeedBoost = false; 
    }

    // If Player collides with enemy
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer =  other.gameObject.transform.position - transform.position; 
           
            if (hasPowerup) // if have powerup hit enemy with powerup force
            {
                enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
            else // if no powerup, hit enemy with normal strength 
            {
                enemyRigidbody.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
            }


        }
    }

}
