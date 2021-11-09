﻿using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CountryManager : ICountryService
    {
        private readonly ICountryDal _countryDal;

        public CountryManager(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }
        public IResult Add(Country country)
        {
            _countryDal.Add(country);
            return new SuccessResult();
        }

        public IResult Delete(Country country)
        {
            _countryDal.Delete(country);
            return new SuccessResult();
        }

        public IDataResult<List<Country>> GetAll()
        {
            return new SuccessDataResult<List<Country>>(_countryDal.GetAll());
        }
         
        public IDataResult<Country> GetById(int id)
        {
            return new SuccessDataResult<Country>(_countryDal.Get(country => country.CountryId == id));
        }

        public IResult Update(Country country)
        {
            _countryDal.Update(country);
            return new SuccessResult();
        }
    }
}