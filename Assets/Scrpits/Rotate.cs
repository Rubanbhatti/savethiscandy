using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Transform star;

    void Update()
    {
        star.eulerAngles += new Vector3(0, 0, 50) * Time.deltaTime;
    }
}
