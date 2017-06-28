using System.Collections.Generic;
using System.Linq;
using DragonsOfMugloar.enums;
using DragonsOfMugloar.DTOs;

namespace DragonsOfMugloar.Services.Strategy
{
    public class NormalWeatherStrategy : IWeatherStrategy
    {
        public DragonDto CreateDragon(DragonDto dragon, KnightDto knight)
        {
            var abilitiesOrderedList = DetermineStrongestKnightAbility(knight);

            var dragonAbilities = DefineDragonAbilities(abilitiesOrderedList);

            dragon = dragonAbilities;

            return dragon;

        }

        private List<KeyValuePair<KnightsAttributes, int>> DetermineStrongestKnightAbility(KnightDto knight)
        {
            var test = new Dictionary<KnightsAttributes, int>
            {
                {KnightsAttributes.Agility, knight.Agility},
                {KnightsAttributes.Armor, knight.Armor},
                {KnightsAttributes.Attack, knight.Attack},
                {KnightsAttributes.Endurance, knight.Endurance}
            };

            return test.OrderByDescending(x => x.Value).ToList();
        }

        private DragonDto DefineDragonAbilities(List<KeyValuePair<KnightsAttributes, int>> abilitiesList)
        {
            var dragon = new DragonDto();

            var dragonAttributes = new Dictionary<DragonsAttributes, int>
            {
                {(DragonsAttributes) abilitiesList[0].Key, abilitiesList[0].Value + 2},
                {(DragonsAttributes) abilitiesList[1].Key, abilitiesList[1].Value - 1},
                {(DragonsAttributes) abilitiesList[2].Key, abilitiesList[2].Value - 1},
                {(DragonsAttributes) abilitiesList[3].Key, abilitiesList[3].Value}
            };

            dragonAttributes.OrderBy(x => x.Key).ToList();

            dragon.WingStrength = dragonAttributes.FirstOrDefault(x => x.Key == DragonsAttributes.WingStrength).Value;
            dragon.ClawSharpness = dragonAttributes.FirstOrDefault(x => x.Key == DragonsAttributes.ClawSharpness).Value;
            dragon.ScaleThickness = dragonAttributes.FirstOrDefault(x => x.Key == DragonsAttributes.ScaleThickness).Value;
            dragon.FireBreath = dragonAttributes.FirstOrDefault(x => x.Key == DragonsAttributes.Firebreath).Value;

            return dragon;
        }
    }
}
