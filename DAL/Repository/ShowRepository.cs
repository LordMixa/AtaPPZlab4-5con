using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.DBEntities;
using DAL.Repository;

namespace DAL
{
    public class ShowRepository:IRepository<DBShow>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly DbSet<DBShow> _showSet;
        public ShowRepository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _showSet=_unitOfWork.Context.Set<DBShow>();
        }
        public void Create(DBShow item)
        {
            _showSet.Add(item);
        }

        public void Delete(int id)
        {
            DBShow show = _showSet.Find(id);
            if (show != null)
                _showSet.Remove(show);
        }

        public DBShow Get(int id)
        {
            return _showSet.Find(id);
        }

        public IEnumerable<DBShow> GetAll()
        {
            return _showSet;
        }

        public void Update(DBShow item)
        {
            _showSet.Attach(item);
            _unitOfWork.Context.Entry(item).State = EntityState.Modified;
        }
    }
}
