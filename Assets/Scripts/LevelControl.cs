using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
   [SerializeField] private string newLevel;
   
    void OnTriggerEnter2d(Collider2D other){
       if(other.CompareTag("Player")){
           SceneManager.LoadScene(newLevel);
       }
    }
}