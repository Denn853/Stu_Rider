using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    public Canvas prefabUI;
    private Canvas uiUse;
    
    // Start is called before the first frame update
    void Start()
    {
        uiUse = Instantiate(prefabUI, FindObjectOfType<Canvas>().transform).GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
