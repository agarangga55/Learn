using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    private void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnMouseOver()
    {
        Debug.Log("Mouse Hovering");
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Destroyed");
            Destroy(this.gameObject);
        }
    }
}
