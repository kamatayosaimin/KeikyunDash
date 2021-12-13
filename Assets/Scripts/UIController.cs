using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    [Serializable]
    class Result
    {
        [SerializeField] private StyledText _distanceText, _itemText, _totalText;
        [SerializeField] private StyledText[] _rankingTexts = new StyledText[5];

        public void SetResult(int distanceScore, int itemScore, int totalScore, ScoreElement[] ranking)
        {
            _distanceText.SetText(distanceScore);

            _itemText.SetText(itemScore);

            _totalText.SetText(totalScore);

            Gradation totalGradation = _totalText.Gradation;

            for (int i = 0; i < _rankingTexts.Length && i < ranking.Length; i++)
            {
                ScoreElement score = ranking[i];
                StyledText text = _rankingTexts[i];

                text.SetText(score.Score);

                if (!score.IsNewScore)
                    continue;

                Gradation gradation = text.Gradation;

                gradation.StartColor = totalGradation.StartColor;
                gradation.EndColor = totalGradation.EndColor;
            }
        }
    }

    [Serializable]
    class SpeedText : StyledText
    {
        private Animator _animator;

        public void EnableAnimator()
        {
            if (!_animator)
                _animator = Text.GetComponent<Animator>();

            _animator.SetTrigger("Trigger");
        }
    }

    [Serializable]
    class StyledText
    {
        [SerializeField] private string _label, _style;
        [SerializeField] private Text _text;
        private Gradation _gradation;

        protected Text Text
        {
            get
            {
                return _text;
            }
        }

        public Gradation Gradation
        {
            get
            {
                if (_gradation)
                    return _gradation;

                _gradation = _text.GetComponent<Gradation>();

                return _gradation;
            }
        }

        public void SetText(int value)
        {
            _text.text = _label + " : " + value.ToString(_style);
        }
    }

    [SerializeField] private GameObject _playParent, _resultParent, _gameOverText;
    [SerializeField] private RectTransform _vitalityParent;
    private Gradation[] _vitalityGradations;
    [SerializeField] private Result _result;
    [SerializeField] private SpeedText _speedText;
    [SerializeField] private StyledText _scoreText;

    public int MaxVitalityCount
    {
        get
        {
            return _vitalityGradations.Length;
        }
    }

    void Awake()
    {
        _vitalityGradations = _vitalityParent.GetComponentsInChildren<Gradation>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetScoreText(int distanceScore, int itemScore)
    {
        int score = distanceScore + itemScore;

        _scoreText.SetText(score);
    }

    public void SetSpeedText(int speed)
    {
        _speedText.SetText(speed);
    }

    public void EnableSpeedAnimator()
    {
        _speedText.EnableAnimator();
    }

    public void SetVitality(int count)
    {
        for (int i = 0; i < MaxVitalityCount; i++)
            _vitalityGradations[i].Type = i < count ? GradiationType.TopToBottom : GradiationType.None;
    }

    void SetActive(bool isPlaying)
    {
        _playParent.SetActive(isPlaying);

        _resultParent.SetActive(!isPlaying);
    }

    public void EnableGameOver()
    {
        _gameOverText.SetActive(true);
    }

    public void EnableResult(int distanceScore, int itemScore, int totalScore, ScoreElement[] ranking)
    {
        SetActive(false);

        _result.SetResult(distanceScore, itemScore, totalScore, ranking);
    }
}
