using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    [SerializeField] private GameObject _aim;
    private Vector3 _mousePosition;

    private void Update()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePosition.y = 1;
        _aim.transform.position = _mousePosition;

    }
}
