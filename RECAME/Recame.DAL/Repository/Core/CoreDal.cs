﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recame.DAL.Repository.Core
{
    public class CoreDal
    {
        private readonly BaseDal _Dal;
        protected BaseDal Dal
        {
            get
            {
                return _Dal;
            }
        }

        protected RecameDBEntities db
        {
            get
            {
                return _Dal.db;
            }
        }

        protected CoreDal(BaseDal dal)
        {
            if (dal == null)
                throw new ArgumentNullException("dal");
            _Dal = dal;
        }
    }
}
