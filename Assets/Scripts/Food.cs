using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "SnakeHead(Clone)")
        {
            collision.gameObject.GetComponent<SnakeController>().IncreaseBodyLength();
            Destroy(this.gameObject);
        }
    }
}
