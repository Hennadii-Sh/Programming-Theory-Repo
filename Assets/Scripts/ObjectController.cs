using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    [SerializeField] private float rotationSpeed = 120;
    private Vector3 rotationPoint;

    private void Awake()
    {
        rotationPoint = transform.position;
    }




    //public void XObjectRotation(float input)
    //{
    //    float rotationAmount = -input * rotationSpeed * Time.deltaTime;
    //    gameObject.transform.RotateAround(rotationPoint, Vector3.right, rotationAmount);
    //    //    gameObject.transform.Rotate(Vector3.right, rotationAmount);
    //}
    public void YObjectRotation(float input)
    {
        float rotationAmount = input * rotationSpeed * Time.deltaTime;
        gameObject.transform.RotateAround(rotationPoint, Vector3.down, rotationAmount);
        //    gameObject.transform.Rotate(Vector3.up, rotationAmount);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");


        //XObjectRotation(verticalInput);
        YObjectRotation(horizontalInput);
    }

}
