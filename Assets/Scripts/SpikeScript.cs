using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeScript : MonoBehaviour
{

    [SerializeField] GameObject player;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        
    }
}
