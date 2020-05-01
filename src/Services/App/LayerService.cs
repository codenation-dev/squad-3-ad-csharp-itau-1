using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TryLog.Core.Interfaces;
using TryLog.Core.Model;
using TryLog.Services.ViewModel;
using TryLog.Services.Interfaces;

namespace TryLog.Services.App
{
    public class LayerService : ILayerService
    {
        private readonly ILayerRepository _repo;
        private readonly IMapper _mapper;
        public LayerService(ILayerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public LayerViewModel Add(LayerViewModel entity)
        {
            var layer = _repo.Add(_mapper.Map<Core.Model.Layer>(entity));
            return _mapper.Map<LayerViewModel>(layer);
        }

        public void Delete(int entityId)
        {
            _repo.Delete(x => x.Id == entityId);
        }

        public LayerViewModel Find(int entityId)
        {
            var layer = _repo.Find(x => x.Id == entityId);
            return _mapper.Map<LayerViewModel>(layer);
        }

        public List<LayerViewModel> FindAll(int entityId)
        {
            var layers = _repo.FindAll(x => x.Id == entityId);
            return _mapper.Map<List<LayerViewModel>>(layers);
        }

        public LayerViewModel Get(int entityId)
        {
            var layer = _repo.Get(entityId);
            return _mapper.Map<LayerViewModel>(layer);
        }

        public bool Update(LayerViewModel entity)
        {
            bool resultUpdate = _repo.Update(_mapper.Map<Core.Model.Layer>(entity));
            return resultUpdate;
        }

        public List<LayerViewModel> SelectAll()
        {
            var layers = _repo.SelectAll();
            return _mapper.Map<List<LayerViewModel>>(layers);
        }
    }
}
