using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class carMove : MonoBehaviour
{
    public Rigidbody rb;
    public Transform car;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    bool driving = false;
    public TrailRenderer bLeft;
    public TrailRenderer bRight;
    public TrailRenderer fLeft;
    public TrailRenderer fRight;
    Vector3 place;
    float drifting_points;
    bool turning_1 = false;
    bool turning_2 = false;
    bool drifting = false;
    bool cantDrive;
    float CountDown = 3.5f;
    public TextMeshProUGUI count;
    float timer = 120;
    public bool Paused = true;
    public TextMeshProUGUI timerText;
    public GameObject EndScreen;
    public GameObject continueButton;
    public GameObject pauseButton;
    float points;
    bool challengeDrift = true;
    bool pointsAdded = true;
    float airtime;
    float reachSpeed = 90;
    public TextMeshProUGUI pointsOnMenu;
    public TextMeshProUGUI pointsAll;
    bool challenge360 = true;
    float rotationx;
    bool is360;
    bool is90;
    bool is180;
    bool is270;
    float highScore;
    public TextMeshProUGUI bestScore;

    void FixedUpdate()
    {
        bestScore.text = PlayerPrefs.GetFloat("highscore", points).ToString("0");
        if (PlayerPrefs.GetFloat("highscore") < points)
        {
            PlayerPrefs.SetFloat("highscore", points);
        }

        pointsOnMenu.text = points.ToString("0");
        pointsAll.text = points.ToString("0");
        if (rb.velocity.magnitude > reachSpeed)
        {
            points += 90;
            reachSpeed = reachSpeed + 90;
        }
        if (cantDrive)
        {
            airtime += 1 * Time.deltaTime;
        }
        if (!Paused)
        {
            timer -= 1 * Time.deltaTime;
        }
        timerText.text = timer.ToString("0");
        drifting_points += 1 * Time.deltaTime;
        MyInput();
        if (Input.GetKey("w") && !cantDrive && !Paused)
        {
            moveDirection = transform.forward * verticalInput;
            rb.AddForce(moveDirection.normalized * 0.6f, ForceMode.VelocityChange);
            driving = true;
        }
        else if (!driving)
        { driving = false; }
        if (Input.GetKey("s") && !cantDrive && !Paused)
        {

            moveDirection = transform.forward * verticalInput;
            rb.AddForce(moveDirection.normalized * 0.6f, ForceMode.VelocityChange);
            driving = true;
        }
        else if (!driving)
        { driving = false; }
        if (Input.GetKey("d") && driving && !Paused)
        {
            pointsAdded = false;
            car.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + 1, transform.eulerAngles.z);
            turning_1 = true;
        }
        else { turning_1 = false; }
        if (Input.GetKey("a") && driving && !Paused)
        {
            pointsAdded = false;
            car.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y - 1, transform.eulerAngles.z);
            turning_2 = true;
        }
        else { turning_2 = false; }
        if (turning_1 && !drifting || turning_2 && !drifting)
        {
            drifting_points = -2;
            drifting = true;
        }
        if (!turning_1 && !turning_2)
        {
            drifting = false;
        }
        if (turning_1 && drifting_points > 0 || turning_2 && drifting_points > 0)
        {
            bLeft.emitting = true;
            bRight.emitting = true;
            fLeft.emitting = true;
            fRight.emitting = true;
        }
        else
        {
            bLeft.emitting = false;
            bRight.emitting = false;
            fLeft.emitting = false;
            fRight.emitting = false;
        }
        if (CountDown > -1)
        {
            CountDown -= 1 * Time.deltaTime;
        }
        if (CountDown > 0)
        {
            count.text = CountDown.ToString("0");
        }
        else if (CountDown  > -1)
        {
            Destroy(count);
            Paused = false;
            pauseButton.SetActive(true);
        }
        if (timer <= 0)
        {
            Paused = true;
            EndScreen.SetActive(true);
        }
        if (challengeDrift && drifting_points > 0 && !turning_1 && !turning_2 && !pointsAdded && !Paused)
        {
            points += drifting_points * 10;
            pointsAdded = true;
        }
        if (challenge360)
        {
            challengeDrift = true;
            challenge360 = false;
            rotationx = transform.eulerAngles.y;
            is360 = false;
        }
        if (transform.eulerAngles.y <= rotationx + 90 && transform.eulerAngles.y >= rotationx + 80 && !is360)
        {
            is90 = true;
        }
        if (transform.eulerAngles.y >= rotationx + 170 && transform.eulerAngles.y <= rotationx + 179 && !is360)
        {
            is180 = true;
        }
        if (transform.eulerAngles.y >= rotationx + 270 && transform.eulerAngles.y <= rotationx + 280 && !is360)
        {
            is270 = true;
        }
        if (transform.eulerAngles.y < rotationx + 5 && transform.eulerAngles.y > rotationx && is180)
        {
            is360 = true;
        }
        if (is90 && is180 && is270 && is360)
        {
            points += 360;
            challenge360 = true;
            is90 = false;
            is180 = false;
            is270 = false;
        }
        if (transform.eulerAngles.x > 180 && transform.eulerAngles.x < 184 && cantDrive)
        {
            transform.rotation = Quaternion.Euler(0,transform.eulerAngles.y,transform.eulerAngles.z);
        }
        if (transform.eulerAngles.z > 180 && transform.eulerAngles.z < 184 && cantDrive)
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x,transform.eulerAngles.y,0);
        }
    }
    void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
    void OnCollisionExit(Collision col)
    {
        if (col.collider.tag == "ground")
        {
            cantDrive = true;
            airtime = 0;
            driving = false;
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "ground")
        {
            cantDrive = false;
            points += airtime * 20;
        }
    }
    public void GamePause()
    {
        if (!Paused)
        {
            Paused = true;
            if (timer > 0)
            {
                pointsAll.enabled = false;
                EndScreen.SetActive(true);
                pauseButton.SetActive(false);
                continueButton.SetActive(true);
            }
        }
        else
        {
            Paused = false;
            if (timer > 0)
            {
                pointsAll.enabled = true;
                EndScreen.SetActive(false);
                pauseButton.SetActive(true);
                continueButton.SetActive(false);
            }
        }
    }
    public void Settings()
    {
        if (!Paused)
        {
            Paused = true;
        }
        else if (Paused)
        {
            Paused = false;
        }
    }
}