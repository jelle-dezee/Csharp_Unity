using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float rateOfFire = 1.0f;
    private float waitToFire = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > waitToFire)
        {
            waitToFire = Time.time + rateOfFire;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
