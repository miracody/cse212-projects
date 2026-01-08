public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
   public static double[] MultiplesOf(double startingNumber, int count) 
   {
         // Plan for MultiplesOf function:
        // 1. Receive two inputs: starting number and how many multiples to generate.
        // 2. Create a new array with a length equal to the number of multiples.
        // 3. Use a loop that runs from 0 up to (count - 1).
        // 4. For each loop index i, calculate the multiple as startingNumber * (i + 1).
        // 5. Store this value in the array at position i.
        // 6. After the loop finishes, return the array containing all multiples.


        double[] result = new double[count];
        for (int i = 0; i < count; i++)
        {
            result[i] = startingNumber * (i + 1);
        }
        return result;
   } 

        // Plan for RotateListRight function:
        // 1. Receive a list of data and an integer amount to rotate to the right.
        // 2. Normalize the amount by using modulo (%) with the list size, so we don’t rotate more than needed.
        // 3. Find the split point: index = data.Count - amount.
        // 4. Use GetRange to slice the list into two parts:
        //    - tail = last 'amount' elements
        //    - head = the first (data.Count - amount) elements
        // 5. Create a new list by adding tail first, then head.
        // 6. Return the new rotated list.

    public static List<int> RotateListRight(List<int> data, int amount)
{
    if (data == null || data.Count == 0)
    {
        return new List<int>(); // return empty list safely
    }

    // Normalize rotation (handle negatives too)
    amount = ((amount % data.Count) + data.Count) % data.Count;

    if (amount == 0)
    {
        return new List<int>(data); // no rotation needed
    }

    int split = data.Count - amount;

    List<int> tail = data.GetRange(split, amount);
    List<int> head = data.GetRange(0, split);

    List<int> rotated = new List<int>(data.Count);
    rotated.AddRange(tail);
    rotated.AddRange(head);

    return rotated;
 }

}
