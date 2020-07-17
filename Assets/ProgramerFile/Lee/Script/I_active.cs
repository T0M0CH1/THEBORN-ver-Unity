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
    public static void Set_Item(GameObject obj, bool flag)
    {
        obj.SetActive(flag);
    }

    /// <summary>
    /// アイテム持続時間
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="dur">時間</param>
    /// <returns></returns>
    public static IEnumerator duration(GameObject obj, float dur)
    {
        yield return new WaitForSecondsRealtime(dur);
        obj.SetActive(false);
    }
 }
