using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShapesPool : MonoBehaviour
{
    [SerializeField] private Transform _container;

    private List<ColoredShape> _pool = new List<ColoredShape>();
    public IReadOnlyList<ColoredShape> Shapes => _pool;

    public void Initialize(ColoredShape prefab, int capacity)
    {
        for (int i = 0; i < capacity; i++)
        {
            ColoredShape spawned = Instantiate(prefab, _container);
            spawned.gameObject.SetActive(false);

            _pool.Add(spawned);
        }    
    }

    public bool TryGetShape(out ColoredShape result)
    {
        result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return result != null;
    }

    public ColoredShape GetRandomActiveShape()
    {
        List<ColoredShape> activeShapes = _pool.Where(shape => shape.gameObject.activeSelf).ToList();

        if (activeShapes.Count > 0)
        {
            int randomIndex = Random.Range(0, activeShapes.Count);
            return activeShapes[randomIndex];
        }

        return null;
    }

    public void ResetShapes()
    {
        foreach (ColoredShape shape in _pool)
        {
            shape.gameObject.SetActive(false);
        }
    }
}
