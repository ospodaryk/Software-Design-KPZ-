using AutoMapper;
using CD_first_withDI.Data;
using CD_first_withDI.Models;
using CD_first_withDI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CD_first_withDI.ShoesData
{
    public class SqlShoesData : IShoesData
    {
        private IMapper _mapper;
        DataContext dataContext;
        public SqlShoesData(IMapper mapper, DataContext ctx)
        {
            this._mapper = mapper;
            dataContext = ctx;
        }
        public void AddShoes(ShoesViewModel cus)
        {
            var elementd = _mapper.Map<Shoes>(cus);

            dataContext.Pairs.Add(elementd);
            dataContext.SaveChanges();

        }
        public List<Shoes> GetPairofShoesList()
        {
            return dataContext.Pairs.ToList();
        }


        public void DeleteShoes(int id)
        {
            dataContext.Remove(dataContext.Pairs.FirstOrDefault(x => x.IdShoes == id));
            dataContext.SaveChanges();
        }

        public Shoes EditShoes(ShoesViewModel customerview)
        {
            Shoes customer = _mapper.Map<Shoes>(customerview);
            Shoes cus = dataContext.Pairs.FirstOrDefault(x => x.IdShoes == customer.IdShoes);
            cus = customer;
            dataContext.SaveChanges();
            return customer;
        }

        public Shoes GetShoes(int id)
        {
            return dataContext.Pairs.SingleOrDefault(x => x.IdShoes == id);
        }

    }
}
