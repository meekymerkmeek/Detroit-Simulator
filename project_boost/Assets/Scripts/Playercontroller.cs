
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] private float thrustForce = 1000f;
    [SerializeField] private float rotationSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    

    public void Thrust()
    {
        if(Input.GetKey(KeyCode.W))
        {
           rb.AddRelativeForce(Vector3.up * thrustForce);
           if(!audioSource.isPlaying) audioSource.Play();
        }
    }

    public void RotateLeft()
    {
       ApplyRotation(rotationSpeed);
    }

    public void RotateRight()
    {
        ApplyRotation(-rotationSpeed);
    }


    private void ApplyRotation(float rotationValue)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationValue * Time.deltaTime);
        rb.freezeRotation = false;

    }
}
