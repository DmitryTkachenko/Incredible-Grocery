using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;


public class GameBehaviour : MonoBehaviour
{
    public static GameBehaviour current;
    public GameObject buyerPrefab;
    public GameObject[] Products;
    private List<GameObject> SubListOfProducts;
    private GameObject[] Order;
    private GameObject[] OrderClones;
    private int amountOPproducts;
    public bool thereIsUnion;
    public float orderUnionVisibleDelie;


    private int[] rendSubArray;

    public bool bayerWantToSay;
    public GameObject UnionOfOrderPrefab;
    private GameObject UnionOrOrderClone;

    private Vector3 storegeStartPosition;
    private Vector3 storegeFinishPosition;
    public float speedStorage;
    private float progressOfStorage;
    public GameObject Storage;
    private bool storageShoulBeVisible;

    public GameObject[] PointedProducts;
    private int amountProducts;
    private GameObject[] TickClones;
    public GameObject Tick;
    int counter = 0;
    public GameObject SellButton;
    public float alphaValueInvisibleSell;

    private void Awake()
    {
        current = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;        
        storegeStartPosition = new Vector3(12.26f, 0.34f, -1);
        storegeFinishPosition = new Vector3(5.71f, 0.34f, -1);
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
        if (storageShoulBeVisible)
        {
            Storage.transform.position = Vector3.Lerp(storegeStartPosition, storegeFinishPosition, progressOfStorage);
            progressOfStorage += speedStorage;
        }
    }

    IEnumerator OrderVisibleCoroutine()
    {
        Ordering();
        UnionOrOrderClone =(GameObject)Instantiate(UnionOfOrderPrefab, new Vector3(1.78f, 2.36f, -1), Quaternion.identity);
        bayerWantToSay = false;
        yield return new WaitForSeconds(orderUnionVisibleDelie);
       MakeOrderInvisable();
        storageShoulBeVisible = true;
        
    }

    void Ordering()
    {
        System.Random randAmountProducts=new System.Random();
        amountProducts = randAmountProducts.Next(1,4);
        PointedProducts = new GameObject[amountProducts];
        Order = new GameObject[amountProducts];
        OrderClones = new GameObject[amountProducts];
        for (var i = 0; i < amountProducts; i++)
        {
            System.Random randProducts = new System.Random();
            var randProductId = randProducts.Next(1, Products.Length);
            Order[i] = Products[randProductId];
            GameObject obgToRemove = Products[randProductId];
            Products = Products.Where(val => val != obgToRemove).ToArray();
        }
        switch (amountProducts)
        {
            case 1:
                OrderClones[0] = (GameObject)Instantiate(Order[0], new Vector3(1.67f, 2.66f, -5), Quaternion.identity);/*.transform.localScale = new Vector3(2.77f, 2.77f, 1);*/
                OrderClones[0].transform.localScale = new Vector3(2.77f, 2.77f, 1);
                break;
            case 2:
                OrderClones[0] = (GameObject)Instantiate(Order[0], new Vector3(2.31f, 2.66f, -5), Quaternion.identity);
                OrderClones[0].transform.localScale = new Vector3(2.77f, 2.77f, 1);
                OrderClones[1] = (GameObject)Instantiate(Order[1], new Vector3(0.94f, 2.66f, -5), Quaternion.identity);
                OrderClones[1].transform.localScale = new Vector3(2.77f, 2.77f, 1);
                break;
            case 3:
                OrderClones[0] = (GameObject)Instantiate(Order[0], new Vector3(0.45f, 2.66f, -5), Quaternion.identity);
                OrderClones[0].transform.localScale = new Vector3(2.77f, 2.77f, 1);
                OrderClones[1] = (GameObject)Instantiate(Order[1], new Vector3(1.74f, 2.66f, -5), Quaternion.identity);
                OrderClones[1].transform.localScale = new Vector3(2.77f, 2.77f, 1);
                OrderClones[2] = (GameObject)Instantiate(Order[2], new Vector3(2.96f, 2.66f, -5), Quaternion.identity);
                OrderClones[2].transform.localScale = new Vector3(2.77f, 2.77f, 1);
                break;
        }
    }

    void MakeOrderInvisable()
    {

        for (var i = 0; i < OrderClones.Length; i++)
        {
            OrderClones[i].GetComponent<Renderer>().enabled = false;

        }
       UnionOrOrderClone.GetComponent<Renderer>().enabled = false;
    }

    public void CompareOrderAndBusket(GameObject productInBasket)
    {

        Vector3 prodPos = productInBasket.transform.position;
        TickClones = new GameObject[amountProducts];
        if (counter < amountProducts)
        {
            TickClones[counter] = (GameObject)Instantiate(Tick, new Vector3(prodPos.x, prodPos.y, prodPos.z - 1), Quaternion.identity);
            counter++;
        }
    }
}
