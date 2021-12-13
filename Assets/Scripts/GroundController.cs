using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{

    [System.Serializable]
    class ObjectGenerator
    {
        [SerializeField] private int _generateProbability, _ironBallProbability, _fullRecoveryProbability;
        [SerializeField] private float _bottom, _top;
        private bool _isIronBallInstanced;
        [SerializeField] private FullRecoveryItem _fullRecoveryItemPrefab;
        [SerializeField] private IronBall _ironBallPrefab;
        [SerializeField] private RecoveryItem _recoveryItemPrefab;

        public ObjectInstanceData GetInstanceData()
        {
            if (!RandomGOIS.Probability(_generateProbability))
            {
                _isIronBallInstanced = false;

                return null;
            }

            Vector3 position = Vector3.up * Random.Range(_bottom, _top);
            OtherObject prefab = GetPrefab();

            return prefab == null ? null : new ObjectInstanceData(prefab, position);
        }

        OtherObject GetPrefab()
        {
            if (RandomGOIS.Probability(_fullRecoveryProbability))
            {
                _isIronBallInstanced = false;

                return _fullRecoveryItemPrefab;
            }

            if (RandomGOIS.Probability(_ironBallProbability))
            {
                if (_isIronBallInstanced)
                {
                    _isIronBallInstanced = false;

                    return null;
                }

                _isIronBallInstanced = true;

                return _ironBallPrefab;
            }

            _isIronBallInstanced = false;

            return _recoveryItemPrefab;
        }
    }

    [SerializeField] private int _count, _addScore = 10;
    private int _index;
    [SerializeField] private float _space;
    private float _roopDistance, _roopSpace;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private ObjectPoint _prefab;
    private ObjectPoint[] _points;
    [SerializeField] private PlayerCharacter _playerCharacter;
    private StageScene _main;
    [SerializeField] private ObjectGenerator _objectGenerator;

    void Awake()
    {
        _main = GetComponent<StageScene>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _roopDistance = _startPoint.position.x - _space - _playerCharacter.transform.position.x;
        _roopSpace = _space * _count;

        Vector3 position = _startPoint.position;

        _points = new ObjectPoint[_count];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = Instantiate(_prefab, position, Quaternion.identity, _startPoint);

            position.x += _space;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        if (!_playerCharacter)
            return;

        ObjectPoint target = _points[_index];

        Transform targetTransform = target.transform;

        if (targetTransform.position.x - _playerCharacter.transform.position.x >= _roopDistance)
            return;

        Vector3 position = targetTransform.position;

        position.x += _roopSpace;

        targetTransform.position = position;

        target.NewObject(_objectGenerator.GetInstanceData());

        _main.AddDistanceScore(_addScore);

        _index++;

        if (_index >= _points.Length)
            _index = 0;
    }
}
