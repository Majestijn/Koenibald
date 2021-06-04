using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverButton : MonoBehaviour
{
	public PlayerController thePlayer;
	public Button First;
    
    void update(){
		if(thePlayer.gameOver){
        First.gameObject.SetActive(true);
    }}
	void start(){
	}
	
	
}
