using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class GameBehaviour : MonoBehaviour
{
    public static GameBehaviour current;
    public GameObject buyerPrefab;
    public GameObject[] Products;
    private List<GameObject> SubListOfProducts;
    private GameObject[] Order;
    private GameObject[] OrderClones;
    private int amountOPproducts;
    public bool  thereIsUnion;
    public float orderUnionVisibleDelie;


    private int[] rendSubArray;

    public bool bayerWantToSay;
    public GameObject UnionOfOrderPrefab;
    private GameObject UnionOrOrderClone;



    private void Awake()
    {
        current = this;
    }

    // Start is called before the first frame update
    void Start()
    {
       
         Instantiate(buyerPrefab, new Vector3(-8.3f, 0.95f, -1), Quaternion.identity);
        //current.amountOPproducts = Products.Count;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (bayerWantToSay == true)
        {
            StartCoroutine(OrderVisibleCoroutine());
            bayerWantToSay = false;
        }
    }

    IEnumerator OrderVisibleCoroutine()
    {
        Ordering();
        current.UnionOrOrderClone =(GameObject)Instantiate(UnionOfOrderPrefab, new Vector3(1.78f, 2.36f, -1), Quaternion.identity);
        bayerWantToSay = false;
        yield return new WaitForSeconds(orderUnionVisibleDelie);
       MakeOrderIvisable();
    }

    void Ordering()
    {
        System.Random randAmountProducts=new System.Random();
        var amountProducts = randAmountProducts.Next(1,4);
        Order = new GameObject[amountProducts];
        OrderClones = new GameObject[amountProducts];
        for (var i = 0; i < amountProducts; i++)
        {
            System.Random randProducts = new System.Random();
            var randProductId = randProducts.Next(1, Products.Length);
            current.Order[i] = Products[randProductId];
            GameObject obgToRemove = Products[randProductId];
            Products = Products.Where(val => val != obgToRemove).ToArray();
        }
        switch (amountProducts)
        {
            case 1:
                current.OrderClones[0] = (GameObject)Instantiate(Order[0], new Vector3(1.67f, 2.66f, -5), Quaternion.identity);/*.transform.localScale = new Vector3(2.77f, 2.77f, 1);*/
                current.OrderClones[0].transform.localScale = new Vector3(2.77f, 2.77f, 1);
                break;
            case 2:
                current.OrderClones[0] = (GameObject)Instantiate(Order[0], new Vector3(2.31f, 2.66f, -5), Quaternion.identity);
                current.OrderClones[0].transform.localScale = new Vector3(2.77f, 2.77f, 1);
                current.OrderClones[1] = (GameObject)Instantiate(Order[1], new Vector3(0.94f, 2.66f, -5), Quaternion.identity);
                current.OrderClones[1].transform.localScale = new Vector3(2.77f, 2.77f, 1);
                break;
            case 3:
                current.OrderClones[0] = (GameObject)Instantiate(Order[0], new Vector3(0.45f, 2.66f, -5), Quaternion.identity);
                current.OrderClones[0].transform.localScale = new Vector3(2.77f, 2.77f, 1);
                current.OrderClones[1] = (GameObject)Instantiate(Order[1], new Vector3(1.74f, 2.66f, -5), Quaternion.identity);
                current.OrderClones[1].transform.localScale = new Vector3(2.77f, 2.77f, 1);
                current.OrderClones[2] = (GameObject)Instantiate(Order[2], new Vector3(2.96f, 2.66f, -5), Quaternion.identity);
                current.OrderClones[2].transform.localScale = new Vector3(2.77f, 2.77f, 1);
                break;
        }
    }

    void MakeOrderIvisable()
    {

        for (var i = 0; i < current.OrderClones.Length; i++)
        {
            current.OrderClones[i].GetComponent<Renderer>().enabled = false;

        }
        current.UnionOrOrderClone.GetComponent<Renderer>().enabled = false;
    }
}
