using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class I_active
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="flag"></param>
    public static void Set_umbrella(GameObject obj, bool flag)
    {
        obj.SetActive(flag);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="dur"></param>
    /// <returns></returns>
    public static IEnumerator duration(GameObject obj, float dur)
    {
        yield return new WaitForSeconds(dur);
        obj.SetActive(false);
    }
}
