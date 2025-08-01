public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // Problem 1: Insert Unique Values Only
        // Check if value already exists - if so, don't insert (no duplicates)
        if (value == Data)
        {
            return; // Value already exists, don't insert duplicate
        }
        else if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else // value > Data
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // Problem 2: Contains
        // Base case: if current node matches the value
        if (value == Data)
        {
            return true;
        }
        // Recursive case: search left subtree if value is smaller
        else if (value < Data)
        {
            return Left != null && Left.Contains(value);
        }
        // Recursive case: search right subtree if value is larger
        else // value > Data
        {
            return Right != null && Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // Problem 4: Tree Height
        // Base case: if this is a leaf node (no children), height is 1
        if (Left is null && Right is null)
        {
            return 1;
        }
        
        // Get height of left and right subtrees
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        
        // Height is 1 plus the maximum height of either subtree
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
