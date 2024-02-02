using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserStart : MonoBehaviour
{
    [SerializeField]
    private GameObject LaserBall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(LaserBall, this.transform.position, Quaternion.identity);
        }
    }
}
