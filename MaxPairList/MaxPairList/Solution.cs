using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography;

//Number
namespace MaxPairList
{

    class DiffNode
    {
        public int Index { get; set; }
        public int Value { get; set; }
        public int Diff { get; set; }
        public DiffNode(int index, int value, int diff)
        {
            this.Index = index;
            this.Value = value;
            this.Diff = diff;
            this.Diffs = new List<DiffNode>();
        }
        public List<DiffNode> Diffs { get; set; }
    }

    class Solution
    {
        public int solution(int[] A)
        {
            var result = 0;
            var sortedA = A.Order().ToArray();
            var root = new DiffNode(0, sortedA[0], -1);
            FillDiffs(sortedA, root);

            var lists = GetDiffLists(root);

            //PrintList(lists);
            result = lists.Max(l => l.Count());
            return result;
        }

        private void PrintList(List<List<DiffNode>> lists)
        {
            foreach (var l in lists)
            {
                PrintArray(l.Select(item => item.Value).ToArray());
            }
        }

        private void FillDiffs(int[] A, DiffNode diffNode)
        {
            for (int i = diffNode.Index + 1; i < A.Length; i++)
            {
                var diff = A[i] - A[diffNode.Index];
                var nextDiffNode = new DiffNode(i, A[i], diff);
                diffNode.Diffs.Add(nextDiffNode);
                FillDiffs(A, nextDiffNode);
            }
        }

        private List<List<DiffNode>> GetDiffLists(DiffNode root)
        {
            var result = new List<List<DiffNode>>();
            foreach (var diffNode in root.Diffs)
            {
                var currentList = new List<DiffNode>();
                currentList.Add(root);
                currentList.Add(diffNode);
                SearchDiffs(diffNode, currentList);
                result.Add(currentList);
                result.AddRange(GetDiffLists(diffNode));
            }
            return result;
        }

        private void SearchDiffs(DiffNode diffNode, List<DiffNode> currentList)
        {
            var dn = diffNode.Diffs.FirstOrDefault(dn => dn.Diff == diffNode.Diff);
            if (dn != null)
            {
                currentList.Add(dn);
                SearchDiffs(dn, currentList);
            }
        }

        private void PrintArray(int[] A)
        {
            var result = $"[{string.Join(",", A)}]";
            Console.WriteLine(result);
        }

    }
}

