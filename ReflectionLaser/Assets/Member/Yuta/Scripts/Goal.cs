using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject GameManger = GameObject.FindGameObjectWithTag("GameManger");
        GameManger.GetComponent<Test_GameManger>().Player_Goal();
    }
}
