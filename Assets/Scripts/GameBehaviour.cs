using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    public GameObject buyerPrefab;
    public List<GameObject> Products;

    // Start is called before the first frame update
    void Start()
    {

         Instantiate(buyerPrefab, new Vector3(-8.3f, 0.95f, -1), Quaternion.identity);        
    }

    // Update is called once per frame
    void FixedUpdate()
    {  
    }
}
