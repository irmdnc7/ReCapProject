using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using Business.ValidationRules.FluentValidation;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImagesService
    {
        ICarImagesDal _carImageDal;
        public CarImagesManager(ICarImagesDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        [ValidationAspect(typeof(CarImagesValidator))]
        [SecuredOperation("admin")]
        public IResult Add(CarImages carImages, IFormFile file)
        {
            IResult result = BusinessRules.Run(
                  CheckIfImageLimitExpired(carImages.CarId),
                  CheckIfImageExtensionValid(file)
                  );

            if (result != null)
            {
                return result;
            }

            carImages.ImagePath = FileHelper.Add(file);
            carImages.Date = DateTime.Now;
            _carImageDal.Add(carImages);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(CarImages carImages)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageExists(carImages.Id)
                );
            if (result != null)
            {
                return result;
            }
            string path = GetById(carImages.Id).Data.ImagePath;
            FileHelper.Delete(path);
            _carImageDal.Delete(carImages);
            return new SuccessResult();
        }

        public IResult DeleteByCarId(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Any())
            {
                foreach (var carImage in result)
                {
                    Delete(carImage);
                }
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarHaveNoImage);
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImages>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImages>>(CheckIfCarHaveNoImage(carId));
        }

        public IDataResult<CarImages> GetById(int id)
        {
            return new SuccessDataResult<CarImages>(_carImageDal.Get(c => c.Id == id));
        }
        [SecuredOperation("admin")]
        public IResult Update(CarImages carImages, IFormFile file)
        {
            IResult result = BusinessRules.Run(
                   CheckIfImageLimitExpired(carImages.CarId),
                   CheckIfImageExtensionValid(file),
                   CheckIfImageExists(carImages.Id)
                   );

            if (result != null)
            {
                return result;
            }

            CarImages oldCarImage = GetById(carImages.Id).Data;
            carImages.ImagePath = FileHelper.Update(file, oldCarImage.ImagePath);
            carImages.Date = DateTime.Now;
            carImages.CarId = oldCarImage.CarId;
            _carImageDal.Update(carImages);
            return new SuccessResult();
        }
        private IResult CheckIfImageLimitExpired(int carId)
        {
            int result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
                return new ErrorResult(Messages.ImageLimitExpiredForCar);
            return new SuccessResult();
        }
        private IResult CheckIfImageExtensionValid(IFormFile file)
        {
            bool isValidFileExtension = Messages.ValidImageFileTypes.Any(t => t == Path.GetExtension(file.FileName).ToUpper());
            if (!isValidFileExtension)
                return new ErrorResult(Messages.InvalidImageExtension);
            return new SuccessResult();
        }

        private List<CarImages> CheckIfCarHaveNoImage(int carId)
        {
            string path = @"\Images\default.png";
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (!result.Any())
                return new List<CarImages> { new CarImages { CarId = carId, ImagePath = path } };
            return result;
        }

        private IResult CheckIfImageExists(int id)
        {
            if (_carImageDal.IsExist(id))
                return new SuccessResult();
            return new ErrorResult(Messages.CarImageMustBeExists);
        }
    }
}
