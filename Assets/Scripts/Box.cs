using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private GameObject pieces;
    public void TakeDamage()
    {
        GameObject currentpices = Instantiate(pieces);
        currentpices.transform.position = gameObject.transform.position;

        GiveImpulseToPieces(currentpices);
        Destroy(currentpices, 5);
        Destroy(gameObject);
    }

    private void GiveImpulseToPieces(GameObject currentpices)
    {
        foreach (Rigidbody2D piece in currentpices.GetComponentsInChildren<Rigidbody2D>())
        {
            Vector2 direcation = new Vector2(Random.Range(-5f, 5f), Random.Range(4f, 8f));
            piece.AddForce(direcation, ForceMode2D.Impulse);
        }
    }
}
