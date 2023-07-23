using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NganHangNhaTro.Data;
using NganHangNhaTro.Helpers;
using NganHangNhaTro.Models.DataModels;
using NganHangNhaTro.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NganHangNhaTro.Service
{
    public interface IRealEstateService
    {
        List<VM_RealEstate> GetList();
        int CreateRealEstate(RealEstate realEstate);
        int CreateCompleteRealEstate(VM_RealEstateDetail detail, int agentId, IFormFile? file);
        void ActiveRealEstate(int id);
        IEnumerable<RealEstateType> GetRealEstateTypeList();
        List<RealEstateViewModel> GetUserAllPosts(int? userId);
        bool UpdateRealEstate(VM_RealEstateDetail detail, IFormFile? file);
        int DeleteRealEstate(int id, int userId);
        bool DisableRealEstate(int id);
        void ActiceRealEstate(int id);
        bool IsExistRealEstate(int id);
        Task<VM_RealEstateDetail> GetRealEstateDetail(int? id);
        List<RealEstateViewModel> CustomerExpireList();
        List<Result> GetRecommendList(int? id);
        IEnumerable<VM_RealEstateIsActive> GetRealEstateIsActiveList();
        List<RealEstateViewModel> GetCustomerConFirmList();
        List<RealEstate> SearchByTitle(string title);
        IQueryable<Result> Filter(Condition condition); 
    }
    public class RealEstateService : IRealEstateService 
    {
        private readonly MyDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RealEstateService (MyDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public List<VM_RealEstate> GetList ()
        {
           var list = new List<VM_RealEstate> ();
           var details = _context.RealEstate
                .Include(x => x.Agent)
                .Include(x => x.RealEstateType).ToList ();
            foreach ( var item in details )
            {
                var vm_rt = new VM_RealEstate { 
                    Id = item.Id,
                    Title = item.Title,
                    Address = item.Address,
                    ExprireTime = item.ExprireTime,
                    RealEstateTypeId = item.RealEstateType.Id,
                    Price = item.Price,
                    AgentName = item.Agent.AgentName, 
                    IsActive = item.IsActive,
                };
                list.Add (vm_rt);
            }
            return list; 
        }
        public IEnumerable<VM_RealEstateIsActive> GetRealEstateIsActiveList()
        {
            var list = new List<VM_RealEstateIsActive>();
            var details = _context.RealEstate
                .Include(x => x.Agent)
                .Include(x => x.RealEstateType)
                .ToList();

            foreach (var item in details)
            {
                var vm_rt = new VM_RealEstateIsActive
                {
                    Id = item.Id,
                    Title = item.Title,
                    Acreage = item.Acreage,
                    Address = item.Address,
                    PostTime = item.PostTime, // Chuyển đổi ngày tháng sang chuỗi ngày
                    RealEstateTypeName = item.RealEstateType.RealEstateTypeName,
                    Price = item.Price,
                    AgentName = item.Agent.AgentName,
                    ContactNumber = item.ContactNumber,
                    ImageUrl = item.imageUrl,
                    ViewCount = item.ViewCount,
                    IsActive = item.IsActive = true
                };

                list.Add(vm_rt);
            }

            return list;
        }
        
        public int CreateRealEstate (RealEstate realEstate)
        {
            try
            {
                _context.RealEstate.Add(realEstate);
                _context.SaveChanges();
                return realEstate.Id;
            }
            catch
            {
                return -1; 
            }
             
        }

        public int CreateCompleteRealEstate(VM_RealEstateDetail detail, int agentId , IFormFile file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;

            string imageUrl = UploadImage(file, wwwRootPath);

            var realEstate = new RealEstate()
            {
                PostTime = DateTime.Now,
                LastUpdate = DateTime.Now,
                BeginTime = Convert.ToDateTime(detail.BeginTime),
                ExprireTime = Convert.ToDateTime(detail.ExprireTime),
                RealEstateTypeId = detail.RealEstateTypeId,
                UserId = agentId,
                ContactNumber = detail.ContactNumber,
                IsActive = false,
                IsConfirm = agentId == 1,
                IsAvaiable = true,
                ConfirmStatus = agentId == 1 ? 1 : 0,
                Title = detail.Title,
                Price = detail.Price,
                Address = detail.Address,
                Acreage = detail.Acreage,
                RoomNumber = detail.RoomNumber,
                Description = detail.Description,
                HasPrivateWc = detail.HasPrivateWc,
                HasMezzanine = detail.HasMezzanine,
                AllowCook = detail.AllowCook,
                FreeTime = detail.FreeTime,
                SecurityCamera = detail.SecurityCamera,
                WaterPrice = detail.IsFreeWater ? 0 : Convert.ToInt32(detail.WaterPrice),
                ElectronicPrice = detail.IsFreeElectronic ? 0 : Convert.ToInt32(detail.ElectronicPrice),
                WifiPrice = detail.IsFreeWifi ? 0 : detail.WifiPrice,
                imageUrl = imageUrl 
            };

            try

            {
                _context.RealEstate.Add(realEstate);
                _context.SaveChanges();

                ActiveRealEstate(realEstate.Id);
            
                return realEstate.Id;
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
        public void ActiveRealEstate(int id)
        {
            var realEstate = _context.RealEstate.Find(id);
            if (realEstate != null && !realEstate.IsActive)
            {
                realEstate.IsActive = true;
                _context.SaveChanges();

            }
        }
        public IEnumerable<RealEstateType> GetRealEstateTypeList()
        {
            Console.WriteLine(_context.RealEstateType.ToList());
            return _context.RealEstateType.ToList();

        }
        private string UploadImage(IFormFile file, string wwwRootPath)
        {
            if (file != null && file.Length > 0)
            {
                string fileExtension = Path.GetExtension(file.FileName).ToLower();
                if (fileExtension != ".png" && fileExtension != ".jpg")
                {
                    throw new Exception("Vui lòng chỉ chọn tập tin ảnh định dạng PNG hoặc JPG.");
                }

                string filename = Guid.NewGuid().ToString() + fileExtension;
                string hanghoaPath = Path.Combine(wwwRootPath, "images", "RealEstate");
                string filePath = Path.Combine(hanghoaPath, filename);

                Directory.CreateDirectory(hanghoaPath); // Ensure the directory exists

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return "/images/RealEstate/" + filename; // Return the relative image URL
            }
            return null; // No image uploaded
        }
        public List<RealEstateViewModel> GetUserAllPosts(int? userId)
        {
            var results = new List<RealEstateViewModel>();
            var source = _context.RealEstate
                           .Include(r => r.RealEstateType)
                           .Include(r => r.Agent)
                           .Where(r => r.UserId == userId)
                           .OrderByDescending(r => r.PostTime)
                           .ThenByDescending(r => r.IsActive)
                           .ToList();

            foreach (var item in source)
            {
                var viewModelItem = new RealEstateViewModel
                {
                    Id = item.Id,
                    AgentId = item.Agent.Id,
                    Address = item.Address,
                    Price = Helper.VNCurrencyFormat(item.Price.ToString()),
                    PostDate = item.PostTime.ToString("dd/MM/yyyy"),
                    BeginTime = item.BeginTime.ToString("dd/MM/yyyy"),
                    ExpireTime = item.ExprireTime == null ? string.Empty : item.ExprireTime.Value.ToString("dd/MM/yyyy"),
                    Type = item.RealEstateType.RealEstateTypeName,
                    Status = Helper.GetStatus(item)
                };
                results.Add(viewModelItem);
            }

            return results;
        }

        public bool UpdateRealEstate (VM_RealEstateDetail detail , IFormFile? file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;

            string imageUrl = UploadImage(file, wwwRootPath);

            var rt = _context.RealEstate.Find(detail.Id); 
            if (rt != null)
            {
                rt.LastUpdate = DateTime.Now;
                rt.BeginTime = DateTime.Parse(detail.BeginTime);
                rt.ExprireTime = DateTime.Parse(detail.ExprireTime);
                rt.ContactNumber = detail.ContactNumber; 
                rt.Title = detail.Title;    
                rt.Description = detail.Description;
                rt.Price = detail.Price;
                rt.Acreage = detail.Acreage;
                rt.RoomNumber = detail.RoomNumber;
                rt.HasMezzanine = detail.HasMezzanine;
                rt.FreeTime = detail.FreeTime;
                rt.AllowCook = detail.AllowCook; 
                rt.SecurityCamera = detail.SecurityCamera;
                rt.WaterPrice = Convert.ToInt32(detail.WaterPrice);
                rt.ElectronicPrice = Convert.ToInt32(detail.ElectronicPrice);  
                rt.WifiPrice = Convert.ToInt32(detail.WifiPrice);
                rt.imageUrl = imageUrl;
                _context.SaveChanges();
                return true; 

            }
            else
            {
                return false; 
            }
        }

        public int DeleteRealEstate (int id, int userId)
        {
            
            try
            {
                var realEstate = _context.RealEstate.Find(id);
                var user = _context.Agent.Find(userId);
                if (realEstate != null && user != null)
                {
                    if (Convert.ToInt32(realEstate.UserId) == user.Id || user.LevelId == 1)
                    {
                        _context.RealEstate.Remove(realEstate);
                        _context.SaveChanges();
                        return 1; // thành công
                    }
                    else return 2; // user không hợp lệ
                }
                return 0; // not found
            }
            catch (Exception)
            {
                return -1; // lỗi hệ thống
            }
        }

        public bool DisableRealEstate (int id)
        {
            var realEstate = _context.RealEstate.Find(id); 
            if(realEstate != null && realEstate.IsActive)
            {
                realEstate.IsActive = false;
                realEstate.LastUpdate = DateTime.Now;
                _context.SaveChanges();
                return true;
            }
            return false; 
        }

        public void ActiceRealEstate(int id)
        {
            var realEstate = _context.RealEstate.Find(id); 
            if(realEstate != null && !realEstate.IsActive)
            {
                realEstate.IsActive = true;
                _context.SaveChanges();
            }
        }

        public bool IsExistRealEstate(int id)
        {
            return _context.RealEstate.Any(r => r.Id == id); 
        }

        public async Task<VM_RealEstateDetail> GetRealEstateDetail (int? id)
        {
            var info = await _context.RealEstate.Where(r => r.Id == id)
                .Include(r => r.RealEstateType)
                .Include(r => r.Agent)
                .SingleOrDefaultAsync();
            if(info != null)
            {
                // Tăng giá trị ViewCount lên 1
                info.ViewCount = info.ViewCount ?? 0; // Thiết lập giá trị mặc định là 0 nếu ViewCount là null
                info.ViewCount++;
                await _context.SaveChangesAsync();

                VM_RealEstateDetail result = Helper.MappingFromRealEstate(info); 
                return result;
            }
            return null;
        }
        public List<RealEstateViewModel> CustomerExpireList()
        {
            var results = new List<RealEstateViewModel>();
            var source = _context.RealEstate
                           .Include(r => r.RealEstateType)
                           .Include(r => r.Agent)
                           .Where(r => r.IsActive && r.ExprireTime < DateTime.Now)
                           .OrderByDescending(r => r.PostTime)
                           .ToList();

            foreach (var item in source)
            {
                var viewModelItem = new RealEstateViewModel
                {
                    Id = item.Id,
                    Address = item.Address,
                    Price = Helper.VNCurrencyFormat(item.Price.ToString()),
                    Agent = item.Agent.AgentName,
                    PostDate = item.PostTime.ToString("dd/MM/yyyy"),
                    BeginTime = item.BeginTime.ToString("dd/MM/yyyy"),
                    ExpireTime = item.ExprireTime == null ? string.Empty : item.ExprireTime.Value.ToString("dd/MM/yyyy"),
                    Type = item.RealEstateType.RealEstateTypeName,
                    Status = Helper.GetStatus(item)
                };
                results.Add(viewModelItem);
            }

            return results;
        }
        public List<RealEstateViewModel> GetCustomerConFirmList()
        {
            var results = new List<RealEstateViewModel>();
            var source = _context.RealEstate
                           .Include(r => r.RealEstateType)
                           .Include(r => r.Agent)
                           .Where(r => !r.IsConfirm)
                           .OrderByDescending(r => r.PostTime)
                           .ToList();

            foreach (var item in source)
            {
                var viewModelItem = new RealEstateViewModel
                {
                    Id = item.Id,
                    Address = item.Address,
                    Price = Helper.VNCurrencyFormat(item.Price.ToString()),
                    Agent = item.Agent.AgentName,
                    PostDate = item.PostTime.ToString("dd/MM/yyyy"),
                    BeginTime = item.BeginTime.ToString("dd/MM/yyyy"),
                    ExpireTime = item.ExprireTime == null ? string.Empty : item.ExprireTime.Value.ToString("dd/MM/yyyy"),
                    Type = item.RealEstateType.RealEstateTypeName,
                    Status = Helper.GetStatus(item)
                };
                results.Add(viewModelItem);
            }

            return results;
        }

        public List<RealEstate> SearchByTitle(string title)
        {
            using (var dbContext = new MyDbContext()) // Create an instance of MyDbContext
            {
                var results = dbContext.Set<RealEstate>().Where(x => EF.Functions.Like(x.Title, $"%{title}%")).ToList();
                return results;
            }
        }
        public IQueryable<Result> Filter(Condition condition)
        {
            try
            {
                var source = _context.RealEstate.Where(r => r.IsActive)
                                .Include(r => r.Agent)
                                .Include(r => r.RealEstateType)
                                .OrderByDescending(r => r.IsAvaiable)
                                .ThenByDescending(r => r.PostTime)
                                .ThenByDescending(r => r.ExprireTime)
                                .AsQueryable();

                if (source != null && condition != null)
                {
                    
                    var priceRange = Helper.GetPriceRange(condition.PriceRange);
                    var minPrice = priceRange[0];
                    var maxPrice = priceRange[1];
                    source = source.Where(x =>
                        x.Price >= minPrice && x.Price <= maxPrice);

                    var acreageRange = Helper.GetAcreageRange(condition.AcreageRange);
                    var minAcreage = acreageRange[0];
                    var maxAcreage = acreageRange[1];
                    source = source.Where(x =>
                       x.Acreage >= minAcreage && x.Acreage <= maxAcreage);

                    if (!string.IsNullOrEmpty(condition.SearchString.Trim()))
                    {
                        if (DateTime.TryParse(condition.SearchString, out DateTime searchDate))
                        {
                            source = source.Where(x => x.PostTime < searchDate && x.ExprireTime > searchDate);
                        }
                        else
                        {
                            source = source.Where(x => x.Address.Contains(condition.SearchString)
                                                     || x.Price.ToString().Contains(condition.SearchString));
                        }
                    }
                }

                IQueryable<Result> results = (from item in source
                                              select new Result
                                              {
                                                  Id = item.Id,
                                                  Address = Helper.GetStreet(item.Address),
                                                  Price = item.Price,
                                                  Acreage = item.Acreage,
                                                  Type = item.RealEstateType.RealEstateTypeName,
                                                  PostTime = item.PostTime.ToString("dd/MM/yyyy"),
                                                  ImageUrl = item.imageUrl,
                                                  AgentName = item.Agent.AgentName,
                                                  ContactNumber = item.ContactNumber
                                              });

                return results;

            }
            catch
            {
                return null;
            }
        }
        public List<Result> GetRecommendList(int? id)
        {
            var realEstate = _context.RealEstate.Where(r => r.Id == id)
                                .Include(r => r.Agent)
                                .SingleOrDefault();

            if (realEstate == null)
            {
                return null;
            }
            else
            {
                var source = _context.RealEstate.Include(r => r.Agent)
                                                .Include(r => r.RealEstateType)
                                                .Where(r => r.Id != realEstate.Id
                                                && r.RealEstateTypeId == realEstate.RealEstateTypeId
                                                && r.IsActive && r.ConfirmStatus == 1 && r.ExprireTime > DateTime.Now && r.IsAvaiable)
                                                .OrderByDescending(r => r.PostTime).Take(4);

                var result = (from item in source
                              select new Result
                              {
                                  Id = item.Id,
                                  Address = Helper.GetStreet(item.Address),
                                  Price = item.Price,
                                  Acreage = item.Acreage,
                                  Type = item.RealEstateType.RealEstateTypeName,
                                  PostTime = item.PostTime.ToString("dd/MM/yyyy"),
                                  ImageUrl = item.imageUrl,
                                  AgentName = item.Agent.AgentName,
                                  ContactNumber = item.ContactNumber
                              }).ToList();
                return result;
            }
        }
    }
}

