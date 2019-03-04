using FeelMiserable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeelMiserable.Services
{
    public class Randomize
    {
        //List<SlangStore> slangs;
        //public Randomize(List<SlangStore> s)
        //{
        //    slangs = s;
        //}

        public SlangStore GetRandom(List<SlangStore> slangs)
        {
            Random random = new Random();
            var index = random.Next(slangs.Count);
            var result = slangs[index];

            return result;
        }



    }
}