using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateChildren : MonoBehaviour
{
    public Hook hook;
    public SpriteRenderer children;

    private void Update()
    {
        Debug.Log(hook.hook);
        if (hook.hook)
        {
            children.enabled = true;
        } else
        {
            children.enabled = false;
        }
    }
}
