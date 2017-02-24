using Portfolio.DataAccessLayer.DomainClasses;
using Portfolio.Repository.Repositories;
using Portfolio.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.WebUI.Helpers
{
    public class DepartmentHelper
    {
        DepartmentRepository _deptRepo = new DepartmentRepository();

        public void InsertOrUpdate(DepartmentViewModel dept)
        {
            var dbDept = new Department()
            {
                Id = dept.Id,
                Name = dept.Name,
                ImagePath = dept.ImagePath
            };
            _deptRepo.InsertOrUpdate(dbDept);
        }

        public void DeleteDepartment(int id)
        {
            var delDept = _deptRepo.Find(id);
            _deptRepo.Delete(delDept);
        }

        public DepartmentViewModel FindDepartment(int id)
        {
            var dbDept = _deptRepo.Find(id);
            var Dept = new DepartmentViewModel()
            {
                Id = dbDept.Id,
                Name = dbDept.Name,
                ImagePath = dbDept.ImagePath
            };
            return Dept;
        }

        public List<DepartmentViewModel> AllDepartments()
        {
            var dbDepts = _deptRepo.All.ToList();
            var departments = new List<DepartmentViewModel>();

            foreach (var _dept in dbDepts)
            {
                string defaultPath = "/Content/Images/DeptImages/";
                var dept = new DepartmentViewModel()
                {
                    Id = _dept.Id,
                    Name = _dept.Name,
                    ImagePath = defaultPath + _dept.ImagePath
                };
                departments.Add(dept);
            }
            return departments;
        }
    }
}