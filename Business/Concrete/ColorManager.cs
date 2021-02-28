using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager (IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            if (color.Name.Length< 2)
            {
                _colorDal.Add(color);
                return new ErrorResult(Messages.ColorNotAdded);
            }
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorListed);
        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == colorId), Messages.GetColorById);
        }

        public IResult Update(Color color)
        {
            if (color.Name.Length < 2)
            {
                return new ErrorResult(Messages.ColorNotUpdated);
            }
            return new SuccessResult(Messages.ColorUpdated);
        }

        
    }
}
