using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DataAccess.Entities;
using DataAccess.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class RouteService : IRouteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RouteService(IUnitOfWork uow, IMapper map)
        {
            _unitOfWork = uow;
            _mapper = map;
        }
        public async Task<RouteDto> GetRouteAsync(int id)
        {
            var route = _mapper.Map<RouteDto>(await _unitOfWork.RouteRepository.GetAsync(id));
            return route;
        }

        public async Task<IEnumerable<RouteDto>> GetAllRoutesAsync()
        {
            var routes = _mapper.Map<IEnumerable<RouteDto>>(await _unitOfWork.RouteRepository.GetAllAsync());
            return routes;
        }

        public async Task AddRouteAsync(RouteDto routeDto)
        {
            var route = _mapper.Map<Route>(routeDto);
            await _unitOfWork.RouteRepository.AddAsync(route);
            await _unitOfWork.SaveAsync();
        }
        public async Task UpdateRouteAsync(RouteDto routeDto)
        {
            var route = _mapper.Map<Route>(routeDto);
            await _unitOfWork.RouteRepository.UpdateAsync(route);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteRouteAsync(int id)
        {
            await _unitOfWork.RouteRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }
    }
}
