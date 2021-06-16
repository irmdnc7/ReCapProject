using Core.DataAcess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal: IEntityRepository<Car>
    {
       
        List<CarDetailDto> GetAllCarDetailsByFilter(CarDetailFilterDto filterDto);
    }
}
