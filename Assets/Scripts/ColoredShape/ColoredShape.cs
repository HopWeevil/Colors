using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class ColoredShape : MonoBehaviour
{
    [SerializeField] private PickEffect _pickEffect;
    private SpriteRenderer _spriteRenderer;

    public Sprite Sprite => _spriteRenderer.sprite;
    public Color Color => _spriteRenderer.color;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetColor(Color main, float modifier)
    {
        Color color = main + new Color(Random.Range(-modifier, modifier), Random.Range(-modifier, modifier), Random.Range(-modifier, modifier));
        _spriteRenderer.color = color;
    }
    public void SetColor(float minBrightness)
    {
        _spriteRenderer.color = new Color(Random.Range(minBrightness, 1f), Random.Range(minBrightness, 1f), Random.Range(minBrightness, 1f));
    }

    public void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }

    public void SetShape(Sprite shape)
    {
        _spriteRenderer.sprite = shape;
    }

    public void PlayPickEffect()
    {
        Instantiate(_pickEffect, transform.position, Quaternion.identity).Play(this);
    }
}