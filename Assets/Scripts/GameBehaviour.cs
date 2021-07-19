using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{


    //private GameObject entrance;
    //private float speedOfBuyer = 0.008f;
    public GameObject buyerPrefab;
    //private float progress;
    //private Vector3 startPosition;
    //private Vector3 doorPosition = new Vector3(-6.87f, 0.65f, -1);
    //private Vector3 counterPosition = new Vector3(-0.86f, -0.82f, -1);
    //private bool buyerIsNextToTheDoor;
    private GameObject buyerPrefabClone;

    //public Vector2 direction;
    //public float acceleration;
    //private Rigidbody2D rb  ;
    //bool i;

    // Start is called before the first frame update
    void Start()
    {

        buyerPrefabClone = Instantiate(buyerPrefab, new Vector3(-8.3f, 0.95f, -1), Quaternion.identity);
        //startPosition = buyerPrefabClone.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {  
    //    if (!buyerIsNextToTheDoor)
    //    {
    //        buyerPrefabClone.transform.position = Vector3.Lerp(startPosition, doorPosition, progress);
    //        progress += speedOfBuyer;
    //        if (buyerPrefabClone.transform.position == doorPosition)
    //        {
    //            buyerIsNextToTheDoor = true;
    //            progress = 0;
    //            GameObject.Find("Entrance").transform.position = new Vector3(-7.258f, 1.4648f, 0);
    //            speedOfBuyer = 0.005f;
                 
    //        }
            
    //    }
        
    //    if(buyerIsNextToTheDoor)
    //    {
           
    //        if(!i)
    //        {
    //            rb = buyerPrefabClone.GetComponent<Rigidbody2D>();
    //            rb.AddForce(direction.normalized*acceleration, ForceMode2D.Impulse);
    //            i = true;
    //        }
           
    //        buyerPrefabClone.transform.position = Vector3.Lerp(doorPosition, counterPosition, progress);
    //        progress += speedOfBuyer;
    //    }
        

    }
}
