using UnityEngine;

public class Chapter1Menu : CanvasBase
{
    protected override void Awake()
    {
        menuType= MenuType.Chapter1;
        base.Awake();
    }
    public override void OnBack()
    {
        base.OnBack();
    }
}
