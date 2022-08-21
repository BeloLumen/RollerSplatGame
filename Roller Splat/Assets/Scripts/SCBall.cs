using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SCBall : MonoBehaviour
{
    public Rigidbody rb;

    private Vector2 firstPos;
    private Vector2 lastPos;
    public Vector2 currentPos;
    public float moveSpeed;
    public Material successMaterial;
    public float currentGroundNumber;
    private SCGameManager gm; 
    
    void Start()
    {
        gm = FindObjectOfType<SCGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Swipe();
        
    }
    private void LateUpdate()
    {
        if (currentGroundNumber == gm.groundNumber)
        {
            gm.LevelUpdate();
        }
    }

    private void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        }
        if (Input.GetMouseButtonUp(0))
        {
            lastPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            currentPos = new Vector2(lastPos.x - firstPos.x , lastPos.y -firstPos.y);
        }
        currentPos.Normalize();

        if(currentPos.y < 0 && currentPos.x < 0.5f && currentPos.x > -0.5f)
        {
            //down
            rb.velocity = Vector3.back * moveSpeed;
        }
        else if ( currentPos.y > 0 && currentPos.x < 0.5f && currentPos.x > -0.5f)
        {
            //up 
            rb.velocity = Vector3.forward * moveSpeed;
        }
        else if (currentPos.x < 0 && currentPos.y < 0.5f && currentPos.y > -0.5f)
        {
            // left 
            rb.velocity = Vector3.left * moveSpeed;
        }
        else if (currentPos.x > 0 && currentPos.y < 0.5f && currentPos.y > -0.5f)
        {
            //right
            rb.velocity = Vector3.right * moveSpeed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<MeshRenderer>().material.color != successMaterial.color)
        {
            if (collision.gameObject.tag == "Ground")
            {
                collision.gameObject.GetComponent<MeshRenderer>().material = successMaterial;
                currentGroundNumber++;
            }
        }
        
    }

}
