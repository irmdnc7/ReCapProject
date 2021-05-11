using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);

        IResult Update(Car car);
        IResult Delete(Car car);

        IDataResult<List<Car>>GetAll();
        IDataResult<Car> GetById(int id);
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId);

        IDataResult<List<CarDetailDto>> GetFilterCar(int brandId, int colorId);

        IDataResult<List<CarDetailDto>> GetCarDetails();

        IDataResult<CarDetailDto> GetCarDetailsById(int id);
        IResult AddTransactionalTest(Car car);
        

    }
}
