using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MenusController : BaseApiController
    {
        private readonly IGenericRepository<Menu> _menuRepository;
        private readonly IMapper _mapper;

        public MenusController(IGenericRepository<Menu> menuRepository, IMapper mapper)
        {
            _mapper = mapper;
            _menuRepository = menuRepository;

        }

        [HttpGet]
        public async Task<ActionResult<List<Menu>>> GetMenu(string name)
        {
            var menuSpec = new MenuAndMenuItems(name);
            var menuItems = await _menuRepository.ListAsync(menuSpec);

            return Ok(_mapper.Map<List<Menu>, List<MenuDto>>(menuItems));

        }

    }
}