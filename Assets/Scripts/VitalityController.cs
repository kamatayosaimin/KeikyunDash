using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitalityController : MonoBehaviour
{
    [SerializeField] private int _initPoint;
    private int _count, _maxCount, _point;
    [SerializeField] private PlayerCharacter _playerCharacter;
    private UIController _uiController;

    void Awake()
    {
        _uiController = GetComponent<UIController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _maxCount = _uiController.MaxVitalityCount;

        FullRecovery();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Consume(int consume)
    {
        _point -= consume;

        if (_point > 0)
            return;

        _count--;

        if (_count <= 0)
            _playerCharacter.Dead();

        _point = _initPoint;

        SetUI();
    }

    public void Recovery()
    {
        if (_count < _maxCount)
            _count++;

        _point = _initPoint;

        SetUI();
    }

    public void FullRecovery()
    {
        _count = _maxCount;
        _point = _initPoint;

        SetUI();
    }

    void SetUI()
    {
        _uiController.SetVitality(_count);
    }
}
