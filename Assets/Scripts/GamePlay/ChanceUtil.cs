using System.Collections.Generic;
using System.Linq;

public class ChanceUtil
{
    private ChanceUtil() 
    { 
    }

    public static T TakeRandomByChance<T>(List<T> variants, float intelligence) where T: IWithProbability
    {
        var orderedVariants = variants.OrderBy(variant => variant.Probability()).ToList();
        System.Random random = new();
        double diceRoll = random.NextDouble() - intelligence * 0.01;

        double cumulative = 0.0;

        for (int i = 0; i < orderedVariants.Count; i++)
        {
            cumulative += orderedVariants[i].Probability();

            if (diceRoll <= cumulative)
            {
                return orderedVariants[i];
            }
        }
        return default;
    }
}
