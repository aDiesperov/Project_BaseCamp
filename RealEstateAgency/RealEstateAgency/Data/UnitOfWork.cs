using RealEstateAgency.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAgency.Data
{
    public class UnitOfWork
    {
        private ApplicationDbContext _context;
        private AdvertRepository advertRepository;
        private AgentRepository agentRepository;
        private ImgForAdvertRepository imgForAdvertRepository;
        private MessageRepository messageRepository;
        private TypeRealEstateRepository typeRealEstateRepository;

        public UnitOfWork(ApplicationDbContext context) => _context = context;

        public AdvertRepository AdvertRepository
        {
            get
            {
                if (this.advertRepository == null) this.advertRepository = new AdvertRepository(_context);
                return this.advertRepository;
            }
        }
        public AgentRepository AgentRepository
        {
            get
            {
                if (this.agentRepository == null) this.agentRepository = new AgentRepository(_context);
                return this.agentRepository;
            }
        }
        public ImgForAdvertRepository ImgForAdvertRepository
        {
            get
            {
                if (this.imgForAdvertRepository == null) this.imgForAdvertRepository = new ImgForAdvertRepository(_context);
                return this.imgForAdvertRepository;
            }
        }
        public MessageRepository MessageRepository
        {
            get
            {
                if (this.messageRepository == null) this.messageRepository = new MessageRepository(_context);
                return this.messageRepository;
            }
        }
        public TypeRealEstateRepository TypeRealEstateRepository
        {
            get
            {
                if (this.typeRealEstateRepository == null) this.typeRealEstateRepository = new TypeRealEstateRepository(_context);
                return this.typeRealEstateRepository;
            }
        }
    }
}