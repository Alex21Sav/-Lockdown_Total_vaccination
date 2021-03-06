using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject _syringe;
    private readonly int _shootSpeed=10;
    private bool _canShoot=true;


    public void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && _canShoot)
        {
            GameObject syringe = Instantiate(_syringe, transform.position, Quaternion.Euler(90, -90, 0));
            //GameObject syringe = Instantiate(_syringe, transform.position, Quaternion.LookRotation(transform.position, Vector3.forward));
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.y = 1;
            syringe.GetComponent<Rigidbody>().AddForce((mousePosition - transform.position).normalized * _shootSpeed, ForceMode.Impulse);

            Vector3 difference = mousePosition - transform.position;
            float angle=Mathf.Atan(difference.x / difference.z)*180/Mathf.PI;
            if (difference.z > 0)
            {
                syringe.transform.localRotation = Quaternion.Euler(syringe.transform.localRotation.eulerAngles.x, angle - 90, syringe.transform.localRotation.eulerAngles.x);
            }
            else
            {
                syringe.transform.localRotation = Quaternion.Euler(syringe.transform.localRotation.eulerAngles.x, angle + 90, syringe.transform.localRotation.eulerAngles.x);
            }
            _canShoot = false;
            StartCoroutine(Reload());
        }
    }



    IEnumerator Reload()
    {
        while (_canShoot==false)
        {
            yield return new WaitForSeconds(1);
            _canShoot = true;
        }
    }
}
