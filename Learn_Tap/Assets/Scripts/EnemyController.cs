using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int speed;

    public Transform myTransform;

    public PlayerController Pcontroller;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        EndPoint();
    }

    private void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnMouseOver()
    {
        //Debug.Log("Mouse Hovering");
        if (Input.GetMouseButton(0))
        {
            if (gameObject.tag == "Enemy")
            {
                Debug.Log("Enemy Destroyed");
                Pcontroller.AddScore();
            }
            if (gameObject.tag == "NPC")
            {
                Debug.Log("NPC Destroyed, You Lose");
                Pcontroller.InstantLose();
            }
            //Debug.Log("Destroyed");
            Destroy(this.gameObject);
        }
    }

    private void EndPoint()
    {
        if (myTransform.position.x >= 9)
        {
            if (this.gameObject.tag == "Enemy")
            {
                Debug.Log("Enemy reached the point");
                Pcontroller.ReduceHealth();
                Debug.Log("Player Health =" + Pcontroller.playerHealth);
            }
            else
            {
                Debug.Log("NPC reached the point");
                Pcontroller.AddScore();
            }
            Destroy(gameObject);
        }
    }

    public void SetDependencies(PlayerController playerController)
    {
        Pcontroller = playerController;
    }
}
