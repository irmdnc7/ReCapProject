using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarImagesService
    {
        IResult Add(CarImages carImages, IFormFile file);
        IResult Delete(CarImages carImages);
        IResult Update(CarImages carImages, IFormFile file);
        IResult DeleteByCarId(int carId);
        IDataResult<List<CarImages>> GetAll();
        IDataResult<List<CarImages>> GetAllByCarId(int carId);
        IDataResult<CarImages> GetById(int id);

    }
}
