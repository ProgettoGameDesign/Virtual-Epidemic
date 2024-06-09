using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class ResetScriptableObjectsOnPlay
{
    // Il costruttore statico viene chiamato automaticamente quando Unity compila gli script
    static ResetScriptableObjectsOnPlay()
    {
        // Registra il metodo da chiamare quando cambia lo stato della modalità di gioco
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    }

    private static void OnPlayModeStateChanged(PlayModeStateChange state)
    {
        // Quando si entra in modalità di gioco
        if (state == PlayModeStateChange.ExitingEditMode)
        {
            // Trova tutte le istanze di PlayerData nel progetto
            string[] guids = AssetDatabase.FindAssets("t:SceneState");
            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                SceneState playerData = AssetDatabase.LoadAssetAtPath<SceneState>(path);
                if (playerData != null)
                {
                    // Resetta i dati
                    playerData.ResetData();

                    // Salva le modifiche nel file dell'asset
                    EditorUtility.SetDirty(playerData);
                }
            }

            // Assicura che le modifiche siano scritte su disco
            AssetDatabase.SaveAssets();
        }
    }
}
