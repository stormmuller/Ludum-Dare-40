using UnityEngine;

public class CameraController : MonoBehaviour
{

    [Range(1, 100)]
    public float panSpeed;
    [Range(0, 1)]
    public float damping;

    [Header("Mouse Zoom")]
    public float zoomSpeed;
    public float minZoom;
    public float maxZoom;

    Transform camera;
    Vector3 target;

    void Start()
    {
        camera = Camera.main.transform;
        target = camera.position;
    }

    void Update()
    {
        bool isTop = Input.mousePosition.y >= Screen.height - 1 || Input.GetAxisRaw("Vertical") > 0f;
        bool isBottom = Input.mousePosition.y <= 0 || Input.GetAxisRaw("Vertical") < 0f;
        bool isRight = Input.mousePosition.x >= Screen.width - 1 || Input.GetAxisRaw("Horizontal") > 0f;
        bool isLeft = Input.mousePosition.x <= 0 || Input.GetAxisRaw("Horizontal") < 0f;
        
        PanVertical(isTop, isBottom);
        PanHorizontal(isLeft, isRight);

        Zoom();
        
        camera.position = Vector3.Lerp(camera.position, target, damping);
    }

    void Zoom()
    {
        float yZoom = target.y + Input.mouseScrollDelta.y * -zoomSpeed;
        float zZoom = target.z - Input.mouseScrollDelta.y * -zoomSpeed;

        if (yZoom < maxZoom && yZoom > minZoom)
        {
            target = new Vector3
               (
                   target.x,
                   yZoom,
                   zZoom
               );
        }
    }

    void PanVertical(bool isTop, bool isBottom)
    {
        float z = 0f;

        if (isTop)
        {
            z += panSpeed * Time.deltaTime;
        }
        else if (isBottom)
        {
            z -= panSpeed * Time.deltaTime;
        }

        target = new Vector3(target.x, target.y, z + target.z);
    }

    void PanHorizontal(bool isLeft, bool isRight)
    {
        float x = 0f;

        if (isLeft)
        {
            x -= panSpeed * Time.deltaTime;
        }
        else if (isRight)
        {
            x += panSpeed * Time.deltaTime;
        }
        
        target = new Vector3(x + target.x, target.y, target.z);
    }
}