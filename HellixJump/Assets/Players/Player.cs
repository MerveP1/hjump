using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
   Rigidbody rb;
   public float bounceForce = 400f;
   
   public GameObject splitPrefab;

    public void Start()
    {
        rb = GetComponent<Rigidbody> ();
    }

    private void OnCollisionEnter(Collision other)
    {
        rb.velocity = new Vector3 (rb.velocity.x, bounceForce * Time.deltaTime, rb.velocity.z);

        GameObject newsplit = Instantiate(splitPrefab, new Vector3 (transform.position.x, other.transform.position.y + 0.2f, transform.position.z), transform.rotation);

                                                                                         // yere degdigi an leke cikart
        newsplit.transform.localScale = Vector3.one * Random.Range(0.8f, 1.2f); 

                                                                                         // yere leke degdiginde
        newsplit.transform.parent = other.transform;

                                                                                         // yere yeni leke cikart

        string materialName  = other.transform.GetComponent<MeshRenderer> ().material.name;

        Debug.Log(materialName);

        if(materialName == " Safe (Instance)") 
        { 
            Debug.Log("you are safe");
        }

        if (materialName == " UnSafe (Instance)")
        {
            GameManager.gameOver = true;
        }

        if (materialName == " LastRing (Instance)" && !GameManager.levelWin)
        {
            GameManager.levelWin = true;
        }


    }

}    
