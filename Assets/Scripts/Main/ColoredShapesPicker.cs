using UnityEngine;
using UnityEngine.Events;

public class ColoredShapesPicker : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    public event UnityAction<ColoredShape> ColoredShapePicked;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit && hit.collider.TryGetComponent(out ColoredShape shape))
            {
                ColoredShapePicked?.Invoke(shape);
            }          
        }
    }
}