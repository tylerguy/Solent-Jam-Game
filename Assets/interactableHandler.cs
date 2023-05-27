using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableHandler : MonoBehaviour
{
    public void interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
    }
}
