using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal :EfEntityRepositoryBase<Car,ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetAllCarDetailsByFilter(CarDetailFilterDto filterDto)
        {        
        
        
            using (ReCapContext context =new ReCapContext())
            {
                var result = from c in context.Car
                             join b in context.Brand
                             on c.BrandId equals b.Id
                             join col in context.Color
                             on c.ColorId equals col.Id
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 BrandName = b.Name,
                                 Description = c.Description,
                                 DailyPrice = c.DailyPrice,
                                 ColorName = col.Name
                             };
                return result.ToList();
            }
        }

       
    }
}
