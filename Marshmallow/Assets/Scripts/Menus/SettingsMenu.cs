using UnityEditor;
using UnityEngine;

public class SettingsMenu : CanvasBase
{
    protected override void Awake()
    {
        menuType= MenuType.Settings;
        base.Awake();
    }
    public override void OnBack()
    {
        base.OnBack();
    }
}
