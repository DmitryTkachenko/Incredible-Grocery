using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingScript : MonoBehaviour
{
    private float speedOfBuyer = 0.008f;    
    private float progress;
    private Vector3 startPosition;
    private Vector3 doorPosition = new Vector3(-6.87f, 0.65f, -1);
    private Vector3 counterPosition = new Vector3(-1.5f, 0.5f, -1);
    private bool buyerIsNextToTheDoor;    

    public Vector2 direction;
    public float acceleration;
    public float gravityWhileJumping;
    
    public float delayBetwinJumping;
    public int numberOfjumps;

   

    // Start is called before the first frame update
    void Start()
    {        
        startPosition = transform.position;
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!buyerIsNextToTheDoor)
        {
            transform.position = Vector3.Lerp(startPosition, doorPosition, progress);
            progress += speedOfBuyer;
            if (transform.position == doorPosition)
            {
                buyerIsNextToTheDoor = true;
                progress = 0;
                GameObject.Find("Entrance").transform.position = new Vector3(-7.258f, 1.4648f, 0);
                speedOfBuyer = 0.005f;
                GetComponent<Rigidbody2D>().gravityScale = gravityWhileJumping;
                StartCoroutine(JumpingCoroutine());
            }

        }
        if (buyerIsNextToTheDoor)
        {
            transform.position = Vector3.Lerp(doorPosition, counterPosition, progress);
            progress += speedOfBuyer;
        }
        if (transform.position == counterPosition  && !GameBehaviour.current.thereIsUnion)
        {
           
            GameBehaviour.current.bayerWantToSay = true;
            GameBehaviour.current.thereIsUnion = true;
        }

        //Vector3(4.6282115, 4.6282115, 4.6282115)  Vector3(1.78999996,2.36999989,-1)


    }

    IEnumerator JumpingCoroutine ()
    {
        for (var i = 0; i < numberOfjumps; i++)
        {
            GetComponent<Rigidbody2D>().AddForce(direction.normalized * acceleration, ForceMode2D.Impulse);
            yield return new WaitForSeconds(delayBetwinJumping);
        }
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }
}
