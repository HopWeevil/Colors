using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(ShapesPool))]
public class ColoredShapesSpawner : MonoBehaviour
{
    [SerializeField] private MainColoredShape _mainColoredShape;
    [SerializeField] private ColoredShape shapeTemplate;
    [SerializeField] private ShapesPool _pool;
    [SerializeField] private Sprite[] _shapes;

    [SerializeField] private float lineSpacing;
    [SerializeField] private int minObjectsPerLine;
    [SerializeField] private int maxObjectsPerLine;
    [SerializeField] private int minLines;
    [SerializeField] private int maxLines;

    [SerializeField] private float _shapeColorModifier;
    [SerializeField] private float _shapeMinBrightness;
    [SerializeField] private int _maxIdenticalShapesAmount;

    public void Initialize()
    {
        int capacity = maxObjectsPerLine * maxLines;
        _pool.Initialize(shapeTemplate, capacity);
    }

    public void Spawn()
    {
        for (int lineIndex = 0; lineIndex < GetLinesAmount(); lineIndex++)
        {
            SpawnLine(lineIndex);
        }

        ColoredShape correctShape = _pool.GetRandomActiveShape();
        SetColors(correctShape);
        SetShapes(correctShape);
    }


    private void SetColors(ColoredShape correctShape)
    {
        _mainColoredShape.SetColor(_shapeMinBrightness);

        foreach(var shape in _pool.Shapes)
        {
            shape.SetColor(_mainColoredShape.Color, _shapeColorModifier);
        }

        correctShape.SetColor(_mainColoredShape.Color);
    }

    private List<Sprite> GetRandomShapeSprites(int count)
    {
        List<Sprite> shuffledShapes = _shapes.OrderBy(x => Random.value).Take(count).ToList();
        return shuffledShapes;
    }

    private void SetShapes(ColoredShape correctShape)
    {
        List<Sprite> randomSprites = GetRandomShapeSprites(_maxIdenticalShapesAmount);

        _mainColoredShape.SetShape(randomSprites[Random.Range(0, randomSprites.Count)]);

        foreach (var shape in _pool.Shapes)
        {
            shape.SetShape(randomSprites[Random.Range(0, randomSprites.Count)]); 
        }

        correctShape.SetShape(_mainColoredShape.Sprite); 
    }

    private void SpawnLine(int lineIndex)
    {
        int objectsInLine = GetObjectsPerLineAmount();
        float totalWidth = objectsInLine * lineSpacing - lineSpacing;
        float xOffset = -totalWidth / 2;

        Vector3 spawnPosition = transform.position + new Vector3(xOffset, -lineIndex * lineSpacing);

        for (int i = 0; i < objectsInLine; i++)
        {
            PlaceShape(spawnPosition);
            spawnPosition.x += lineSpacing;

        }
    }

    private void PlaceShape(Vector3 position)
    {
        if (_pool.TryGetShape(out ColoredShape shape))
        {
            shape.gameObject.SetActive(true);
            shape.transform.position = position;
        }
    }

    private int GetLinesAmount()
    {
        return Random.Range(minLines, maxLines + 1);
    }

    private int GetObjectsPerLineAmount()
    {
        return Random.Range(minObjectsPerLine, maxObjectsPerLine + 1);
    }
}