using System.Collections;
using System.Collections.Generic;
using System.Net.Configuration;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour
{
    //not working right
    
    private List<Renderer> customerRenders;  //all customers in scene
    public GameObject arrow; //the arrow
    public GameObject camera; //the camera

    public List<GameObject> arrowList;
    
    
    // Start is called before the first frame update
    void Start()
    {
        arrowList = new List<GameObject>();
        
        //find the camera
        camera = FindObjectOfType<CameraScript_Follow>().gameObject;
        
        //find all the customers
        customerRenders = new List<Renderer>();

        foreach (var customer in FindObjectsOfType<InteractCustomer>())
        {
            customerRenders.Add(customer.gameObject.GetComponent<Renderer>());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var eachArrow in arrowList)
        {
            Destroy(eachArrow);
            arrowList.Remove(eachArrow);
        }
        //CheckRender();
        foreach (var render in customerRenders)
        {
            if (!render.isVisible)
            {
                Vector3 arrowSpawn = new Vector3(camera.transform.position.x - 4.49f, camera.transform.position.y - 6.06f,
                    camera.transform.position.z - 11.09f);
                Instantiate(arrow, arrowSpawn, Quaternion.identity);
                arrowList.Add(arrow);
            }
        }
        
        

    }
}
