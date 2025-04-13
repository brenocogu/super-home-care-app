using UnityEditor;
using UnityEngine;
using VContainer;

namespace SuperHomeCare.AppRoot
{
    [ExecuteAlways]
    public class AppRootDomain
    {
#if UNITY_EDITOR
        [MenuItem("Editor/Refresh #%r")]
        private static void Refresh()
        {
            Debug.Log("Request script reload.");

            EditorApplication.UnlockReloadAssemblies();
           
            AssetDatabase.Refresh();

            EditorUtility.RequestScriptReload();
        }
        
        [InitializeOnLoadMethod]
        public static void InitializeEditorPreferences()
        {
            Debug.Log("Script realoded!");
       
            AssetDatabase.SaveAssets();

            EditorApplication.LockReloadAssemblies();
        }
#endif
    }
}