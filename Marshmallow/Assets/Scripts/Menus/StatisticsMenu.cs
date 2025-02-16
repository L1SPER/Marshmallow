using UnityEditor;
using UnityEngine;

public class StatisticsMenu : CanvasBase
{
    protected override void Awake()
    {
        menuType= MenuType.Statistics;
        base.Awake();
    }
    public override void OnBack()
    {
        base.OnBack();
    }
}
