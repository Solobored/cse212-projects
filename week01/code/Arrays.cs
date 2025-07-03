public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Create a new array of doubles with the specified length
        // Step 2: Use a loop to iterate from 1 to length (inclusive)
        // Step 3: For each iteration i, calculate the multiple by multiplying number * i
        // Step 4: Store the calculated multiple in the array at index (i-1)
        // Step 5: Return the completed array

        double[] multiples = new double[length];
        
        for (int i = 1; i <= length; i++)
        {
            multiples[i - 1] = number * i;
        }
        
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Handle edge case - if amount equals data.Count, no rotation is needed
        // Step 2: Calculate the split point - elements from this index to the end will move to the front
        // Step 3: Extract the elements that need to move to the front (last 'amount' elements)
        // Step 4: Extract the elements that will stay but move to the back (first part of the list)
        // Step 5: Clear the original list
        // Step 6: Add the elements that go to the front first
        // Step 7: Add the remaining elements to the back

        // If amount equals the list count, no rotation is needed
        if (amount == data.Count)
        {
            return;
        }

        // Calculate the split point - elements from this index onward move to the front
        int splitIndex = data.Count - amount;
        
        // Get the elements that will move to the front (last 'amount' elements)
        List<int> elementsToFront = data.GetRange(splitIndex, amount);
        
        // Get the elements that will move to the back (first part of the list)
        List<int> elementsToBack = data.GetRange(0, splitIndex);
        
        // Clear the original list
        data.Clear();
        
        // Add elements to front first
        data.AddRange(elementsToFront);
        
        // Add remaining elements to back
        data.AddRange(elementsToBack);
    }
}
