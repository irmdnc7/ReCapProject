using Core.DataAcess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarImagesDal:IEntityRepository<CarImages>
    {
        bool IsExist(int id);
    }
}
