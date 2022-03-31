using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Mindbox.Tests;

public class TreeeNodeTests
{
    [Fact]
    public void PreOrderTraversal()
    {
        var traversal = new TreeTraversal<char>();
        var nodes = traversal.Traverse(_tree).Select(x => x.Value).ToArray();
        var exptected = new char[] { 'a', 'b', 'd', 'e', 'f', 'c', 'g', 'i', 'j', 'h' };
        Assert.Equal(exptected, nodes);
    }

    [Fact]
    public void PostOrderTraversal()
    {
        var traversal = new TreeTraversal<char>();
        var nodes = traversal.Traverse(_tree, TraversalOrder.Post).Select(x => x.Value).ToArray();
        var exptected = new char[] { 'd', 'e', 'f', 'b', 'i', 'j', 'g', 'h', 'c', 'a' };
        Assert.Equal(exptected, nodes);
    }

    [Fact]
    public void InOrderTraversal()
    {
        var traversal = new TreeTraversal<char>();
        var nodes = traversal.Traverse(_tree, TraversalOrder.In).Select(x => x.Value).ToArray();
        var exptected = new char[] { 'd', 'b', 'e', 'f', 'a', 'i', 'g', 'j', 'c', 'h'};
        Assert.Equal(exptected, nodes);
    }

    [Fact]
    public void ShouldReturnRoot()
    {
        var tree = new TreeNode<char>('a');
        var traversal = new TreeTraversal<char>();
        Assert.Single(traversal.Traverse(tree));
    }

    private readonly TreeNode<char> _tree = new TreeNode<char>('a')
        {
            Children = new List<TreeNode<char>>
            {
                new TreeNode<char>('b')
                {
                    Children = new List<TreeNode<char>>
                    {
                        new TreeNode<char>('d'),
                        new TreeNode<char>('e'),
                        new TreeNode<char>('f')
                    }
                },
                new TreeNode<char>('c')
                {
                    Children = new List<TreeNode<char>>
                    {
                        new TreeNode<char>('g')
                        {
                            Children = new List<TreeNode<char>>
                            {
                                new TreeNode<char>('i'),
                                new TreeNode<char>('j')
                            }
                        },
                        new TreeNode<char>('h')
                    }
                }
            }
        };
}
