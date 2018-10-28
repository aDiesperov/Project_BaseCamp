using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstateAgency.Data;
using RealEstateAgency.Models;
using RealEstateAgency.ViewModels;

namespace RealEstateAgency.Controllers
{
    [Authorize]
    public class GalleryController : Controller
    {
        private UnitOfWork _unitOfWork;
        private UserManager<IdentityUser> _userManager;
        [TempData]
        public string MessageState { get; set; }

        public GalleryController(UnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            AdvertViewModel advertViewModel = new AdvertViewModel()
            {
                Adverts = _unitOfWork.AdvertRepository.GetAllResolve(),
                TypeRealEstates = _unitOfWork.TypeRealEstateRepository.GetAll()
            };
            ViewData["MessageState"] = MessageState;
            return View(advertViewModel);
        }
        [Authorize(Roles = "Agent")]
        [HttpGet]
        public IActionResult Create()
        {
            CreateAdvertViewModel createAdvertViewModel = new CreateAdvertViewModel()
            {
                TypesRealEstate = _unitOfWork.TypeRealEstateRepository.GetAll()
            };

            return View(createAdvertViewModel);
        }
        [Authorize(Roles = "Agent")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateAdvertViewModel createAdvert)
        {
            if (ModelState.IsValid)
            {
                TypeRealEstate typeRealEstate = await _unitOfWork.TypeRealEstateRepository.GetByIdAsync(createAdvert.TypeRealEstate);
                if (typeRealEstate != null)
                {
                    Advert advert = new Advert()
                    {
                        Name = createAdvert.Name,
                        Description = createAdvert.Description,
                        Price = createAdvert.Price,
                        TotalArea = createAdvert.TotalArea,
                        Floor = createAdvert.Floor,
                        KitchenArea = createAdvert.KitchenArea,
                        NumRooms = createAdvert.NumRooms,
                        NumStories = createAdvert.NumStories,
                        Rating = 0,
                        Rent = createAdvert.Rent,
                        StatusActive = TypeStatusAdvert.waiting,
                        DateChangeStatus = DateTime.Now,
                        DatePublication = DateTime.Now,
                        TypeRealEstate = typeRealEstate,
                        Author = await _unitOfWork.AgentRepository.GetByUserAsync(await _userManager.GetUserAsync(User)),
                    };

                    await _unitOfWork.AdvertRepository.CreateAsync(advert);

                    //upload files
                    foreach (var file in createAdvert.Files)
                    {
                        if (file.Length > 0)
                        {
                            string fileName;
                            do
                            {
                                fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                            } while (System.IO.File.Exists("imgs\\" + fileName));

                            using (var newImg = new FileStream("imgs\\" + fileName, FileMode.CreateNew, FileAccess.ReadWrite))
                            {
                                await file.CopyToAsync(newImg);
                            }
                            ImgForAdvert imgForAdvert = new ImgForAdvert() { Name = fileName, Advert = advert };
                            await _unitOfWork.ImgForAdvertRepository.CreateAsync(imgForAdvert);
                        }
                    }
                    MessageState = "Added!";
                    return RedirectToAction("Index");
                }
            }
            createAdvert.TypesRealEstate = _unitOfWork.TypeRealEstateRepository.GetAll();

            return View(createAdvert);


        }
        [HttpGet]
        public IActionResult CreateApplicationForRealEstate()
        {
            ApplicationForRealEstateViewModel application = new ApplicationForRealEstateViewModel()
            {
                TypesRealEstate = _unitOfWork.TypeRealEstateRepository.GetAll()
            };

            return View(application);
        }
        [HttpPost]
        public async Task<IActionResult> CreateApplicationForRealEstate(ApplicationForRealEstateViewModel applicationViewModel)
        {
            ApplicationForRealEstate application = new ApplicationForRealEstate()
            {
                Author = await _userManager.GetUserAsync(User),
                Active = true,
                DatePublication = DateTime.Now,
                Description = applicationViewModel.Description,
                FromFloor = applicationViewModel.FromFloor,
                FromKitchenArea = applicationViewModel.FromKitchenArea,
                FromNumRooms = applicationViewModel.FromNumRooms,
                FromPrice = applicationViewModel.FromPrice,
                FromTotalArea = applicationViewModel.FromTotalArea,
                Name = applicationViewModel.Name,
                ToFloor = applicationViewModel.ToFloor,
                ToKitchenArea = applicationViewModel.ToKitchenArea,
                ToNumRooms = applicationViewModel.ToNumRooms,
                ToPrice = applicationViewModel.ToPrice,
                ToTotalArea = applicationViewModel.ToTotalArea,
                TypeRealEstate = await _unitOfWork.TypeRealEstateRepository.GetByIdAsync(applicationViewModel.TypeRealEstate)
            };
            await _unitOfWork.ApplicationForRealEstateRepository.CreateAsync(application);

            MessageState = "Added!";
            return RedirectToAction("Index");
        }
        [Route("imgs/{id}")]
        public FileResult GetImg(string id)
        {
            return File(System.IO.File.ReadAllBytes("imgs\\" + id), System.Net.Mime.MediaTypeNames.Image.Jpeg);
        }
    }
}