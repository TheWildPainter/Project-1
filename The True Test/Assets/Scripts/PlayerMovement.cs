using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 60;
    public float jumpHeight = 5;
    public float xp = 0;
    public float xpForNextLevel = 10;
    public int level = 0;
    public float currentMoveSpeed;
    public float currentRotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        SetXpForNextLevel();
        SetCurrentMoveSpeed();
        SetCurrentRotationSpeed();
    }

    void SetXpForNextLevel()
    {
        xpForNextLevel = (10f + (level * level * 0.1f));
        Debug.Log("xpForNextLevel " + xpForNextLevel);
    }

    void SetCurrentMoveSpeed()
    {
        currentMoveSpeed = this.moveSpeed + (this.moveSpeed * 0.1f * level);
        Debug.Log("currentMoveSpeed =" + currentMoveSpeed);
    }

    void SetCurrentRotationSpeed()
    {
        currentRotationSpeed = this.rotationSpeed + (this.rotationSpeed * 0.1f * level);
        Debug.Log("currentRotationSpeed =" + currentRotationSpeed);
    }

    void LevelUp()
    {
        xp = 0f;
        level++;
        Debug.Log("level" + level);
        SetXpForNextLevel();
        SetCurrentMoveSpeed();
        SetCurrentRotationSpeed();
    }

    public void GainXP(int xpToGain)
    {
        xp += xpToGain;
        Debug.Log("Gained " + xpToGain + " XP, Current XP = " + xp + ", XP needed to reach next Level = " + xpForNextLevel);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) == true) { GainXP(1); }

        if (xp >= xpForNextLevel)
        {
            LevelUp();
        }

        Debug.Log(Time.deltaTime);
        if (Input.GetKey(KeyCode.UpArrow) == true)
        { this.transform.position += this.transform.forward * Time.deltaTime * this.moveSpeed; }

        if (Input.GetKey(KeyCode.DownArrow) == true)
        { this.transform.position -= this.transform.forward * Time.deltaTime * this.moveSpeed; }

        if (Input.GetKey(KeyCode.LeftArrow) == true)
        { this.transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime); }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        { this.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime); }

        if (Input.GetKeyDown(KeyCode.Space) == true && Mathf.Abs(this.GetComponent<Rigidbody>().velocity.y) < 0.01 )
        { this.GetComponent<Rigidbody>().velocity += Vector3.up * this.jumpHeight; }

        if ((transform.rotation.eulerAngles.x < -180)) ;

        if ((transform.rotation.eulerAngles.x > 180)) ;

        if ((transform.rotation.eulerAngles.z < -360)) ;

        if ((transform.rotation.eulerAngles.z > 360)) ;

        float currentLook = transform.rotation.eulerAngles.y;

        transform.rotation = Quaternion.identity;

        transform.Rotate(0, currentLook, 0);
    }
}
