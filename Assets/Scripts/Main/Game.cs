using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private StageHandler _stageHandler;
    [SerializeField] private Score _score;
    [SerializeField] private ColoredShapesSpawner _coloredShapesSpawner;
    [SerializeField] private ShapesPool _shapesPool;

    private void Start()
    {
        _coloredShapesSpawner.Initialize();
        _coloredShapesSpawner.Spawn();
    }

    private void OnEnable()
    {
        _stageHandler.StageFailed += OnStageFailed;
        _stageHandler.StageCompleted += OnStageCompleted;
        _timer.TimeOver += OnTimeOver;
    }

    private void OnDisable()
    {
        _stageHandler.StageFailed -= OnStageFailed;
        _stageHandler.StageCompleted -= OnStageCompleted;
        _timer.TimeOver -= OnTimeOver;
    }

    private void OnStageCompleted()
    {
        _shapesPool.ResetShapes();
        _coloredShapesSpawner.Spawn();
        _timer.Restart();
        _score.Increase();
    }

    private void OnStageFailed()
    {
        GameOver();
    }


    private void OnTimeOver()
    {
        GameOver();
    }

    private void GameOver()
    {

    }

    private void OnApplicationQuit()
    {

    }
}
