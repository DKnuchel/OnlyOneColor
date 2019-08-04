using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineScript : MonoBehaviour
{

    [SerializeField] string nextLevelName;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //nextLevelName = "level1";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player)
        SceneManager.LoadScene(nextLevelName, LoadSceneMode.Single);
    }
}
