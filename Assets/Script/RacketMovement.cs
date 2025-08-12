// PaddleMovement.cs
using UnityEngine;

public class RacketMovement : MonoBehaviour
{
    public float speed = 10f;
    public float minY, maxY;
    

    void Update()
    {
        if(UserInputManager.Instance == null) return;
        float move = UserInputManager.Instance.verticalInput * speed * Time.deltaTime;
        Vector3 newPos = transform.position + new Vector3(0, move, 0);
        newPos.y = Mathf.Clamp(newPos.y, minY, maxY);
        transform.position = newPos;
    }
}