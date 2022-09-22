using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoyadoSearchTest.Repository.Interfaces
{
    public interface IBingRepository
    {
        int SearchBing(string[] words);
    }
}
