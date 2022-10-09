using UnityEngine;
public static class ExitTR 
{
    public static void DestroyChildren(this Transform tr, bool destroyImmediatelty = false)
    {
        foreach (Transform childTr in tr)
        {
            if (destroyImmediatelty == true)
            { MonoBehaviour.DestroyImmediate(childTr.gameObject); }
            else
            { MonoBehaviour.Destroy(childTr.gameObject); }
        }
        
    }
}
