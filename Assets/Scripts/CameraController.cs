using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool canMove = true;

    public float panSpeed = 30f;
    public float panBorder = 20f;
    public float scrollSpeed = 10f;

    public float minY = 10f;
    public float maxY = 80f;

    void Update()
    {
        if (GameManager._gameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canMove = !canMove;
        }

        if (!canMove) { return; }

        // Forward
        if (Input.GetKey(KeyCode.Z) || Input.mousePosition.y >= Screen.height-panBorder)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        // Backward
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= 0 + panBorder)
        {
            transform.Translate(-Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        // Left
        if (Input.GetKey(KeyCode.Q) || Input.mousePosition.x <= 0 + panBorder)
        {
            transform.Translate(-Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        // Right
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorder)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        //Zoom
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;

        /*        if (scroll > 0)
                {
                    transform.Translate(Vector3.forward * scrollSpeed * Time.deltaTime, Space.Self);
                }

                if (scroll < 0)
                {
                    transform.Translate(-Vector3.forward * scrollSpeed * Time.deltaTime, Space.Self);
                }*/
    }
}
