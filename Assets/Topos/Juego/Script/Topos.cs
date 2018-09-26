using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topos : MonoBehaviour {

    private bool subido;    
    private int random;
    private int random2;

    public bool tocado;

    private float tiempo;

    private Animator anim;

    public void Start()
    {
        RandomSelect();
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        tiempo += Time.deltaTime;
        if(tiempo >= random)
        {
            if(subido == false)
            {
                anim.SetTrigger("Subir");
                subido = true;
            }
            if(tocado == false)
            {
                if (tiempo >= random + random2)
                {
                    anim.SetTrigger("Bajar");
                    tiempo = 0;
                    RandomSelect();
                    subido = false;
                }
            }

        }
        if (tocado == true)
        {
            GameManagerTopos.Instance.noMasMonedas = true;
            GameManagerTopos.Instance.GetCoin();
            anim.SetTrigger("Bajar");
            tiempo = 0;
            RandomSelect();
            subido = false;
            tocado = false;
        }

    }

    public void Resetiar()
    {
        GameManagerTopos.Instance.noMasMonedas = false;
    }

    public void RandomSelect()
    {
        random = Random.Range(2, 10);
        random2 = Random.Range(1, 3);
    }
}
