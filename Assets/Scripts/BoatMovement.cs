using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoatMovement : MonoBehaviour
{
    public int Points = 0;
    public ParticleSystem Laser;
    public GameObject TargetPointLaser;
    public GameObject DialUi;
    public GameObject Back;
    public AudioClip LaserSound;
    public AudioClip TrashSoak;
    public AudioClip FishSoak;
    private AudioSource audsc;
    private AudioSource NewAudio;
    private bool once = true;
    private bool UfoOk = false;
    private Vector3 scaleVec = new Vector3( 0.1f, 0.1f, 0.1f );
    private Vector3 MoveVec = new Vector3(0.0f, 0.2f, 0.0f);
    private Vector3 MoveUpUfo = new Vector3(0.0f, 2.5f, 0.0f);
    public GameObject TxtPoints;
    public GameObject GameOverMenu;
    public GameObject Gmsc;
    public Sprite Ufo;
    public BoxCollider2D bxc;
    private void Start()
    {
        audsc = Gmsc.GetComponent<AudioSource>();
        NewAudio = Back.GetComponent<AudioSource>();
    }

    void Update()
    {
        TxtPoints.GetComponent<TextMeshProUGUI>().SetText(Points.ToString());

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (UfoOk == false)
            {
                gameObject.transform.position += new Vector3(-0.04f, 0.0f, 0.0f);
            }
            else
            {
                gameObject.transform.position += new Vector3(-0.07f, 0.0f, 0.0f);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (UfoOk == false)
            {
                gameObject.transform.position += new Vector3(0.04f, 0.0f, 0.0f);
            }
            else
            {
                gameObject.transform.position += new Vector3(0.07f, 0.0f, 0.0f);
            }
            
        }
        if (Points < 0)
        {
            LoseOver();
        }
        if (Points > 50 && UfoOk == false)
        {
            UfoIncoming();
            UfoOk = true;
        }
    }

    private void LoseOver()
    {
        Gmsc.SetActive(false);
        this.gameObject.SetActive(false);
        GameOverMenu.SetActive(true);
    }
    private void UfoIncoming()
    {
        DialUi.SetActive(true);
        Gmsc.GetComponent<GameManagerSc>().TimerBound = 2f;
        Gmsc.GetComponent<GameManagerSc>().TrashesNum = 8;
        gameObject.GetComponent<SpriteRenderer>().sprite = Ufo;
        iTween.MoveBy(this.gameObject, iTween.Hash("amount", MoveUpUfo, "easetype", iTween.EaseType.linear, "time", 1f));
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        bxc.enabled = !bxc.enabled;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trash") 
        {

            if (Input.GetKey(KeyCode.Space) && once)
            {
                if (UfoOk)
                {
                    Laser.transform.position = new Vector3(TargetPointLaser.transform.position.x,-3.92f,0.0f); 
                    
                    //Laser.gameObject.SetActive(true);
                    Laser.Play();
                    NewAudio.Play();
                }
                //scaleVec
                iTween.MoveBy(collision.gameObject, iTween.Hash("amount", MoveVec, "easetype", iTween.EaseType.linear, "time", 0.2f));
                iTween.ScaleBy(collision.gameObject, iTween.Hash("amount", scaleVec, "easetype", iTween.EaseType.linear, "time", 0.2f));
                StartCoroutine(Exma(collision.gameObject));
                once = false;
                audsc.clip = TrashSoak;
                audsc.Play();
                Points += 5;
            }       
        }

        else if (collision.gameObject.tag == "Fish")
        {
            if (Input.GetKey(KeyCode.Space) && once)
            {
                if (UfoOk)
                {

                    Laser.transform.position = new Vector3(TargetPointLaser.transform.position.x, -3.92f, 0.0f);
                    //Laser.gameObject.SetActive(true);
                    Laser.Play();
                    NewAudio.Play();
                }
                iTween.MoveBy(collision.gameObject, iTween.Hash("amount", MoveVec, "easetype", iTween.EaseType.linear, "time", 0.2f));
                iTween.ScaleBy(collision.gameObject, iTween.Hash("amount", scaleVec, "easetype", iTween.EaseType.linear, "time", 0.2f));
                StartCoroutine(Exma(collision.gameObject));
                once = false;
                audsc.clip = FishSoak;
                audsc.Play();
                if (UfoOk)
                {
                    Points -= 100;
                }
                else
                {
                    Points -= 15;
                }
                
            }
           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        once = true;
    }

    IEnumerator Exma(GameObject collision)
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(collision.gameObject);
    }


}
