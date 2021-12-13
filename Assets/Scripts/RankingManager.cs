using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RankingManager : SingletonBehaviour<RankingManager>
{
    [SerializeField] private int[] _ranking = new int[5];

    int[] DefaultRanking
    {
        get
        {
            int[] ranking = new[]
            {
                5000,
                4000,
                3000,
                2000,
                1000
            };

            return ranking;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void Init()
    {
        _ranking = DefaultRanking;
    }

    protected override void AwakeChild()
    {
    }

    public ScoreElement[] AddScore(int score)
    {
        List<ScoreElement> list = _ranking.Select(s => new ScoreElement(s, false)).ToList();

        list.Add(new ScoreElement(score, true));
        list.Sort((a, b) => b.Score - a.Score);
        list.RemoveAt(list.Count - 1);

        _ranking = list.Select(e => e.Score).ToArray();

        return list.ToArray();
    }
}
