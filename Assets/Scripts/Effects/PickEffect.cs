using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class PickEffect : MonoBehaviour
{
    private ParticleSystem _correctPick;
    private ParticleSystem.MainModule _mainModule;

    private void Awake()
    {
        _correctPick = GetComponent<ParticleSystem>();
    }

    public void Play(ColoredShape coloredShape)
    {
        _mainModule = _correctPick.main;
        _mainModule.startColor = coloredShape.Color;
        _correctPick.Play();
    }
}