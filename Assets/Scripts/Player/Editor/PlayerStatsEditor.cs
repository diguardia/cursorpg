using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerStats))]
public class PlayerStatsEditor : Editor {
    public PlayerStats stats => target as PlayerStats;

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        
        if (GUILayout.Button("Reset")) {
            stats.Reset();
        }
    }
}