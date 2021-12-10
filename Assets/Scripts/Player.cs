using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _playerImage;
    [SerializeField] private TMP_Text _playerNameText;
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody3D;
    private bool _isMoving = false;
    private float _x, _z;

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
