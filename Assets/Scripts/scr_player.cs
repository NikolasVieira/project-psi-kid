using UnityEngine;
using System.Collections;

public class scr_player : MonoBehaviour
{
    public bool isMoving; // Flag que indica se o jogador esta se movendo
    public float speed;
    public Vector2 direction;
    private Vector3 targetPos; // Espaco que o jogador vai ficar depois de andar

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetPos = transform.position + new Vector3(direction.x, direction.y, 0);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
}
