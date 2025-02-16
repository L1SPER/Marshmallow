using UnityEditor;

[CustomEditor(typeof(CanvasBase),true)]
public class CanvasBaseEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        // CanvasBase referansı al
        CanvasBase canvasBase= (CanvasBase) target;

        // Default Inspector elemanlarını çiz
        DrawDefaultInspector();

        // backActionType'a bağlı olarak ilgili alanları göster/gizle
        SerializedProperty sceneToLoadProp= serializedObject.FindProperty("sceneToLoad");
        SerializedProperty backButtonProp= serializedObject.FindProperty("backButton");

        if(canvasBase.backActionType== CanvasBase.BackActionType.LoadScene)
        {
            EditorGUILayout.PropertyField(sceneToLoadProp);
        }
        if(canvasBase.backActionType== CanvasBase.BackActionType.OpenPreviousMenu)
        {
            EditorGUILayout.PropertyField(backButtonProp);
        }
        
        serializedObject.ApplyModifiedProperties();
    }
}
