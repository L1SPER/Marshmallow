using UnityEditor;
using UnityEngine;
public class QuitMenu : CanvasBase
{
    protected override void Awake()
    {
        menuType= MenuType.Quit;
        base.Awake();
    }
    public override void OnBack()
    {
        base.OnBack();
    }
}
