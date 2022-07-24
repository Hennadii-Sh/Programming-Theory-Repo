using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    [SerializeField] private float rotationSpeed = 120;
    [SerializeField] private float zoomSpeed = 5;
    private Vector3 rotationPoint;
    private bool isMaxAngle;
    private bool isMinAngle;
    private float maxAngleX = 70;
    private float minAngleX = 300;
    private float currentCameraAngleX;
    private float minZoomDistance = 2;
    private float maxZoomDistance = 3.5f;
    [SerializeField] private float currentZoomDistance = 5;

    private void Awake() => rotationPoint = Vector3.zero;    // MAYBE SHOULD BIND ROTATION POINT TO NEWLY INSTANTIETED OBJECT POSITION??

    public void XCameraRotation(float input)
    {
        float rotationAmount = input * rotationSpeed * Time.deltaTime;
        transform.RotateAround(rotationPoint, Vector3.right, rotationAmount);
    }
    //public void YCameraRotation(float input)
    //{
    //    float rotationAmount = -input * rotationSpeed * Time.deltaTime;
    //    gameObject.transform.RotateAround(rotationPoint, Vector3.up, rotationAmount);
    //}

    public void CameraZoom(float value)
    {
        //Способ 3 - работает корректно
        float distance = (rotationPoint - transform.position).magnitude;
        float distancePassed = zoomSpeed * Time.deltaTime*value;
        float t = distancePassed / distance;
        transform.position = Vector3.LerpUnclamped(transform.position, rotationPoint, t);

        //Способ 1 - не работает, меняет угол наклона камеры при перемещении
        //Vector3 direction = (rotationPoint - transform.position).nirmalized;
        //transform.Translate(direction * Time.deltaTime * zoomSpeed * value);

        //Способ 2 - не работает, меняет угол наклона камеры при перемещении
        //transform.Translate(transform.forward * Time.deltaTime * zoomSpeed * value);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        //horizontalInput = Input.GetAxisRaw("Horizontal");
        currentCameraAngleX = transform.rotation.eulerAngles.x;
        currentZoomDistance = (transform.position - rotationPoint).magnitude;

        if (ShouldMoveUp)
            XCameraRotation(verticalInput);
        if (ShouldMoveDown)
            XCameraRotation(verticalInput);
        //YCameraRotation(horizontalInput);


        //correct camera angle!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    }

    private void LateUpdate()
    {


        if (ShouldMoveCloser) CameraZoom(1);
        if (ShouldMoveFurther) CameraZoom(-1);


        transform.LookAt(rotationPoint);
    }

    private bool ShouldMoveUp => ((currentCameraAngleX < maxAngleX) || (currentCameraAngleX > (minAngleX - 10))) && verticalInput > 0;
    private bool ShouldMoveDown => ((currentCameraAngleX < (maxAngleX + 10)) || (currentCameraAngleX > minAngleX && currentCameraAngleX < 360)) && verticalInput < 0;

    private bool ShouldMoveCloser => currentZoomDistance > minZoomDistance && Input.GetKey(KeyCode.E);
    private bool ShouldMoveFurther => currentZoomDistance < maxZoomDistance && Input.GetKey(KeyCode.Q);

}
