using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Score), typeof(TMP_Text))]
public class ScoreView : MonoBehaviour
{
    private Score _score;
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        _score = GetComponent<Score>();
    }

    private void OnEnable()
    {
        _score.AmountChange += OnAmountChanged;
    }

    private void OnDisable()
    {
        _score.AmountChange -= OnAmountChanged;
    }

    private void OnAmountChanged(int amount)
    {
        _text.text = amount.ToString();
    }
}