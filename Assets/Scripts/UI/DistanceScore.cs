using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceScore : MonoBehaviour
{
    [SerializeField] private Text _distanceText;

    private int _distance = 0;

    private void OnEnable()
    {
        _distance = 0;
        StartCoroutine("IncrementScore");
    }

    private void Update()
    {
        _distanceText.text = _distance.ToString();
    }

    IEnumerator IncrementScore()
    {
        for (; ; )
        {
            _distance++;
            yield return new WaitForSeconds(1f);
        }
    }
}
