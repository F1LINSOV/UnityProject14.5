using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Destructible))]
public class StoneHitpointsText : MonoBehaviour
{
    [SerializeField] private Text hitpointText;

    private Destructible destructible;

    private void Awake()
    {
        destructible = GetComponent<Destructible>();

        destructible.ChengeHitPoints.RemoveListener(OnChangeHitpoints);
    }
    private void OnChangeHitpoints()
    {
        int hitPoints = destructible.GetHitPoints();

        if (hitPoints >= 1000) 
            hitpointText.text = hitPoints / 1000 + "K";

        else
            hitpointText.text = hitPoints.ToString();
    }
}
