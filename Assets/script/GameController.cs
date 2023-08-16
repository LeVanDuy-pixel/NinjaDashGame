using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    int score = 0, speedOfWall;
    bool isOver, canSpawn=true, canSpawnWall = true;
    GameObject w;
    Player pl;
    UIManagement m_ui;
    float time;
    public void SpawnWall(){
        float randYpos = Random.Range(-2.5f,-0.3f);
        Vector2 spawnPos = new Vector2(5,randYpos);
        if(wall){
            w = Instantiate(wall, spawnPos,Quaternion.identity);
        }
    }
    public void destroyWall(){
        Destroy(w);
        canSpawn = true;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
        speedOfWall = 3;
        pl = FindObjectOfType<Player>();
        m_ui = FindObjectOfType<UIManagement>();
        m_ui.SetScoretext("Banished Talishman: " +score);
        m_ui.ShowGameGuidePanel(true);
    }

    // Update is called once per frame
    void Update()
    {
         time += Time.deltaTime;
        
        if(isOver==true){
            pl.Stop();
            m_ui.ShowGameOverPanel(true);
            return;
        }
        if(score !=0 && score % 2==0 && score < 10 && canSpawnWall){
            speedOfWall++;
            canSpawnWall = false;
        }
        if(canSpawn && pl.check() && time>=2.5f){
            m_ui.ShowGameGuidePanel(false);
            SpawnWall();
            canSpawnWall = true;
            canSpawn = false;
        }
        
    }
    public void setScore(int value){
        this.score = value;
    }
    public int getScore(){
        return score;
    }
    public void ScoreIncrement(){
        score++;
        m_ui.SetScoretext("Banished Talishman: "+ score);
    }
    public void setGameOver(bool value){
        this.isOver = value;
    }
    public bool IsGameOver(){
        return isOver;
    }
    public void Replay(){
        SceneManager.LoadScene("NinjaDash");
    }
    public void BackToMenu(){
        SceneManager.LoadScene("Menu");
    }
    public int WallSpeed(){
        return speedOfWall;
    }
}
