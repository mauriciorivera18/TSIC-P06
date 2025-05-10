using UnityEngine;

public class Eventos : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToActivate; // Array of GameObjects to activate
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public void ActivaHumo()
   {
      objectsToActivate[0].SetActive(true); // Activate the first GameObject in the array
   }

   public void DesactivaHumo()
   {
      objectsToActivate[0].SetActive(false); // Deactivate the first GameObject in the array
   }
}
