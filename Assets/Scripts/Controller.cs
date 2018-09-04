using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public static Controller Instance;

    private GameObject _car1;
    private GameObject _car2;
    private GameObject _car3;
    private GameObject _car4;
    private GameObject _bus1;
    private GameObject _bus2;
    private GameObject _taxi;
    private float _spawnTimer;
    public bool playing;
   
    public Transform[] spawnpoint;
    private float spawntime = 3f;
   
   
    private List<string> _cars;
    private List<Cars> _carList;

    private void Awake()
    {



        Instance = this;
    }

    void Start()
    {
        playing = true;
        _cars = new List<string>();
        _cars.Add("Car1");
        _cars.Add("Car2");
        _cars.Add("Car2");
        _cars.Add("Car4");
        _cars.Add("Bus1");
        _cars.Add("Bus2");
        _cars.Add("Taxi");
        //InvokeRepeating("SUpdate", spawntime, spawntime);

        _carList = new List<Cars>();

        StartCoroutine(SUpdate());
    }


    private IEnumerator SUpdate()
    {
        if (!playing)
        {
            yield break;
        }


        int spawnPointIndex = Random.Range(0, spawnpoint.Length);
        int carIndex = Random.Range(0, _cars.Count);

        var car = Instantiate(Resources.Load<Cars>(_cars[carIndex]), spawnpoint[spawnPointIndex].position,
            spawnpoint[spawnPointIndex].rotation);

     

        _carList.Add(car);

        //spawntime = Random.

        yield return new WaitForSeconds(Random.Range(2, 4));

        StartCoroutine(SUpdate());
    }




    void Update()
    {

        
       

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                hit.collider.gameObject.GetComponent<Cars>().Movement=!hit.collider.gameObject.GetComponent<Cars>().Movement;
                Debug.Log("You selected the " + hit.transform.name);
                
            }

        }
    }


    

}

