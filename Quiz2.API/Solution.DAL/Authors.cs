using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class Authors : ICRUD<data.Authors>
    {
        private Repository<data.Authors> _repository = null;
        public Authors(SolutionDBContext solutionDBContext)
        {
            _repository = new Repository<data.Authors>(solutionDBContext);
        }

        public void Delete(data.Authors t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.Authors> GetAll()
        {
            return _repository.GetAll();
        }

        public data.Authors GetOneById(int id)
        {
            return _repository.GetOnebyId(id);
        }

        public void Insert(data.Authors t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Updated(data.Authors t)
        {
            _repository.Update(t);
            _repository.Commit();
        }
    }
}
