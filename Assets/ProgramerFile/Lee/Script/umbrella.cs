using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class umbrella
{
   static float dur = 10.0f;  
    
   static public void Set_Item(GameObject obj, bool flag)
    {
        obj.SetActive(flag);
    }

    static public IEnumerator duration(GameObject obj)
    {
        yield return new WaitForSeconds(dur);
        obj.SetActive(false);
    }
}
