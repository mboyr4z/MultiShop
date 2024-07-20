using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoOperationManager : ICargoOperationDal
    {
        private readonly ICargoOperationDal _cargoOperationDal;

        public CargoOperationManager(ICargoOperationDal cargoOperationDal)
        {
            _cargoOperationDal = cargoOperationDal;
        }
        public void Delete(int id)
        {
            _cargoOperationDal.Delete(id);
        }

        public List<CargoOperation> GetAll()
        {
            return _cargoOperationDal.GetAll();
        }

        public CargoOperation GetById(int id)
        {
            return _cargoOperationDal.GetById(id);
        }

        public void Insert(CargoOperation entity)
        {
            _cargoOperationDal.Insert(entity);
        }

        public void Update(CargoOperation entity)
        {
            _cargoOperationDal.Update(entity);
        }
    }
}
