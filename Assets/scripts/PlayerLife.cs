using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(AudioSource))]
public class PlayerLife : MonoBehaviour
{

    [SerializeField] AudioSource deathSound;
    bool dead = false;

    void Start()
    {
        // collectionSound = gameObject.AddComponent<AudioSource>();
        AudioSource[] allMyAudioSources = GetComponents<AudioSource>();
        deathSound = allMyAudioSources[2];
    }
    void Update()
    {
        if(GetComponent<Rigidbody>().position.y < -7 && !dead) {
            Die();
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy Body")) {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<playerMovement>().enabled = false;
            Die();
        }
    }

    void Die() {
        Invoke(nameof(ReloadLevel), 1.3f);
        dead = true;
        deathSound.Play(0);
    }

    void ReloadLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
