using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject[] _heartImage;
    int currentHeart;

    private void Start()
    {
        currentHeart = _heartImage.Length - 1;
    }

    private void OnEnable()
    {
        Player.PlayerIsDamaged += RemoveHeart;
    }

    private void OnDisable()
    {
        Player.PlayerIsDamaged -= RemoveHeart;
    }

    public void RemoveHeart()
    {
        Destroy(_heartImage[currentHeart]);
        currentHeart--;
    }
}
