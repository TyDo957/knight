using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{
    [Range(1,1)] // thuộc tính phạm vi
    [SerializeField] private float airDeducValue = 1f;
    [Range(20, 30)]
    [SerializeField] private float airMax = 20f;
    [Range(20 , 30)]
    [SerializeField] private float timeMax = 20f;
    [Range(-2 , 2)]
    [SerializeField] private float restarLvtime = 2f; // bắt đầu lại màn chơi

    public static GamePlay instance;
    private GameObject player;
    private float airvalue, timeValue;

    [SerializeField] private Text winText, loseText;
    [SerializeField] private Canvas gameoverCavas;
    [SerializeField] private Slider airSlider, timeSlider;
    [SerializeField] private bool gameRunning;

    
    private void Awake()
    {
        this.CheckAwake();
    }
    private void Start()
    {
        this.CheckStart();
    }
    private void Update()
    {
        this.CheckUpdate();
        this.ReduceAir();
        this.ReduceTime();
        
    }
    private void CheckAwake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    private void CheckStart()
    {
        timeValue = timeMax;
        timeSlider.maxValue = timeValue;
        timeSlider.minValue = 0f;
        timeSlider.value = timeValue;

        airvalue = airMax;
        airSlider.maxValue = airvalue;
        airSlider.minValue = 0f;
        airSlider.value = airvalue;

        gameRunning = true;
                                                                                                                                                                                                                                                                                                                                                                                                               
        player = GameObject.FindWithTag(TagManager.PLAYER_TAG);

    }
    private void CheckUpdate()
    {
        if (!gameRunning)
        {
            return;
        }
    }
    private void ReduceTime()
    {
        timeValue -= Time.deltaTime;
        timeSlider.value = timeValue;

        if (timeValue <= 0f)
        {
            gameRunning = false;
            Gameover(false);
        }
    }
    private void ReduceAir()
    {
        airvalue -= airDeducValue * Time.deltaTime;
        airSlider.value = airvalue;

        if (airvalue <= 0f)
        {
            gameRunning = false;
            Gameover(false);

        }
    }
    public void IncreaseAir(float air)  // tăng thêm thời gian
    {
        airvalue += air;

        if (airvalue > airMax)
        {
            airvalue = airMax;
        }
    }
    public void IncreaseTime(float time) // tăng thêm thời gian
    {
        timeValue += time;

        if (timeValue > timeMax)
        {
            timeValue = timeMax;
        }
    }
    public void Gameover(bool win)
    {
        Destroy(player);
        gameoverCavas.enabled = true;
        gameRunning = false;

        if (win)
        {
            winText.gameObject.SetActive(true);
        }
        else
        {
            loseText.gameObject.SetActive(true);
        }
        Invoke("RestarLevel", restarLvtime);

    }
    public void RestarLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene
           (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

}

    