using System.Linq;

public class BuildBuildingEventRaiser : EventRaiser
{
    public Building building;
    public MaterialsListVariable originalBuildingMaterialsContainer;
    public IntVariable currentMetal;
    public IntVariable currentElectricity;
    public BuildingVariable buildingVariable;

    public override void RaiseEvent()
    {
        if (!HasEnoughResources)
        {
            print("Not enough ru");
            return;
            // Show messgae
        }

        buildingVariable.CurrentValue = building;
        originalBuildingMaterialsContainer.CurrentItems = building.originalBuildingMaterials.ToList();

        base.RaiseEvent();
    }

    private bool HasEnoughResources
    {
        get
        {
            return currentMetal.CurrentValue >= building.metalCost.CurrentValue &&
                currentElectricity.CurrentValue >= building.electricityCost.CurrentValue;
        }
    }
}
