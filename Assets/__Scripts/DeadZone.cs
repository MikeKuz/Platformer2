using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    //public LevelManager levelManager;
    public MenuManager menuManager;
    public GameObject losePanel;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //SceneManager.LoadScene(0);
            menuManager.ShowLosePanel();
        }
        else 
            Destroy(collision.gameObject);
    }

}
