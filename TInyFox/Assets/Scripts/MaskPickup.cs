// using UnityEngine;

// public class MaskPickup : MonoBehaviour
// {
//     void OnTriggerEnter(Collider other)
//     {
//         if (!other.CompareTag("Player")) return;

//         Mask mask = other.GetComponent<Mask>();
//         if (mask != null)
//         {
//             mask.UnlockMask();
//         }

//         Destroy(gameObject);
//     }
// }
