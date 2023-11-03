using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Image))]
public class Timer : MonoBehaviour 
{
    [SerializeField] private Gradient fillGradient;
    [SerializeField] private float duration;

    private float currentTime;
    private Image image;

    public event UnityAction TimeOver;

    private void Start()
    {
        image = GetComponent<Image>();
        currentTime = duration;
    }

    private void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            float fillAmount = currentTime / duration;
            image.fillAmount = fillAmount;
            image.color = fillGradient.Evaluate(fillAmount);
        }
        else
        {
            TimeOver?.Invoke();
        }
    }

    public void Restart()
    {
        image.fillAmount = 1.0f;
        currentTime = duration;
    }
}