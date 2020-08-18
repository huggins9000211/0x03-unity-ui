using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{

    public int health;
    public float speed = 5;
    private int score;
    public Text scoreText;
    public Text healthText;
    public Text wLText;
    public Image wLBackround;
    public GameObject temp;
    

    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        score = 0;
        rigidbody = GetComponent<Rigidbody> ();
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Death()
    {
        if (health == 0)
        {
            temp.SetActive(true);
            wLBackround.color = Color.red;
            wLText.color = Color.white;
            wLText.text = "Game Over!";

            //Debug.Log($"Game Over!");
            StartCoroutine(LoadScene(3));
        }
    }

    void SetScoreText()
    {
        scoreText.text = $"Score: {score}";
    }

    void SetHealthText()
    {
        healthText.text = $"Health: {health}";
    }
    // Update is called once per frame
    void Update()
    {
        float Horiz = Input.GetAxis ("Horizontal");
        float Vert = Input.GetAxis ("Vertical");

        Vector3 move = new Vector3(Horiz, 0.0f, Vert);

        rigidbody.AddForce(move * speed);
        Death();

        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            score++;
            SetScoreText();
            //Debug.Log($"Score: {score}");
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Trap")
        {
            health--;
            SetHealthText();
            //Debug.Log($"Health: {health}");
        }
        else if (other.gameObject.tag == "Goal")
        {
            temp.SetActive(true);
            wLBackround.color = Color.green;
            wLText.color = Color.black;
            wLText.text = "You Win!";
            StartCoroutine(LoadScene(3));
            //Debug.Log($"You win!");
        }
    }
}
