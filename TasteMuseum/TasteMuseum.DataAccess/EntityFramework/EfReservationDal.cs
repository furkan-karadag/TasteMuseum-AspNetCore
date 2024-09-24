﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteMuseum.DataAccess.Abstract;
using TasteMuseum.DataAccess.Repository;
using TasteMuseum.Entity.Concrete;

namespace TasteMuseum.DataAccess.EntityFramework
{
    public class EfReservationDal:GenericRepository<Reservation> , IReservationDal
    {
    }
}
