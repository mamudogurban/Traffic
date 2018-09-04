using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cars : MonoBehaviour
{
    private bool _movement = true;
    public float SpeedMultiplier;
    public bool Movement{

        get { return _movement; }

        set
        {
            _movement = value;
        }

    }



    void Update()



    {

        if (!Movement) 
        {
            return;
        }

       
            transform.position += transform.forward * SpeedMultiplier;
        

    }

    void OnCollisionEnter(Collision col)
    {

        Controller.Instance.playing = false;

        Debug.Log("kaza");

        if (col.gameObject.name == "Sensor")
        {



        }
    }
}
