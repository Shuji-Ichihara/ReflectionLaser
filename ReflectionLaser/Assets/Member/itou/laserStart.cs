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
        Vector3 aa = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 0.02f);
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 at = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 0.01f);
            this.transform.position = aa;
            Instantiate(LaserBall, at, Quaternion.identity);
        }
    }
}
