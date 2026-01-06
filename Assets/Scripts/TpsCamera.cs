using UnityEngine;
using Unity.Cinemachine;


public class TpsCamera : MonoBehaviour
{
    
    public AxisState xAxis, yAxis; // Cinemachine axis
    public Transform camFollowPos; 


    CinemachineCamera camera;
    public float normalFov = 60f;
    public float aimFov = 40f;
    public float zoomSpeed = 10f;

    void Start()
    {
        
        camera = GetComponentInChildren<CinemachineCamera>();
    }
    private void Update()
    {
        xAxis.Update(Time.deltaTime);
        yAxis.Update(Time.deltaTime);

        Debug.Log("bastı "+Input.GetMouseButton(1));

        if (camera != null)
        {
            float targetFov = Input.GetMouseButton(1) ? aimFov : normalFov;
            // Lens ayarına erişerek FOV değiştir:
            camera.Lens.FieldOfView = Mathf.Lerp( camera.Lens.FieldOfView,  targetFov, Time.deltaTime * zoomSpeed );
        }
    }

    private void LateUpdate()
    {
        // Yatay dönüş (sağ-sol) objeyi Y ekseninde döndürür
        transform.eulerAngles = new Vector3(0f, xAxis.Value, 0f);

        // Dikey dönüş (yukarı-aşağı) follow pozisyonunu X ekseninde döndürür
        camFollowPos.localEulerAngles = new Vector3(yAxis.Value, 0f, 0f);
    }
}

