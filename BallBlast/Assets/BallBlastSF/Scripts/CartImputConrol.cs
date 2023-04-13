using UnityEngine;

public class CartImputConrol : MonoBehaviour
{
    [SerializeField] private Cart cart;
    [SerializeField] private Turret turret;

    private void Update()
    {
        cart.SetMovementTarget (Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (Input.GetMouseButton(0) == true)
        {
            turret.Fire();
        }
    }
}
