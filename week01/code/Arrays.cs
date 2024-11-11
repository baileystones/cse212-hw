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
        //Create an array (multiples) to hold the multiples with a size of length
        //This should be using the data type of 'double'
        double[] multiples = new double[length];

        // Make a for loop to go through the array and put the data in (multiples of number)
        // For every index (i) in the loop, calculate the multiple
        //In your for loop, you want the number to be multiplied by (i + 1) and then stored in the array
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        //Return the array with the multiples data populated in it 
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
        //Amount is the number of positions to rotate to the right,
        //so use modulo to correctly wrap the numbers back around
        //if the amount is greater than the length of the list 
        amount = amount % data.Count;

        //Use GetRange so the list is split in two
        //Move the data so the elements that fit in the list without wrapping back around stay up front and the rest get cycled through to the second part
        //The first part has the remaining elements at the beginning
        List<int> secondPart = data.GetRange(data.Count - amount, amount);
        List<int> firstPart = data.GetRange(0, data.Count - amount);

        //Get rid of the data from the original list
        data.Clear();
        //Populate the list with the rotated data
        data.AddRange(secondPart);
        data.AddRange(firstPart);
    }
}
