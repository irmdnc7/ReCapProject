﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        ICarImagesService _carImagesService;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
           
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
                         
            
            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);                               
                         
        }
        [TransactionScopeAspect]
        

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            _carImagesService.DeleteByCarId(car.Id);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
           
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }
        [CacheAspect]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId));
        }

        public IDataResult<List<Car>> GetCarsByBrand(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => (p.BrandId) == brandId));
        }

       

        public IDataResult<List<Car>> GetCarsByColor(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetails(CarDetailFilterDto filterDto)
        {
             return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetailsByFilter(filterDto));
        }

        public IDataResult<List<CarDetailDto>> GetFilterCar(int brandId, int colorId)
        {
            throw new NotImplementedException();
        }
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);
        }
        
        

        
    }
}
