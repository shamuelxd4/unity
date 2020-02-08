using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Range(0f, 0.20f)]
    public float parallaxSpeed = 0.02f;
    public RawImage background;
    public RawImage platform;
    public GameObject uiIdle;


    public enum GameState {Idle, Playing};
    public GameState gameState = GameState.Idle;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    //metodo parallax
    void Update()
    {
        //comenzar el juego ya que esta en pausa a menos que lo iniciemos
        if( gameState == GameState.Idle && ( Input.GetKeyDown("up") || Input.GetMouseButtonDown(0))){
            gameState = GameState.Playing;
            uiIdle.SetActive(false);
        }
        //iniciando juego 
        else if(gameState == GameState.Playing){
               //llamando la funcion Parallax
               Parallax();
        }
    }
    //funcion Parallax
    void Parallax(){
        //movimiento del juego "deslizar"
            float finalSpeed = parallaxSpeed * Time.deltaTime;
            background.uvRect = new Rect(background.uvRect.x + finalSpeed, 0f, 1f, 1f);
            platform.uvRect = new Rect(platform.uvRect.x + finalSpeed * 4, 0f, 1f, 1f); 
    }

}
