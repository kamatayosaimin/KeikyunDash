using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    private bool _isGrounded;
    private PlayerCharacter _playerCharacter;

    void Awake()
    {
        _playerCharacter = GetComponentInParent<PlayerCharacter>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_isGrounded && Input.GetMouseButtonDown(0))
        {
            _isGrounded = false;

            _playerCharacter.Jump();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!_isGrounded && other.GetComponent<Ground>())
            _isGrounded = true;
    }
}
