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
            var layer = _repo.Add(_mapper.Map<Layer>(entity));
            return _mapper.Map<LayerViewModel>(layer);
        }

        public bool Delete(int entityId)
        {
            bool resultDelete = false;
            var layer = _repo.Find(x => x.Id == entityId && x.Deleted == false);
            
            if (layer != null)
            {
                layer.Deleted = true;
                resultDelete = _repo.Update(layer);
            }

            return resultDelete;
        }

        public LayerViewModel Get(int entityId)
        {
            var layer = _repo.Find(x => x.Id == entityId && x.Deleted == false);
            return _mapper.Map<LayerViewModel>(layer);
        }

        public bool Update(LayerViewModel entity)
        {
            bool resultUpdate = false;
            var layer = _repo.Find(x => x.Id == entity.Id && x.Deleted == false);

            if (layer != null)
            {
                resultUpdate = _repo.Update(_mapper.Map<Layer>(entity));
            }

            return resultUpdate;
        }

        public List<LayerViewModel> SelectAll()
        {
            var layers = _repo.FindAll(x => x.Deleted == false);
            return _mapper.Map<List<LayerViewModel>>(layers);
        }
    }
}
