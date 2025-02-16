using UnityEditor;
using UnityEngine;

public class StartMenu : CanvasBase
{
    protected override void Awake()
    {
        menuType= MenuType.Main;
        base.Awake();
    }
    public override void OnBack()
    {
        base.OnBack();
    }
}
