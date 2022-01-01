using Business.Abstract;
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

        public IResult DeleteByCountryName(string countryName)
        {
            var deletedCountry = _countryDal.Get(country => country.CountryName == countryName);
            _countryDal.Delete(deletedCountry);
            return new SuccessResult();
        }

        public IDataResult<List<Country>> GetAll()
        {
            return new SuccessDataResult<List<Country>>(_countryDal.GetAll());
        }

        public IDataResult<Country> GetByCountryName(string countryName)
        {
            return new SuccessDataResult<Country>(_countryDal.Get(country => country.CountryName==countryName));
        }

        public IDataResult<Country> GetById(int id)
        {
            return new SuccessDataResult<Country>(_countryDal.Get(country => country.CountryId == id));
        }

        public IDataResult<Country> GetCountryByName(string countryName)
        {
            return new SuccessDataResult<Country>(_countryDal.Get(country => country.CountryName.ToLower() == countryName.ToLower()));
        }

        public IDataResult<int> GetCountryIdByName(Country country)
        {
            var c = _countryDal.Get(country => country.CountryId==country.CountryId);

            return new SuccessDataResult<int>(c.CountryId);
        }

        public IResult Update(Country country)
        {
            _countryDal.Update(country);
            return new SuccessResult();
        }
    }
}
