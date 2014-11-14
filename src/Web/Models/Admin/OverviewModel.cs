using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wishes.Core.Domain.Model;

namespace Wishes.Web.Models.Admin
{
    public class OverviewModel
    {
        public IEnumerable<User> Users { get; set; }


    }
}