using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] Transform _stageParent;
    [SerializeField] Vector3 _offsetFromCenter;

    List<BaseStage> _startStagePrefabs;
    List<BaseStage> _mobStagePrefabs;
    List<BaseStage> _bonusStagePrefabs;
    List<BaseStage> _bossStagePrefabs;

    Dictionary<BaseStage.Type, List<BaseStage>> _stageObjects;
    public Dictionary<BaseStage.Type, List<BaseStage>> StageObjects { get { return _stageObjects; } }

    const int _maxRow = 3;
    const int _offset = 100;

    int xPos = 0;
    int rowCount = 0;

    public void Initialize(List<BaseStage> startStagePrefabs, List<BaseStage> bonusStagePrefabs, List<BaseStage> mobStagePrefabs, List<BaseStage> bossStagePrefabs)
    {
        _startStagePrefabs = startStagePrefabs;
        _bonusStagePrefabs = bonusStagePrefabs;
        _mobStagePrefabs = mobStagePrefabs;
        _bossStagePrefabs = bossStagePrefabs;

        _stageObjects = new Dictionary<BaseStage.Type, List<BaseStage>>();
    }

    public Dictionary<BaseStage.Type, List<BaseStage>> ReturnStageObjects() { return _stageObjects; }

    public void CreateMap()
    {
        CreateStage(BaseStage.Type.Start, _startStagePrefabs);
        CreateStage(BaseStage.Type.Bonus, _bonusStagePrefabs);
        CreateStage(BaseStage.Type.Mob, _mobStagePrefabs);
        CreateStage(BaseStage.Type.Boss, _bossStagePrefabs);
    }

    void CreateStage(BaseStage.Type type, List<BaseStage> stagePrefabs)
    {
        List<BaseStage> stages = new List<BaseStage>();

        for (int i = 0; i < stagePrefabs.Count; i++)
        {
            Vector3 stagePosition = new Vector3(xPos, rowCount * _offset) + _offsetFromCenter;
            BaseStage stage = Instantiate(stagePrefabs[i], _stageParent);
            stage.transform.position = stagePosition;

            stages.Add(stage);

            rowCount++;
            if (rowCount == _maxRow)
            {
                xPos += _offset;
                rowCount = 0;
            }
        }

        _stageObjects.Add(type, stages);
    }
}
