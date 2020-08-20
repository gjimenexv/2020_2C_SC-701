using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;
using Solution.DO.Interfaces;
using Solution.DAL.EF;
using Solution.DAL;

namespace Solution.BS
{
    public class Authors : ICRUD<data.Authors>
    {
        private SolutionDBContext _solutionDBContext = null;
        public Authors(SolutionDBContext solutionDBContext)
        {
            _solutionDBContext = solutionDBContext;
        }
        public void Delete(data.Authors t)
        {
            new Solution.DAL.Authors(_solutionDBContext).Delete(t);
        }

        public IEnumerable<data.Authors> GetAll()
        {
            return new Solution.DAL.Authors(_solutionDBContext).GetAll();
        }

        public data.Authors GetOneById(int id)
        {
            return new Solution.DAL.Authors(_solutionDBContext).GetOneById(id);
        }

        public void Insert(data.Authors t)
        {
            t.AuId = null;
            new Solution.DAL.Authors(_solutionDBContext).Insert(t);
        }

        public void Updated(data.Authors t)
        {
            new Solution.DAL.Authors(_solutionDBContext).Updated(t);
        }
    }
}
