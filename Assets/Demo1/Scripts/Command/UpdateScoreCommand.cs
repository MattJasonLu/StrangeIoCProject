using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScoreCommand : EventCommand
{
    [Inject]
    public ScoreModel scoreModel { get; set; } // ScoreModel唯一

    [Inject]
    public IScoreService scoreService { get; set; }

    public override void Execute()
    {
        scoreModel.Score++;
        scoreService.UpdateScore("http://xxx/xxx", scoreModel.Score);

        dispatcher.Dispatch(Demo1MediatorEvent.ScoreChange, scoreModel.Score);
    }
}
