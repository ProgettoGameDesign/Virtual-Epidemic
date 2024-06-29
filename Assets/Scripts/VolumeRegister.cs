using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VolumeRegister : MonoBehaviour
{
    private PostProcessVolume _volume;

    private void Awake()
    {
        _volume = GetComponent<PostProcessVolume>();
        if (_volume != null)
        {
            PostProcessingManager.Instance.RegisterVolume(_volume);

            // Disattiva il volume se volumesDisabled è true
            if (PostProcessingManager.Instance.volumesDisabled)
            {
                _volume.enabled = false;
            }
        }
    }

    private void OnDestroy()
    {
        if (_volume != null)
        {
            PostProcessingManager.Instance.UnregisterVolume(_volume);
        }
    }
}
