using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class ItemCollector : MonoBehaviour
{
    int coins = 0;
    [SerializeField] AudioSource collectionSound;
    [SerializeField] TextMeshProUGUI coinsText;
    void Start()
    {
        // collectionSound = gameObject.AddComponent<AudioSource>();
        AudioSource[] allMyAudioSources = GetComponents<AudioSource>();
        collectionSound = allMyAudioSources[0];
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin")) {
            Destroy(other.gameObject);
            collectionSound.Play(0);
            coins++;
            coinsText.text = "Coins : " + coins;
        }
    }
}
