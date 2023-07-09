using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Using UnityEngine.Audio;
[RequireComponent(typeof(AudioSource))]
public class playerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] LayerMask ground;

    [SerializeField] Transform groundCheck;
    [SerializeField] AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        AudioSource[] allMyAudioSources = GetComponents<AudioSource>();
        audioData = allMyAudioSources[1];
    }


    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y ,verticalInput * movementSpeed);   

        if(Input.GetButtonDown("Jump") && IsGrounded()) {
            Jump();
        }
    }

    void Jump() {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        audioData.Play(0);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy Head")) {
            Destroy(other.transform.parent.gameObject);
            Jump();
        }
    }

    bool IsGrounded() {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
