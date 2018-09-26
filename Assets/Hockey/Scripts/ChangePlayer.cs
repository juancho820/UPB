using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayer : MonoBehaviour {
    [SerializeField]
    private GameObject player;

	void Start () {
        CambiarScript(false);
    }

    public void CambiarScript(bool valor)
    {
        if (valor)
        {
            player.GetComponent<PlayerDrag>().enabled = true;
            player.GetComponent<PlayerButtons>().enabled = false;
        }
        else
        {
            player.GetComponent<PlayerDrag>().enabled = false;
            player.GetComponent<PlayerButtons>().enabled = true;
        }
    }
}
