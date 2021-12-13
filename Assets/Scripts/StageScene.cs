using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScene : SceneBehaviour
{
    [SerializeField] private int _addTarget, _maxSpeed = 1;
    private int _distanceScore, _itemScore, _speed = 1, _targetScore;
    [SerializeField] private float _gameOverSpan;
    [SerializeField] private PlayerCharacter _playerCharacter;
    private UIController _uiController;
    private VitalityController _vitalityController;

    void Awake()
    {
        _uiController = GetComponent<UIController>();
        _vitalityController = GetComponent<VitalityController>();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        SetScoreText();
        SetSpeedText(false);
        AddTargetScore();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public void GameStart()
    {
        _playerCharacter.GameStart();
    }

    public void GameEnd()
    {
        _uiController.EnableGameOver();

        StartCoroutine(GameOverState());
    }

    public void AddDistanceScore(int add)
    {
        _distanceScore += add;

        SetScoreText();

        _vitalityController.Consume(add);

        if (_speed >= _maxSpeed || _distanceScore < _targetScore)
            return;

        _speed++;

        _playerCharacter.SpeedUp();

        SetSpeedText(true);
        AddTargetScore();
    }

    public void AddItemScore(int add)
    {
        _itemScore += add;

        SetScoreText();
    }

    void SetScoreText()
    {
        _uiController.SetScoreText(_distanceScore, _itemScore);
    }

    void SetSpeedText(bool enableAnimator)
    {
        _uiController.SetSpeedText(_speed);

        if (enableAnimator)
            _uiController.EnableSpeedAnimator();
    }

    void AddTargetScore()
    {
        _targetScore += _addTarget * _speed;
    }

    IEnumerator GameOverState()
    {
        yield return new WaitForSeconds(_gameOverSpan);

        int totalScore = _distanceScore + _itemScore;

        _uiController.EnableResult(_distanceScore, _itemScore, totalScore, RankingManager.Instance.AddScore(totalScore));
    }
}
