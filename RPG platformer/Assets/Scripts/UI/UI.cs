using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchTo(GameObject _menu)
    {
        // cycles through all children of the UI, find all the elements, switch them off
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        // switch on the one we need
        if (_menu != null)
            _menu.SetActive(true);
    }
}
