using UnityEngine;
using System.Collections;

namespace CGT
{
    [ExecuteInEditMode]
    public class InspectObject : MonoBehaviour
    {
        [Tooltip("Horizontal speed")]
        [SerializeField] private float horizontalSpeed = 5.0F;

        [Tooltip("Vertical speed")]
        [SerializeField] private float verticalSpeed = 5.0F;

        [Tooltip("Zoom speed")]
        public float zoomSpeed = 1;

        [Tooltip("Max and min FOV")]
        public float minFOV = 20;
        public float maxFOV = 75;

        [HideInInspector]
        public Vector3 initialPosition;
        [SerializeField] ChiudiApriInventario chiudiApriInventario;
        [SerializeField] GameObject pulsanteChiudi;

        private Vector3 pivotOffset = new Vector3(0, 0, 0); // Piccolo offset per il pivot

        void Start()
        {
            InspectManager.instance.Ping();
        }

        private void OnEnable()
        {
            if (Application.isPlaying)
                initialPosition = new Vector3(90, 180, 0); // Ruotato di 90 gradi sull'asse X
                transform.localEulerAngles = initialPosition;

        }

        void Update()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                initialPosition = transform.localEulerAngles;
                if (InspectManager.instance.autoCullingMask)
                    SetLayerRecursively(InspectManager.instance.GetLayerInspect());
            }
#endif 

            float horizontalRotation = horizontalSpeed * Input.GetAxis("Mouse X");
            float verticalRotation = verticalSpeed * Input.GetAxis("Mouse Y");

            if (Mathf.Abs(horizontalRotation) > Mathf.Abs(verticalRotation))
                verticalRotation = 0;
            else
                horizontalRotation = 0;

            Vector3 pivotPoint = transform.position + pivotOffset;

            if (Input.GetMouseButton(0))
            {
                if (horizontalRotation != 0)
                    transform.RotateAround(pivotPoint, Vector3.up, -horizontalRotation);
                else
                    transform.RotateAround(pivotPoint, Vector3.right, verticalRotation);
            }

            else if (Input.GetMouseButtonDown(1))
            {
                transform.localEulerAngles = initialPosition;
                InspectManager.instance.StopInspecting();
                chiudiApriInventario.SwitchActive();
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                if (InspectManager.instance.inspectCamera.fieldOfView < maxFOV)
                    InspectManager.instance.inspectCamera.fieldOfView += zoomSpeed;
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                if (InspectManager.instance.inspectCamera.fieldOfView > minFOV)
                    InspectManager.instance.inspectCamera.fieldOfView -= zoomSpeed;
            }
        }

        public void SetLayerRecursively(int layerNumber)
        {
            gameObject.layer = layerNumber;
            foreach (Transform trans in gameObject.GetComponentsInChildren<Transform>(true))
            {
                trans.gameObject.layer = layerNumber;
            }
        }

        public void ChiudiIspezionamentoPulsante()
        {
            transform.localEulerAngles = initialPosition;
            pulsanteChiudi.SetActive(false);
            InspectManager.instance.StopInspecting();
            chiudiApriInventario.SwitchActive();
        }
    }
}
