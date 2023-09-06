using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public Quaternion rot;

    public Vector3 CurrentEulerAngle;
    private float x, y, z;
    public float rotSpeed;

    public Transform TargetA, TargetB;

    float timeCount = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(90, 90, 90);
    }

    // Update is called once per frame
    void Update()
    {
        //RotationInputs();
        //QuaternionRotateTowards();
        //QuaternionSlerp();
        lookRotation();
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 28;

        GUI.Label(new Rect(10, 0, 0, 0),
            "Rotating on X" + x + "y" + y + "z" + z, style);
        GUI.Label(new Rect(10, 25, 0, 0), 
            "Current Euler Angles" + CurrentEulerAngle, style);
        GUI.Label(new Rect(10, 50, 0, 0), 
            "Game Object World Euler Angle" + transform.eulerAngles, style);

    }

    void RotationInputs()
    {
        if (Input.GetKeyDown(KeyCode.X)) { x = 1 - x; }
        if (Input.GetKeyDown(KeyCode.Y)) { y = 1 - y; }
        if (Input.GetKeyDown(KeyCode.Z)) { z = 1 - z; }

        CurrentEulerAngle += new Vector3(x, y, z) * Time.deltaTime * rotSpeed;
        rot.eulerAngles = CurrentEulerAngle;
        transform.rotation = rot;
    }

    void QuaternionRotateTowards()
    {
        var step = Time.time * rotSpeed;
        transform.rotation = Quaternion.RotateTowards(transform.rotation,TargetA.rotation,step);
    }

    void QuaternionSlerp()
    {
        transform.rotation = Quaternion.Slerp(TargetA.rotation, TargetB.rotation, timeCount);
        timeCount = timeCount + Time.deltaTime;
    }

    void lookRotation()
    {
        Vector3 relativeRes = TargetA.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativeRes, Vector3.up);
        transform.rotation = rotation;
    }
}
