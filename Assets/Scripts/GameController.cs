using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject snakePrefab;
    public GameObject foodPrefab;
    public GameObject foodPrefab2;
    public GameObject foodPrefab3;
    public GameObject foodPrefab4;
    public GameObject foodPrefab5;
    public GameObject foodPrefab6;
    public GameObject foodPrefab7;
    public GameObject foodPrefab8;
    public GameObject foodPrefab9;
    public GameObject foodPrefab10;

   


    //just snake things
    public Snake head;
    public Snake tail;
    public int NorthEastSouthWest;
    public Vector2 nextPosition;

    //growth of snake
    public int maxSize;
    public int currentSize;

    //range of spawn 
    public int xBound;
    public int yBound;

    //range of spawn badfood
    public int xxBound;
    public int yyBound;

    //goodfood
    public GameObject currentFood;

    //bad food
    public GameObject currentFood2;
    public GameObject badFoodPrefab;
    public GameObject badFoodPrefab2;
    public GameObject badFoodPrefab3;
    public GameObject badFoodPrefab4;
    public GameObject badFoodPrefab5;
    public GameObject badFoodPrefab6;
    public GameObject badFoodPrefab7;
    public GameObject badFoodPrefab8;
    public GameObject badFoodPrefab9;
    public GameObject badFoodPrefab10;


    public int score;

    public Text scoreText;

    public Text questionText;


    public float deltaTimer;


    GameObject GameOver;
    bool gameOver;
    bool death;

    
    GameObject Winner;
    bool winner;

    public bool paused;


    //Audio
    public AudioClip[] audioClip;
    public AudioSource input;
    public AudioManager instanceMusic;

        
    void OnEnable()
    {
        Snake.hit += hit;
    }
    void OnDisable()
    {
        Snake.hit -= hit;
    }

    int foodCount = -1;

    string[] wyrazy = new string[10];
    
    

   // Use this for initialization
	void Start () 

    {
        input = GetComponent<AudioSource>();
        gameOver = false;
        death = false;
        winner = false;
        paused = false;
        

        GameOver = GameObject.Find("GameOverPanel");
        Winner = GameObject.Find("winpanel");
        

        InvokeRepeating("TimerInvoke", 0.5f, deltaTimer);
        FoodFunction();
        instanceMusic = GameObject.FindObjectOfType<AudioManager>();
        
                       

        wyrazy[0] = "K _ _ tałt";
        wyrazy[1] = "Sk _ wka";
        wyrazy[2] = "P _ _ enica";
        wyrazy[3] = "Dru _ ";
        wyrazy[4] = "Wkró _ ce";
        wyrazy[5] = "Spok _ j";
        wyrazy[6] = "Rze _ ucha";
        wyrazy[7] = "B _ j";
        wyrazy[8] = "Tch _ rz";
        wyrazy[9] = "Mo _ e";
	}
	 
	// Update is called once per frame
	void Update () 
    {

        if(Input.GetKeyDown(KeyCode.Space))
            {
                Pause();
             }

   
        if (death)
        {
            gameOver = true;
        }
        else if (!death)
        {
            gameOver = false;
        }
        if (gameOver)
        {
            
            GameOver.SetActive(true);
            Time.timeScale = 0;
            
        } 
                
        else if (!gameOver)
        {
            
            GameOver.SetActive(false);
                Time.timeScale = 1;
        }


        if (score == 10)
        {
            winner = true;
        }
        if (winner)
        {
            
            Winner.SetActive(true);
            Time.timeScale = 0;
        }
        else if (!winner)
        {
            
            Winner.SetActive(false);
            Time.timeScale = 1;
        }
                      
        CompChangeDirections();

        if (score == 0)
        {
            questionText.text = wyrazy[0];
         }
        if (score == 1)
        {
            questionText.text = wyrazy[1];
        }
        if (score == 2)
        {
            questionText.text = wyrazy[2];
        }
        if (score == 3)
        {
            questionText.text = wyrazy[3];
        }
        if (score == 4)
        {
            questionText.text = wyrazy[4];
        }
        if (score == 5)
        {
            questionText.text = wyrazy[5];
        }
        if (score == 6)
        {
            questionText.text = wyrazy[6];
        }
        if (score == 7)
        {
            questionText.text = wyrazy[7];
        }
        if (score == 8)
        {
            questionText.text = wyrazy[8];
        }
        if (score == 9)
        {
            questionText.text = wyrazy[9];
        }


	}

    public void PauseSound()
    {
        input.Pause();
    }
       public  void UnPauseSound()
    {
        input.UnPause();
    }


   public  void PlaySound(int clip)
    {
        input.clip = audioClip[clip];
        input.Play();
    }

    

    void TimerInvoke()
    {
        Movement();
         StartCoroutine(CheckVisible());

        if (currentSize >= maxSize)
        {
            TailFunction();
        }
        else
        {
            currentSize++;
        }

       

    }


    void Movement()
    {
        GameObject temp;
        nextPosition = head.transform.position;

        switch (NorthEastSouthWest)
        {
                //up North
            case 0:
                nextPosition = new Vector2(nextPosition.x, nextPosition.y + 1);
                break;
                //right East
            case 1:
                nextPosition = new Vector2(nextPosition.x + 1, nextPosition.y);
                break;

                //down South
            case 2:
                nextPosition = new Vector2(nextPosition.x, nextPosition.y - 1);
                break;
                //left West
            case 3:
                nextPosition = new Vector2(nextPosition.x - 1 , nextPosition.y);
                break;
        }
        //instance snake
        temp = (GameObject)Instantiate(snakePrefab, nextPosition, transform.rotation);
        head.Setnext(temp.GetComponent<Snake>());
        head = temp.GetComponent<Snake>();
        
        

       

        return;

    }
        //can't go backwards cuz we can colide with our snake parts xD
    void CompChangeDirections()
    {       //top
        if (NorthEastSouthWest != 2 && Input.GetKeyDown(KeyCode.W))
        {
            NorthEastSouthWest = 0;
        }
        //right
        if (NorthEastSouthWest != 3 && Input.GetKeyDown(KeyCode.D))
        {
            NorthEastSouthWest = 1;
        }
        //bottom
        if (NorthEastSouthWest != 0 && Input.GetKeyDown(KeyCode.S))
        {
            NorthEastSouthWest = 2;
        }
        //left
        if (NorthEastSouthWest != 1 && Input.GetKeyDown(KeyCode.A))
        {
            NorthEastSouthWest = 3;
        }
    }
    void TailFunction()
    {
        Snake tempSnake = tail;
        tail = tail.GetNext();
        tempSnake.RemoveTail();
    }

    
    void FoodFunction()
    {
        int xPosition = Random.Range(-xBound, xBound);
        int yPosition = Random.Range(-yBound, yBound);

        int xxPosition = Random.Range(-xxBound, xxBound);
        int yyPosition = Random.Range(-yyBound, yyBound);
       
        //instance food
        foodCount++;

              
        
        if (foodCount == 0) 
        { 
        //good
        currentFood = (GameObject)Instantiate(foodPrefab, new Vector2(xPosition, yPosition), transform.rotation);
        StartCoroutine(CheckRender(currentFood));

        //bad
        currentFood2 = (GameObject)Instantiate(badFoodPrefab, new Vector2(xxPosition, yyPosition), transform.rotation);
        StartCoroutine(CheckRender(currentFood2));


        } if (foodCount == 1)
        {
            //good
            currentFood = (GameObject)Instantiate(foodPrefab2,new Vector2(xPosition, yPosition), transform.rotation);
            StartCoroutine(CheckRender(currentFood));

            //bad
            currentFood2 = (GameObject)Instantiate(badFoodPrefab2, new Vector2(xxPosition, yyPosition), transform.rotation);
            StartCoroutine(CheckRender(currentFood2));

        }

        if (foodCount == 2)
        {
            //good
            currentFood = (GameObject)Instantiate(foodPrefab3, new Vector2(xPosition, yPosition), transform.rotation);
            StartCoroutine(CheckRender(currentFood));
            //bad
            currentFood2 = (GameObject)Instantiate(badFoodPrefab3, new Vector2(xxPosition, yyPosition), transform.rotation);
            StartCoroutine(CheckRender(currentFood2));
        }

        if (foodCount == 3)
        {
            //good
            currentFood = (GameObject)Instantiate(foodPrefab4, new Vector2(xPosition, yPosition), transform.rotation);
            StartCoroutine(CheckRender(currentFood));
            //bad
            currentFood2 = (GameObject)Instantiate(badFoodPrefab4, new Vector2(xxPosition, yyPosition), transform.rotation);
            StartCoroutine(CheckRender(currentFood2));

        } if (foodCount == 4)
        {
            //good
            currentFood = (GameObject)Instantiate(foodPrefab5, new Vector2(xPosition, yPosition), transform.rotation);
            StartCoroutine(CheckRender(currentFood));
            //bad
            currentFood2 = (GameObject)Instantiate(badFoodPrefab5, new Vector2(xxPosition, yyPosition), transform.rotation);
            StartCoroutine(CheckRender(currentFood2));

        }

        if (foodCount == 5)
        {
            //good
            currentFood = (GameObject)Instantiate(foodPrefab6, new Vector2(xPosition, yPosition), transform.rotation);
            StartCoroutine(CheckRender(currentFood));
            //bad
            currentFood2 = (GameObject)Instantiate(badFoodPrefab6, new Vector2(xxPosition, yyPosition), transform.rotation);
            StartCoroutine(CheckRender(currentFood2));
        }

        if (foodCount == 6)
        {
            //good
            currentFood = (GameObject)Instantiate(foodPrefab7, new Vector2(xPosition, yPosition), transform.rotation);
            StartCoroutine(CheckRender(currentFood));
            //bad
            currentFood2 = (GameObject)Instantiate(badFoodPrefab7, new Vector2(xxPosition, yyPosition), transform.rotation);
            StartCoroutine(CheckRender(currentFood2));


        }
        
        if (foodCount == 7)
        {
            //good
            currentFood = (GameObject)Instantiate(foodPrefab8, new Vector2(xPosition, yPosition), transform.rotation);
            StartCoroutine(CheckRender(currentFood));
            //bad
            currentFood2 = (GameObject)Instantiate(badFoodPrefab8, new Vector2(xxPosition, yyPosition), transform.rotation);
            StartCoroutine(CheckRender(currentFood2));

        }

        if (foodCount == 8)
        {
            //good
            currentFood = (GameObject)Instantiate(foodPrefab9, new Vector2(xPosition, yPosition), transform.rotation);
            StartCoroutine(CheckRender(currentFood));
            //bad
            currentFood2 = (GameObject)Instantiate(badFoodPrefab9, new Vector2(xxPosition, yyPosition), transform.rotation);
            StartCoroutine(CheckRender(currentFood2));
        }

        if (foodCount == 9)
        {
            //good
            currentFood = (GameObject)Instantiate(foodPrefab10, new Vector2(xPosition, yPosition), transform.rotation);
            StartCoroutine(CheckRender(currentFood));
            //bad
            currentFood2 = (GameObject)Instantiate(badFoodPrefab10, new Vector2(xxPosition, yyPosition), transform.rotation);
            StartCoroutine(CheckRender(currentFood2));
        }

    }

    private void StartCoroutine(IEnumerable enumerable)
    {
        return;
    }

   

    //checkin if food rendered
    IEnumerable CheckRender(GameObject IN)
    {
        yield return new WaitForEndOfFrame();
        if (IN.GetComponent<Renderer>().isVisible == false)
        {
            if (IN.tag == "Food")
            {
                Destroy(IN);
                FoodFunction();
                            
               
            }
            
                                              
        }
    }
           

    void hit(string WhatWasSent)
    {
        if (WhatWasSent == "Food")
        {
            if (deltaTimer >= 0.1f)
            {
                deltaTimer -= 0.05f;
                CancelInvoke("TimerInvoke");
                InvokeRepeating("TimerInvoke", 0, deltaTimer);
                
            }

            //destory badfood
            Destroy(GameObject.FindGameObjectWithTag("BadFood"));
            //make another one 
            FoodFunction();
            PlaySound(Random.Range(1,5));          
            maxSize++;
            score++;
            //display score
            scoreText.text = score.ToString();
                                                                     
            //save highscore                     
            int temp = PlayerPrefs.GetInt("HighScore");
                                                              
                                                                                  
            if (score > temp)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }


        }
        //gameover
        if (WhatWasSent == "Snake")
        {
            PlaySound(5);
            death = true;
            CancelInvoke("TimerInvoke");
            //Exit();
        }

        if (WhatWasSent == "BadFood")
        {
            PlaySound(0);
            death = true;         
            CancelInvoke("TimerInvoke");
            //Exit();
        }

        if (WhatWasSent == "Bound")
        {
            PlaySound(5);
            death = true;
            CancelInvoke("TimerInvoke");
            //Exit();
        }
    }

    



    public void Pause()
    {
        
        paused = !paused;
        if (paused)
        {
            Time.timeScale = 0;
            CancelInvoke("TimerInvoke");
        }
        else if (!paused)
        {
            Time.timeScale = 1;
            InvokeRepeating("TimerInvoke", 0, deltaTimer);
        }
    }
  

    public void Exit()
    {
        SceneManager.LoadScene(0);
        instanceMusic.inputz.Play();
    }

    public void Restart()
    {
        SceneManager.LoadScene(6);
    }

    //wraps
    void wrap()
    {
        if (NorthEastSouthWest == 0)
        {
            head.transform.position = new Vector2(head.transform.position.x, -(head.transform.position.y - 1));
        }
        if (NorthEastSouthWest == 1)
        {
            head.transform.position = new Vector2(-(head.transform.position.x - 1), head.transform.position.y);
        }
        if (NorthEastSouthWest == 2)
        {
            head.transform.position = new Vector2(head.transform.position.x, -(head.transform.position.y + 1));
        }
        if (NorthEastSouthWest == 3)
        {
            head.transform.position = new Vector2(-(head.transform.position.x + 1), head.transform.position.y);
        }
    }

    IEnumerator CheckVisible()
    {
        yield return new WaitForEndOfFrame();
        if (!head.GetComponent<Renderer>().isVisible)
        {
            wrap();
        }
    }

   

    


   
    

}

