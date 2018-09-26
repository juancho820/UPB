using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour {

    public GameObject padre;

    public void Desactivar()
    {
        padre.SetActive(false);
    }
}
