using ComposTux.Entities;
using ComposTux.Models;
using ComposTux.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ComposTux.BussinesLayer
{
    public class BLCompany
    {
        public async Task<bool> InsertCompany(Company company)
        {
            try
            {
                using (var db = new ProyectosEntities())
                {
                    var response = db.spInsCompany(company.CompanyName, company.CompanyAddress, company.CompanyLatitud, company.CompanyLongitud, company.IdUser);
                    if(response == -1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch(Exception x)
            {
                Console.WriteLine(x.Message);
                return false;
            }
        }
        public async Task<bool> UpdateCompany(Company company)
        {
            try
            {
                using (var db = new ProyectosEntities())
                {
                    var response = db.spUpdCompany(company.CompanyName, company.CompanyAddress, company.CompanyLatitud, company.CompanyLongitud, company.IdUser, company.IdCompany);
                    if (response == -1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
                return false;
            }
        }
        public async Task<BaseResult<Company>> SelectCompany(Guid IdUser)
        {
            try
            {
                BaseResult<Company> baseResult = new BaseResult<Company>();
                Company company = new Company();
                using (var db = new ProyectosEntities())
                {
                    var response = db.spSelCompany(IdUser).FirstOrDefault();
                    if(response != null)
                    {
                        company.CompanyActive = response.CompanyActive;
                        company.CompanyAddress = response.CompanyAddress;
                        company.CompanyLatitud = response.CompanyLatitud;
                        company.CompanyLongitud = response.CompanyLongitud;
                        company.CompanyName = response.CompanyName;
                        company.IdCompany = response.IdCompany;
                        company.IdUser = response.IdUser;
                        baseResult.Count = 1;
                        baseResult.Message = "";
                        baseResult.Result = company;
                    }
                    else
                    {
                        baseResult.Count = 0;
                        baseResult.Message = "No encontrado";
                        baseResult.Result = null;
                    }
                }
                return baseResult;
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
                return null;
            }
        }
        public async Task<BaseResult<List<Company>>> SelectCompanyAll()
        {
            try
            {
                BaseResult<List<Company>> baseResult = new BaseResult<List<Company>>();
                List<Company> Listcompany = new List<Company>();
                using (var db = new ProyectosEntities())
                {
                    var responseResult = db.spSelAllCompany().ToList();
                    if (responseResult != null)
                    {
                        foreach(var response in responseResult)
                        {
                            Company company = new Company();
                            company.CompanyActive = response.CompanyActive;
                            company.CompanyAddress = response.CompanyAddress;
                            company.CompanyLatitud = response.CompanyLatitud;
                            company.CompanyLongitud = response.CompanyLongitud;
                            company.CompanyName = response.CompanyName;
                            company.IdCompany = response.IdCompany;
                            company.IdUser = response.IdUser;
                            Listcompany.Add(company);
                        }                      
                        baseResult.Count = Listcompany.Count;
                        baseResult.Message = "";
                        baseResult.Result = Listcompany;
                    }
                    else
                    {
                        baseResult.Count = 0;
                        baseResult.Message = "No encontrado";
                        baseResult.Result = null;
                    }
                }
                return baseResult;
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
                return null;
            }
        }
    }
}