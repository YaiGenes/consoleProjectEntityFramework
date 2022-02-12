using entityFrameworkTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityFrameworkTest.Services
{
    public interface IGolgiOrderProcessor
    {
        SynthesisResult<Assembling> Process(string processFile);
    }
}
