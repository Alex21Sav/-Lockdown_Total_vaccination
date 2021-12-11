using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mask : MonoBehaviour
{
    private MaskSpawner _maskSpawner;

    private void Awake()
    {
        _maskSpawner = GameObject.FindObjectOfType<MaskSpawner>().GetComponent<MaskSpawner>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Granny>(out Granny granny) || other.gameObject.TryGetComponent<Syringe>(out Syringe syringe))
        {
            return;
        }
        else if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            GameDataManager.AddCoins(1);
            GameSharedUI.Instance.UpdateCoinsUI();
            _maskSpawner.MaskSpawn();
            Destroy(gameObject);
        }
        else
        {
            _maskSpawner.MaskSpawn();
            Destroy(gameObject);
        }
    }
}
