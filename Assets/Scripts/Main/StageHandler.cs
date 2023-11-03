using UnityEngine;
using UnityEngine.Events;

public class StageHandler : MonoBehaviour
{
    [SerializeField] private MainColoredShape _mainColoredShape;
    [SerializeField] private ColoredShapesPicker _shapesPicker;

    public event UnityAction StageCompleted;
    public event UnityAction StageFailed;

    private void OnEnable()
    {
        _shapesPicker.ColoredShapePicked += OnColoredShapePicked;
    }
    private void OnDisable()
    {
        _shapesPicker.ColoredShapePicked -= OnColoredShapePicked;
    }

    private void OnColoredShapePicked(ColoredShape coloredShape)
    {
        if (coloredShape.Color == _mainColoredShape.Color)
        {
            coloredShape.PlayPickEffect();
            StageCompleted?.Invoke();
        }
        else
        {
            StageFailed?.Invoke();
        }
    }
}