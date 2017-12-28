using UnityEngine;

public class BuildingPlacer : MonoBehaviour
{
    public LayerVariable layerMask;
    public Material ghostMaterial;
    public MaterialsListVariable originalMaterials;
    public BoolVariable isPlacing;
    public BuildingVariable buildingToPlace;
    public IntVariable totalElectricity;
    public IntVariable totalMetal;
    public GameEvent metalChangedEvent;
    public GameEvent electricityChangedEvent;

    GameObject ghostBuilding;

    public void StartPlacingBuilding()
    {
        isPlacing.CurrentValue = true;

        this.ghostBuilding = Instantiate(buildingToPlace.CurrentValue.buildingPrefab);

        var renderer = ghostBuilding.GetComponent<Renderer>();
        var materials = renderer.materials;

        for (int i = 0; i < materials.Length; i++)
        {
            materials[i] = ghostMaterial;
        }

        renderer.materials = materials;
    }

    private void FixedUpdate()
    {
        if (isPlacing.CurrentValue && ghostBuilding != null)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f, layerMask.CurrentValue))
            {
                MoveGhost(ghostBuilding, hit.point);
                PlaceBuilding(ghostBuilding, buildingToPlace.CurrentValue);
            }
        }
    }

    private void PlaceBuilding(GameObject ghostBuilding, Building building)
    {
        if (Input.GetMouseButtonDown(0))
        {
            var renderer = ghostBuilding.GetComponent<Renderer>();
            var materials = renderer.materials;

            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = originalMaterials.CurrentItems[i];
            }

            renderer.materials = materials;

            this.totalElectricity.CurrentValue -= building.electricityCost.CurrentValue;
            this.totalMetal.CurrentValue -= building.metalCost.CurrentValue;
            metalChangedEvent.Raise();
            electricityChangedEvent.Raise();

            isPlacing.CurrentValue = false;
        }
    }

    private void MoveGhost(GameObject ghostBuilding, Vector3 posistion)
    {
        ghostBuilding.transform.position = posistion;
    }
}
