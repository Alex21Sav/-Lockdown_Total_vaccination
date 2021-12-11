using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _playerImage;
    [SerializeField] private TMP_Text _playerNameText;
    [SerializeField] private float _speed;
    private int health=5;

    private Rigidbody _rigidbody3D;
    private bool _isMoving = false;
    private float _x, _z;

    private bool _canBeDamaged=true;

    public static event Action PlayerIsDamaged;

    private void Start()
    {
       _rigidbody3D = GetComponent<Rigidbody>();

        ChangePlayerSkin();
    }

    private void ChangePlayerSkin()
    {
        Character character = GameDataManager.GetSelectedCharacter();

        if (character.Image != null)
        {            
            _playerImage.sprite = character.Image;
            _playerNameText.text = character.Name;
        }

    }

    private void Update()
    {
        _x = Input.GetAxis("Horizontal");
        _z = Input.GetAxis("Vertical");

        _isMoving = (_x != 0 || _z != 0);
    }

    private void FixedUpdate()
    {
        _rigidbody3D.position += new Vector3(_x,0, _z) * _speed * Time.fixedDeltaTime;
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Granny>(out Granny granny)&&_canBeDamaged)
        {
            Debug.Log(1);
            health--;
            PlayerIsDamaged?.Invoke();
            if (health == 0)
            {
                Time.timeScale = 0;
            }
            _canBeDamaged = false;
            StartCoroutine(Recover());
        }
    }

    IEnumerator Recover()
    {
        yield return new WaitForSeconds(2);
        _canBeDamaged = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        string tag = other.collider.tag;

        if (tag.Equals("Coin"))
        {
            GameDataManager.AddCoins(32);


        #if UNITY_EDITOR
            if (Input.GetKey(KeyCode.C))
            {
                GameDataManager.AddCoins(200);
            }
#endif

            GameSharedUI.Instance.UpdateCoinsUI();

            Destroy(other.gameObject);
        }
    }
}
