namespace Mindbox;

public class TreeNode<T>
{
    public TreeNode(T value)
    {
        Value = value;
    }

    public T Value { get; }
    public IEnumerable<TreeNode<T>>? Children { get; init; }
}

public enum TraversalOrder
{
    In,
    Pre,
    Post
}
public interface ITreeTraversal<T>
{
    IEnumerable<TreeNode<T>> Traverse(TreeNode<T> node, TraversalOrder order = TraversalOrder.In);
}

public class TreeTraversal<T> : ITreeTraversal<T>
{
    public IEnumerable<TreeNode<T>> Traverse(TreeNode<T> node, TraversalOrder order = TraversalOrder.Pre)
        => order switch
        {
            TraversalOrder.Pre => PreOrder(node),
            TraversalOrder.Post => PostOrder(node),
            TraversalOrder.In => InOrder(node),
            _ => throw new NotImplementedException()
        };

    private IEnumerable<TreeNode<T>> InOrder(TreeNode<T> node)
    {
        var leftChild = node.Children?.FirstOrDefault();
        if (leftChild is not null)
        {
            foreach (var item in InOrder(leftChild)) yield return item;
        }
        yield return node;
        var restChildren = node.Children?.Skip(1) ?? Enumerable.Empty<TreeNode<T>>();
        foreach (var item in restChildren.SelectMany(x => InOrder(x))) yield return item;
    }

    private IEnumerable<TreeNode<T>> PostOrder(TreeNode<T> node)
    {
        if (node.Children is not null)
        {
            var nodes = node.Children.SelectMany(x => PostOrder(x));
            foreach (var item in nodes) yield return item;
        }
        yield return node;
    }

    private IEnumerable<TreeNode<T>> PreOrder(TreeNode<T> node)
    {
        yield return node;
        if (node.Children is null) yield break;
        var nodes = node.Children.SelectMany(x => PreOrder(x));
        foreach (var item in nodes) yield return item;
    }
}
