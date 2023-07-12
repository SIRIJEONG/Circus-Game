using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public static partial class GFunc
{
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object message)
    {
#if DEBUG_MODE
        Debug.Log(message);
#endif
    }


    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void LogWarning(object message)
    {
#if DEBUG_MODE
        Debug.LogWarning(message);
#endif
    }




    public static void SetText(this GameObject target, string text)
    {
        Text textComponent = target.GetComponent<Text>();
        if (textComponent == null)
        {
            return;
        }
        textComponent.text = text;
    }

    public static string GetActiveSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }


    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //! 두 벡터를 더한다. 
    public static Vector2 AddVector(this Vector3 origin, Vector2 addVector)
    {
        Vector2 result = new Vector2(origin.x, origin.y);
        result += addVector;
        return result;
    }


    //!컴포넌트가 존재하는지 여부를 체크하는 함수 
    public static bool IsValid<T>(this T target) where T : Component
    {
        if (target == null || target == default) { return false; }
        else { return true; }
    }


    //!리스트가 유효한지 여부를 체크하는 함수 
    public static bool IsValid<T>(this List<T> target) where T : Component
    {

        bool isInValid = (target == null || target == default);
        isInValid = isInValid || target.Count == 0;

        if (target == null || target == default) { return false; }
        else { return true; }
    }
}

