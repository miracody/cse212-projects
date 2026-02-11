public static class Trees
{
    /// <summary>
    /// Given a sorted list (sorted_list), create a balanced BST.  
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree(); // Create an empty BST to start with 

        if (sortedNumbers.Length > 0)
        {
            InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        }

        return bst;
    }

    /// <summary>
    /// Recursively insert the middle element of the current range.
    /// </summary>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        if (first > last)
        {
            return;
        }

        int mid = (first + last) / 2;
        bst.Insert(sortedNumbers[mid]);

        InsertMiddle(sortedNumbers, first, mid - 1, bst);
        InsertMiddle(sortedNumbers, mid + 1, last, bst);
    }
}
