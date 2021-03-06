﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[3]{1,2,3};
            int[] b = new int[3]{3,4,5};
            Console.WriteLine(FindMedianSortedArrays(a, b));
            Console.ReadKey();
        }

        #region 1-100
        #region 1
        /// <summary>
        /// #1 https://leetcode.com/problems/two-sum/#/description
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        static public int[] TwoSum(int[] nums, int target)
        {
            for (int a = 0; a < nums.Length; a++)
            {
                for (int b = a + 1; b < nums.Length; b++)
                {
                    if ((nums[a] + nums[b]) == target)
                    {
                        return new int[] { a, b };
                    }
                }
            }
            return new int[2];
        }
        #endregion

        #region 2
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        /// <summary>
        /// #2 https://leetcode.com/problems/add-two-numbers/#/description
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        static public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode answer = new ListNode((l1.val + l2.val) % 10);
            ListNode teman = new ListNode(0);
            answer.next = teman;
            int tem = 0;
            while (l1 != null || l2 != null)
            {
                if (l1 == null)
                {
                    tem = l2.val + tem;
                    l2 = l2.next;
                }
                else if (l2 == null)
                {
                    tem = l1.val + tem;
                    l1 = l1.next;
                }
                else
                {
                    tem = l1.val + l2.val + tem;
                    l1 = l1.next;
                    l2 = l2.next;
                }
                teman.val = tem % 10;
                tem = tem / 10;
                if (l1 != null || l2 != null || tem > 0)
                {
                    teman.next = new ListNode(1);
                    teman = teman.next;
                }
            }
            return answer.next;
        }
        #endregion

        #region 3
        /// <summary>
        /// #3 https://leetcode.com/problems/longest-substring-without-repeating-characters/#/description
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static public int LengthOfLongestSubstring(string s)
        {
            int max = 0;
            char[] chars = s.ToCharArray();
            List<char> ins = new List<char>();
            foreach (char c in chars)
            {
                if (ins.Contains(c))
                {
                    if (ins.Count > max)
                    {
                        max = ins.Count;
                    }
                    ins.RemoveRange(0, ins.IndexOf(c) + 1);
                    ins.Add(c);
                }
                else
                {
                    ins.Add(c);
                }
            }
            if (ins.Count > max)
            {
                max = ins.Count;
            }
            return max;
        }
        #endregion

        #region 4
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            double result = 0;
            int maxCount = nums1.Length + nums2.Length;
            bool isEven = (maxCount / 2 * 2 == maxCount);
            int cnt = maxCount/2;
            int n1 = 0;
            int n2 = 0;
            int f1 = 1;
            int f2 = 1;
            for (int i = 0; i <= cnt; i++)
            {
                if (n1 <= nums1.Length - 1 && n2 <= nums2.Length - 1)
                {
                    if (nums1[n1] < nums2[n2])
                    {
                        f1 = f2;
                        f2 = 1;
                        n1++;
                    }
                    else
                    {
                        f1 = f2;
                        f2 = 2;
                        n2++;
                    }
                }
                else if (n1 <= nums1.Length - 1)
                {
                    f1 = f2;
                    f2 = 1;
                    n1++;
                }
                else
                {
                    f1 = f2;
                    f2 = 2;
                    n2++;
                }
            }

            if (isEven)
            {
                if (f1 == 1 && f2 == 1)
                {
                    result = (nums1[n1 - 1] + nums1[n1 - 2]) / 2.0;
                }
                else if (f1 == 2 && f2 == 2)
                {
                    result = (nums2[n2 - 1] + nums2[n2 - 2]) / 2.0;
                }
                else
                {
                    result = (nums1[n1 - 1] + nums2[n2 - 1]) / 2.0;
                }
            }
            else
            {
                if (f2 == 1)
                {
                    result = nums1[n1-1];
                }
                else
                {
                    result = nums2[n2-1];
                }
            }
            return result;
        }
        #endregion
        #endregion
    }
}
