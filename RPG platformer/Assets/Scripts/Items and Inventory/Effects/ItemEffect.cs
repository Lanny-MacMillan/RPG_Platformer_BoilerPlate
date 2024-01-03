using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class ItemEffect : ScriptableObject
{
    
    public virtual void ExecuteEffect(Transform _enemyPosition)
    {
        Debug.Log("Effect executed!");
    }
}
