
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebApplication1.Entidades;
using WebApplication1.Entidades.Pets;
using WebApplication1.Repositories.Pets;

namespace WebApplication1.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly WebApiContext _context;
        public PetRepository(WebApiContext context)
        {
            _context = context;
        }

        public void Create(Pet pet)
        {
            _context.Pet.Add(pet);
            _context.SaveChanges();
        }
        //TODO: update, List, delete
    }
}