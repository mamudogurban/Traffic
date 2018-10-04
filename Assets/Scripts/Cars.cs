using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Player;
using UnityEngine;
using UnityEngine.UI;

public class Cars : MonoBehaviour
{
    private float hitspeed = 50;
    public static Cars Instance2;
    private GameObject _animatorComponent;
    private bool _movement = true;
    public float SpeedMultiplier;
    public bool Movement{

        get { return _movement; }

        set
        {
            _movement = value;
        }

    }

    void Awake()
    {
        Instance2 = this;
    }

   

    void Start()
    {
       
    }

    void Update()



    {

        if (!Movement) 
        {
            return;
        }

       
            transform.position += transform.forward * SpeedMultiplier;

       
    }

    void OnCollisionEnter(Collision collision)
    {

        Controller.Instance.playing = false;

        Debug.Log("kaza");

      


        _animatorComponent = Instantiate(Resources.Load<GameObject>("BigExplosionEffect") );
        _animatorComponent.transform.position = collision.gameObject.transform.position;
        _movement = false;
        _animatorComponent = Instantiate(Resources.Load<GameObject>("SmokeEffect"));







    }



    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == 10)
        {
            Debug.Log("puan");

            Controller.Instance.score += 50;
        }

        if (other.gameObject.layer == 11)
        {

            Destroy(gameObject);
        } 

    }
   


}


