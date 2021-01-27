using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool canMove;

    public GameObject[] tiles;
    public float tileDetectionRange;
    Transform moveToTile;

    public float speed;
    void Start()
    {
        tiles = GameObject.FindGameObjectsWithTag("Tile");
    }

    public void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        foreach (GameObject tile in tiles)
        {
            if (canMove == true)
            {
                if (Vector3.Distance(gameObject.transform.position, tile.transform.position) <= tileDetectionRange)
                {
                    tile.GetComponent<Renderer>().material.color = Color.green;
                }
            }
        }
    }

    private void OnMouseDown()
    {
        canMove = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, tileDetectionRange);
    }
}
