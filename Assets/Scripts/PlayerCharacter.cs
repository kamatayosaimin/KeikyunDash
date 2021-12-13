using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : CharacterObject
{
    [SerializeField] private float _initVelocity, _force, _jumpForce;
    private float _velocity;
    [SerializeField] private Vector3 _cameraOffset;
    [SerializeField] private ParticleSystem _deadParticlePrefab;
    private Rigidbody _rigidbody;
    [SerializeField] private StageScene _main;
    [SerializeField] private VitalityController _vitalityController;

    protected override void Awake()
    {
        base.Awake();

        _velocity = _initVelocity;
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;

        camera.position = Vector3.right * transform.position.x + camera.TransformDirection(_cameraOffset);
    }

    void FixedUpdate()
    {
        Vector3 velocity = _rigidbody.velocity;

        velocity.x = _velocity;

        _rigidbody.velocity = velocity;
    }

    public void GameStart()
    {
        GetComponentInChildren<JumpTrigger>().enabled = enabled = true;
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
    }

    public void SpeedUp()
    {
        _velocity += _force;
    }

    public void AddItemScore(int add)
    {
        _main.AddItemScore(add);
    }

    public void Recovery()
    {
        _vitalityController.Recovery();
    }

    public void FullRecovery()
    {
        _vitalityController.FullRecovery();
    }

    public void Dead()
    {
        _main.GameEnd();

        Instantiate(_deadParticlePrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
