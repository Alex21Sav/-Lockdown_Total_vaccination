using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syringe : MonoBehaviour
{
    BoxCollider _collider;

    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.TryGetComponent<Player>(out Player player))
        {
            Debug.Log(1);
            Destroy(gameObject);
        }
    }
}
