using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject _syringe;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0))
        {
            GameObject syringe=Instantiate(_syringe, transform.position, Quaternion.Euler(90,-90,0));
            syringe.GetComponent<Rigidbody>().AddForce(Vector3.forward*10,ForceMode.Impulse);
        }
    }
}
