using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    private int amount;

    public event UnityAction<int> AmountChange;

    public void Increase()
    {
        amount++;
        AmountChange?.Invoke(amount);
    }

    public void SetAmount(int value = 0)
    {
        amount = value;
        AmountChange?.Invoke(amount);
    }
}
