using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TryLog.Core.Interfaces;
using TryLog.Core.Model;
using TryLog.UseCase.DTO;
using TryLog.UseCase.Interfaces;

namespace TryLog.UseCase.App
{
    public class LayerUC : ILayerUC
    {
        private readonly ILayerRepository _repo;
        private readonly IMapper _mapper;
        public LayerUC(ILayerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public LayerDTO Add(LayerDTO entity)
        {
            var layer = _repo.Add(_mapper.Map<Layer>(entity));
            return _mapper.Map<LayerDTO>(layer);
        }

        public void Delete(int entityId)
        {
            _repo.Delete(x => x.Id == entityId);
        }

        public LayerDTO Find(int entityId)
        {
            var layer = _repo.Find(x => x.Id == entityId);
            return _mapper.Map<LayerDTO>(layer);
        }

        public List<LayerDTO> FindAll(int entityId)
        {
            var layers = _repo.FindAll(x => x.Id == entityId);
            return _mapper.Map<List<LayerDTO>>(layers);
        }

        public LayerDTO Get(int entityId)
        {
            var layer = _repo.Get(entityId);
            return _mapper.Map<LayerDTO>(layer);
        }

        public bool Update(LayerDTO entity)
        {
            bool resultUpdate = _repo.Update(_mapper.Map<Layer>(entity));
            return resultUpdate;
        }

        public List<LayerDTO> SelectAll()
        {
            var layers = _repo.SelectAll();
            return _mapper.Map<List<LayerDTO>>(layers);
        }
    }
}
