using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu]
    public class InspectableItemSO : ItemSO, IInspectAction
    {
        public string ActionName => "Inspect";

        [field: SerializeField]

        public AudioClip actionSFX { get; private set; }

        public bool PerformAction()
        {
            Debug.Log($"PerformAction da Inspect");
            //Codice per viewer 3D
            return true;
        }

    }
}