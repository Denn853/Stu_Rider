using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObject : MonoBehaviour
{
    public GameObject Obj;
    public float activateTime;

    void Update()
    {
        if (Obj.active == true)
        {
            StartCoroutine(DisableObj());
        }

        IEnumerator DisableObj()
        {
            yield return new WaitForSeconds(activateTime);
            Obj.SetActive(false);
        }
    }
}
