using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA_BB_AB
{
    internal class Solution
    {
        //  AA  |   BB  |   AB  |   RESULT
        //----------------------------------
        //   0  |    0  |    0  |   Empty?
        //   0  |    0  |    n  |   AB1-AB2-AB3...ABn
        //   0  |    n  |    0  |   BB1
        //   0  |    n  |    m  |   BB1-AB1-AB2-AB3...ABm
        //   n  |    0  |    0  |   AA1
        //   n  |    0  |    m  |   AB1-AB2-AB3...ABm-AA1
        //   n  |    m  |    0  |   if n>m then AA1-BB1-AA2-BB2-AA3-BB3...AAm-BBm-AAm+1
        //                          else if n<m then BB1-AA1-BB2-AA2-BB3-AA3...BBn-AAn-BBn+1
        //                          else if n==m then BB1-AA1-BB2-AA2-BB3-AA3...BBn-AAn
        //   n  |    m  |    l  |   if n>m then AB1-AB2-AB3...ABl-AA1-BB1-AA2-BB2-AA3-BB3...AAm-BBm-AAm+1
        //                          else if n<m then BB1-AA1-BB2-AA2-BB3-AA3...BBn-AAn-BBn+1-AB1-AB2-AB3...ABl
        //                          else if n==m then AB1-AB2-AB3...ABl-AA1-BB1-AA2-BB2-AA3-BB3...AAn-BBn

        public string solution(int AA, int AB, int BB)
        {
            var result = string.Empty;

            var ABresult = string.Empty;
            for (int i = 0; i < AB; i++)
            {
                ABresult += "AB";
            }

            var AABBResult = string.Empty;
            for (int i = 0; i < Math.Min(AA, BB); i++)
            {
                AABBResult += "AABB";
            }

            if (AA > BB)
            {
                result = $"{ABresult}{AABBResult}AA";
            }
            else if (AA < BB)
            {
                result = $"BB{AABBResult}{ABresult}";
            }
            else if (AA == BB)
            {
                result = $"{ABresult}{AABBResult}";
            }

            return result;
        }
    }
}
