namespace Solution;

public class TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
{
    public int val = val;
    public TreeNode left = left;
    public TreeNode right = right;
}

public static class Solution
{
    public static TreeNode BuildTree(int?[] values)
    {
        if (values is null || values.Length == 0 || values[0] is null) return null;

        var root = new TreeNode((int)values[0]!);
        var queue = new Queue<TreeNode?>();

        var i = 1;
        queue.Enqueue(root);
        
        while (i < values.Length)
        {
            var current = queue.Dequeue();
            
            if (current is null) continue;

            if (i < values.Length)
            {
                var value = values[i++];
                current.left = value.HasValue ? new TreeNode(value.Value) : null;
                queue.Enqueue(current.left);
            }
            if (i < values.Length)
            {
                var value = values[i++];
                current.right = value.HasValue ? new TreeNode(value.Value) : null;
                queue.Enqueue(current.right);
            }
        }

        return root;
    }

    public static bool IsSameTree(TreeNode p, TreeNode q)
    {
        var pQueue = new Queue<TreeNode?>([p]);
        var qQueue = new Queue<TreeNode?>([q]);

        while (pQueue.Count > 0 && qQueue.Count > 0)
        {
            var pNode = pQueue.Dequeue();
            var qNode = qQueue.Dequeue();

            if (pNode is null && qNode is null) continue;

            if (pNode is null || qNode is null) return false;

            if (pNode.val != qNode.val) return false;

            static void AddNodeToQueue(TreeNode? node, Queue<TreeNode?> queue)
            {
                queue.Enqueue(node);
            }

            AddNodeToQueue(pNode.left, pQueue);
            AddNodeToQueue(qNode.left, qQueue);
            AddNodeToQueue(pNode.right, pQueue);
            AddNodeToQueue(qNode.right, qQueue);
        }

        return pQueue.Count == 0 && qQueue.Count == 0;
    }
}
