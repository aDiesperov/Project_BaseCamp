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
                Adverts = _unitOfWork.AdvertRepository.GetAll(),
                TypeRealEstates = _unitOfWork.TypeRealEstateRepository.GetAll()
            };

            return View(advertViewModel);
        }
        [Authorize(Roles = "Agent")]
        [HttpGet]
        public IActionResult Create()
        {
            CreateAdvertViewModel createAdvertViewModel = new CreateAdvertViewModel()
            {
                TypeRealEstates = _unitOfWork.TypeRealEstateRepository.GetAll().ToList()
            };

            return View(createAdvertViewModel);
        }
        [Authorize(Roles = "Agent")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateAdvertViewModel createAdvert)
        {
            if (ModelState.IsValid && false)
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
                    TypeRealEstate = await _unitOfWork.TypeRealEstateRepository.GetByIdAsync(createAdvert.TypeRealEstate),
                    Author = _unitOfWork.AgentRepository.GetByUser(await _userManager.GetUserAsync(User)),
                };

                //upload files
                foreach(var file in createAdvert.Files)
                {
                    if (file.Length > 0)
                    {
                        string fileName;
                        do
                        {
                            fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        } while (System.IO.File.Exists("imgs\\" + fileName));

                        using (var newImg = new FileStream("imgs\\" + fileName, FileMode.CreateNew, FileAccess.Write)) {
                            await file.CopyToAsync(newImg);
                        }
                        ImgForAdvert imgForAdvert = new ImgForAdvert() { Name = fileName, Advert = advert };
                        await _unitOfWork.ImgForAdvertRepository.CreateAsync(imgForAdvert);
                    }
                }

                await _unitOfWork.AdvertRepository.CreateAsync(advert);
            }
            else
            {
                createAdvert.TypeRealEstates = _unitOfWork.TypeRealEstateRepository.GetAll().ToList();

                return View(createAdvert);
            }
            return RedirectToAction();
        }
    }
}