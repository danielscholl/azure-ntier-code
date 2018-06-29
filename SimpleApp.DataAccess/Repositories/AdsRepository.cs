using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleApp.DataAccess.Models;

namespace SimpleApp.DataAccess.Repositories
{
    public class AdsRepository
    {
        private readonly AdContext _context;

        public AdsRepository(AdContext context)
        {
            _context = context;
        }

        public List<Ad> GetAds()
        {
            return _context.Ads.ToList();
        }
        public bool TryGetAd(int id, out Ad ad)
        {
            ad = _context.Ads.Find(id);

            return (ad != null);
        }

    }
}
