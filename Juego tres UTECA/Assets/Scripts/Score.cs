using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]
    int _score = 100;
    public int score
    {
        get { return _score; }
        set
        {
            _score = value;
            whenScoreChange.Invoke(_score.ToString());
        }
    }
    [SerializeField]
    protected MyStringEvent whenScoreChange;

    public static Score singleton;

    private void Start()
    {
        if(singleton != null)
        {
            Destroy(gameObject);
            return;
        }
        singleton = this;


        whenScoreChange.Invoke(_score.ToString());
    }
}
