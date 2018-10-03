using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
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
    public Text scoreTxt;
    public int score;
    public Transform[] spawnpoint1;
    public Transform[] spawnpoint2;
    
   
    private List<string> _cars;
    private List<Cars> _carList;
   
    private void Awake()
    {



        Instance = this;
    }

    void Start()
    {
        score = 0;
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


        int spawnPointIndex = Random.Range(0, spawnpoint1.Length);
        int carIndex = Random.Range(0, _cars.Count);
        var spawnPointIndex2 = Random.Range(0, spawnpoint2.Length);
        var car = Instantiate(Resources.Load<Cars>(_cars[carIndex]), spawnpoint1[spawnPointIndex].position,spawnpoint1[spawnPointIndex].rotation);
        var car2 = Instantiate(Resources.Load<Cars>(_cars[carIndex]), spawnpoint2[spawnPointIndex2].position, spawnpoint2[spawnPointIndex2].rotation);
      

        _carList.Add(car2);
        _carList.Add(car);

        //spawntime = Random.

        yield return new WaitForSeconds(Random.Range(2f,4f));

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

        scoreTxt.text = "SCORE:" + score.ToString();



        if (score == 200)
        {
            Debug.Log("LevelUp");
            new WaitForSeconds(Random.Range(1.5f, 2));
        }
       
    }


    

}

