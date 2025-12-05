using Unity.VisualScripting;
using UnityEngine;

public class StandardPlatform : MonoBehaviour
{
    private float startX;
    private float startY;

    private float end_posX;
    private float end_posY;

    private int moveDirX = 1;
    private int moveDirY = 1;

    public float move_speed = 1;

    public float moveDisX = 0;
    public float moveDisY = 0;

    private int prev_dirX;
    private int prev_dirY;

    private void Start()
    {
        startX = this.transform.position.x;
        startY = this.transform.position.y;
        end_posX = startX - moveDisX;
        end_posY = startY + moveDisY;
        prev_dirX = -1*moveDirX;
        prev_dirY = -1*moveDirY;
        
    }

    private void Update()
    {
        if (this.tag == "PlatformMoving")
        {
            if (moveDisX > 0)
            {

                this.transform.Translate(Vector2.left * moveDirX * move_speed * Time.deltaTime);
                if (this.transform.position.x <= end_posX && end_posX < 0 && moveDirX == 1)
                {
                    Debug.Log("1");
                    prev_dirX = moveDirX;
                    moveDirX *= -1;
                }
                else if (this.transform.position.x <= end_posX && end_posX >= 0 && moveDirX == 1)
                {
                    Debug.Log("2");
                    prev_dirX = moveDirX;
                    moveDirX *= -1;
                }
                else if (startX - this.transform.position.x <= 0 && moveDirX == -1)
                {
                    Debug.Log("3");
                    prev_dirX = moveDirX;
                    moveDirX *= -1;
                }
                
            }
            if (moveDisY > 0)
            {

                this.transform.Translate(Vector2.up * moveDirY * move_speed * Time.deltaTime);
                if (this.transform.position.y >= end_posY && end_posY < 0 && moveDirY == 1)
                {
                    Debug.Log("1");
                    prev_dirY = moveDirY;
                    moveDirY *= -1;
                }
                else if (this.transform.position.y >= end_posY && end_posY >= 0 && moveDirY == 1)
                {
                    Debug.Log("2.1");
                    prev_dirY = moveDirY;
                    moveDirY *= -1;
                }
                else if (this.transform.position.y - startY <= 0 && moveDirY == -1)
                {
                    Debug.Log("3");
                    prev_dirY = moveDirY;
                    moveDirY *= -1;
                }

            }
        }
    }
}

