using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "player") {
            other.gameObject.transform.SetParent(transform);
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "player") {
            other.gameObject.transform.SetParent(null);
        }
    }
}
