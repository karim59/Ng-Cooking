﻿using Cooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Service
{
    public interface IUserService
    {
        bool Add( User u );
        List<User> Get();
        User Get(int id );
        bool Remove(int id);
    }
}
