using UnityEngine;
using System.Collections;
using SgLib;

public class EnemyGoalController : MonoBehaviour {

    private GameManager gameManager;
    private SpriteRenderer spriteRenderer;
	private bool isChecked;
	private int ScoreMultiplier = 1;
	public UIManager uimanager;
	
    // Use this for initialization
	void Start() {
		uimanager = FindObjectOfType<UIManager>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        gameObject.SetActive(false);
        spriteRenderer = GetComponent<SpriteRenderer>();
       // transform.position += (Random.value >= 0.5f) ? (new Vector3(0.2f, 0)) : (new Vector3(-0.2f, 0));
        gameObject.SetActive(true);
		uimanager.multiliertxt.transform.GetComponent<Animator>().SetBool("Mult",false);
		uimanager.multiliertxt.text = "1X";
		//  this.transform.GetComponent<TrailRenderer>().enabled = false; 
    }
	void Update(){
		
		if (ScoreManager.Instance.Score >= 3){
			ScoreMultiplier = 2;
			uimanager.multiliertxt.text = "2X";
			uimanager.multiliertxt.transform.GetComponent<Animator>().SetBool("Mult",true);
		}
			
		if (ScoreManager.Instance.Score >= 10){
			ScoreMultiplier = 4;	
			uimanager.multiliertxt.text = "4X";
		}

			//	uimanager.multiliertxt.transform.GetComponent<Animator>().SetBool("Mult",true);
		if (ScoreManager.Instance.Score >= 25){
			ScoreMultiplier = 6;
			uimanager.multiliertxt.text = "6X";
		}
	
			//uimanager.multiliertxt.transform.GetComponent<Animator>().SetBool("Mult",true);
		
		if (ScoreManager.Instance.Score >= 50){
			ScoreMultiplier = 8;
			uimanager.multiliertxt.text = "8X";
		}

			//uimanager.multiliertxt.transform.GetComponent<Animator>().SetBool("Mult",true);
		
		
		if (ScoreManager.Instance.Score >= 200){
			ScoreMultiplier = 10;
			uimanager.multiliertxt.text = "10X";
		}
	
	}
		//	uimanager.multiliertxt.transform.GetComponent<Animator>().SetBool("Mult",true);
	


    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Dead") && !gameManager.gameOver) {
            SoundManager.Instance.PlaySound(SoundManager.Instance.eploring);
            gameManager.CheckGameOver(gameObject);
            Exploring();
        }
    }

    //void OnTriggerEnter2D(Collider2D other) {
    //    if (other.CompareTag("Gold") && !gameManager.gameOver) {
    //        SoundManager.Instance.PlaySound(SoundManager.Instance.hitGold);
    //        ScoreManager.Instance.AddScore(1);
    //        gameManager.CheckAndUpdateValue();

    //        ParticleSystem particle = Instantiate(gameManager.hitGold, other.transform.position, Quaternion.identity) as ParticleSystem;
    //        var main = particle.main;
    //        main.startColor = other.gameObject.GetComponent<SpriteRenderer>().color;
    //        particle.Play();
    //        Destroy(particle.gameObject, 1f);
    //        Destroy(other.gameObject);
    //        gameManager.CreateTarget();
    //    }
    //}
    
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("EnemyGoal") && !gameManager.gameOver) {
			SoundManager.Instance.PlaySound(SoundManager.Instance.hitGold);
			ScoreManager.Instance.AddScore(1*ScoreMultiplier);
			gameManager.CheckAndUpdateValue();

			ParticleSystem particle = Instantiate(gameManager.hitGold, other.transform.position, Quaternion.identity) as ParticleSystem;
			var main = particle.main;
			main.startColor = other.gameObject.GetComponent<SpriteRenderer>().color;
			particle.Play();
			Destroy(particle.gameObject, 1f);
			//	Destroy(other.gameObject);
			//	gameManager.CreateAnotherBall();
		}
	}

    /// <summary>
    /// Handle when player die
    /// </summary>
    public void Exploring() {
        ParticleSystem particle = Instantiate(gameManager.die, transform.position, Quaternion.identity) as ParticleSystem;
        var main = particle.main;
        main.startColor = spriteRenderer.color;
        particle.Play();
        Destroy(particle.gameObject, 1f);
        Destroy(gameObject);
    }

}
