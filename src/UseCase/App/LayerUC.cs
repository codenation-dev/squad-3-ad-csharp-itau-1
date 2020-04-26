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
        public void Add(LayerDTO entity)
        {
            _repo.Add(_mapper.Map<Layer>(entity));
        }

        public void Delete(int entityId)
        {
            _repo.Delete(x => x.Id == entityId);
        }

        public LayerDTO Find(int entityId)
        {
            var entity = _repo.Find(x => x.Id == entityId);
            return _mapper.Map<LayerDTO>(entity);
        }

        public List<LayerDTO> FindAll(int entityId)
        {
            var entity = _repo.FindAll(x => x.Id == entityId);
            return _mapper.Map<List<LayerDTO>>(entity);
        }

        public LayerDTO Get(int entityId)
        {
            var entity = _repo.Get(entityId);
            return _mapper.Map<LayerDTO>(entity);
        }

        public void SaveOrUpdate(LayerDTO entity)
        {
            _repo.Update(_mapper.Map<Layer>(entity));
        }

        public List<LayerDTO> SelectAll()
        {
            var entity = _repo.SelectAll();
            return _mapper.Map<List<LayerDTO>>(entity);
        }
    }
}
