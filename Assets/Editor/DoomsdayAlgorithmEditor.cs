using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DoomsdayAlgorithm))]
public class DoomsdayAlgorithmEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        DoomsdayAlgorithm myScript = (DoomsdayAlgorithm)target;

        if (GUILayout.Button("Run"))
        {
            myScript.SetWeekDay();
        }

        EditorGUILayout.LabelField("Leap year", myScript.leapYear.ToString());

        EditorGUILayout.LabelField("Day of the week", myScript.dayOfTheWeek);
    }
}
