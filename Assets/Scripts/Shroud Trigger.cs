using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroudTrigger : MonoBehaviour
{
    public GameObject Shroud;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Shroud.SetActive(true);
        }
    }

    private void Start()
    {
        Shroud.SetActive(false);
    }
}
