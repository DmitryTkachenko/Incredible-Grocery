using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingScript : MonoBehaviour
{
    private bool CloneIsCreated;
    private GameObject entrance;
    private float speedOfBuyer = 0.008f;
    //public GameObject buyerPrefabClone;
    private float progress;
    private Vector3 startPosition;
    private Vector3 doorPosition = new Vector3(-6.87f, 0.65f, -1);
    private Vector3 counterPosition = new Vector3(-0.86f, -0.82f, -1);
    private bool buyerIsNextToTheDoor;
    //private GameObject buyerPrefabClone;

    public Vector2 direction;
    public float acceleration;

    // Start is called before the first frame update
    void Start()
    {
        //if(!CloneIsCreated)
        //{
        //   buyerPrefabClone = Instantiate(buyerPrefab, new Vector3(-8.3f, 0.95f, -1), Quaternion.identity);
        startPosition = this.transform.position;
        this.GetComponent<Rigidbody2D>().gravityScale = 0;

        //}


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!buyerIsNextToTheDoor)
        {
            this.transform.position = Vector3.Lerp(startPosition, doorPosition, progress);
            progress += speedOfBuyer;
            if (this.transform.position == doorPosition)
            {
                buyerIsNextToTheDoor = true;
                progress = 0;
                GameObject.Find("Entrance").transform.position = new Vector3(-7.258f, 1.4648f, 0);
                speedOfBuyer = 0.005f;

            }

        }

        if (buyerIsNextToTheDoor)
        {

            this.GetComponent<Rigidbody2D>().gravityScale = 2;
            //this.GetComponent<Rigidbody2D>().AddForce(direction.normalized * acceleration, ForceMode2D.Impulse);
            


            this.transform.position = Vector3.Lerp(doorPosition, counterPosition, progress);
            progress += speedOfBuyer;
        }


    }


    private void OnCollisionEnter(Collision collision)
    {
        this.GetComponent<Rigidbody2D>().AddForce(direction.normalized * acceleration, ForceMode2D.Impulse);
    }
}
