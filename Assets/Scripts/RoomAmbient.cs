using UnityEngine;

/// <summary>
/// Klasa przechowująca informację o stanie ambientu pokoju.
/// </summary>
public class RoomAmbient : MonoBehaviour
{
    public bool ambientActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ambientActivated = true;
            UpdateAllDoors();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ambientActivated = false;
            UpdateAllDoors();
        }
    }

    // Nowa metoda: Wymusza na drzwiach ponowne sprawdzenie dźwięku
    private void UpdateAllDoors()
    {
        // Znajduje wszystkie drzwi na scenie
        Doors[] allDoors = FindObjectsByType<Doors>(FindObjectsSortMode.None);
        
        foreach (Doors door in allDoors)
        {
            // Wywołuje nową publiczną metodę w skrypcie Doors
            door.RoomsSnap();
        }
    }
}