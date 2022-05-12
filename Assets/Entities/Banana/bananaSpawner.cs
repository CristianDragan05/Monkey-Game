using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bananaSpawner : MonoBehaviour


{
    public float width = 1;
    public float height = 1;
    public float speed = 0.1f;

    private float xmax;
    private float xmin;

    public bool movingRight = true;

    public GameObject bananaPrefab;

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));
        xmax = rightBoundary.x;
        xmin = leftBoundary.x;
    }

    // Update is called once per frame
    void Update()
    {

        if (Random.value<0.003f)
        {
            Instantiate(bananaPrefab, transform.position, Quaternion.identity);
        }

        if (movingRight)
        {
            transform.position += new Vector3(speed, 0);
        }

        else

        {
            transform.position += new Vector3(-speed, 0);
        }

        float rightEdgeOfFormation = transform.position.x + (0.03f * width);
        float leftEdgeOfFormation = transform.position.x - (0.03f * width);


        if (rightEdgeOfFormation > xmax)
        {
            movingRight = false;
        }

        if (leftEdgeOfFormation < xmin)
        {
            movingRight = true;
        }
    }
}
