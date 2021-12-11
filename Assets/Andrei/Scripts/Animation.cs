using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetAxis("Vertical") != 0 && Input.GetAxis("Horizontal") == 0)
        {
            _animator.SetBool("IsRunningLeft", false);
            _animator.SetBool("IsRunningRight", false);
            _animator.SetBool("IsRunning", true);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            _animator.SetBool("IsRunning", false);
            _animator.SetBool("IsRunningRight", false);
            _animator.SetBool("IsRunningLeft", true);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            _animator.SetBool("IsRunning", false);
            _animator.SetBool("IsRunningLeft", false);
            _animator.SetBool("IsRunningRight", true);
        }
        else
        {
            _animator.SetBool("IsRunning", false);
            _animator.SetBool("IsRunningLeft", false);
            _animator.SetBool("IsRunningRight", false);
        }
    }
}
